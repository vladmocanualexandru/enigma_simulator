using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enigma.Logistics;
using Enigma.Enumerations;

namespace Enigma.Components
{
    class EnigmaMachine
    {
        public Dictionary<String, Rotor> Rotors { get; set; }
        public InterRotorsConnection Connections { get; set; }
        public Reflector Reflector { get; set; }
        public Plugboard Plugboard { get; set; }
        public int NumberOfRotors { get; set; }

        private ConfigurationHolder configHolder = ConfigurationHolder.GetInstance();
        
        public EnigmaMachine (int numberOfRotorsParam)
        {

            Reflector = new Reflector();
            Plugboard = new Plugboard();

            NumberOfRotors = numberOfRotorsParam;
            Rotors = new Dictionary<String, Rotor>(numberOfRotorsParam);

            for (int i = 0; i < NumberOfRotors; i++)
            {
                Rotors.Add("rotor_"+i, new Rotor(i));
            }

            Connections = new InterRotorsConnection(NumberOfRotors);

        }

        public void AdvanceRotors()
        {
            RecursiveAdvanceRotors(0,false);
        }

        public void WithdrawRotors()
        {
            RecursiveAdvanceRotors(0, true);
        }

        private void RecursiveAdvanceRotors(int rotorNumber, bool reversedMode)
        {
            if (rotorNumber == Rotors.Count) return;

            if (!reversedMode)
            {
                if (Rotors["rotor_"+rotorNumber].TurnUp())
                {
                    RecursiveAdvanceRotors(rotorNumber+1, false);
                }
            }
            else
            {
                if (Rotors["rotor_" + rotorNumber].TurnDown())
                {
                    RecursiveAdvanceRotors(rotorNumber + 1, true);
                }
            }
        }

        public int GetEncrytedKeyValue(int inputKeyValue)
        {
            Plugboard.Contacts[inputKeyValue].State = ContactState.LEFT_TO_RIGHT;
            Plugboard.MarkContact(Plugboard.Contacts[inputKeyValue]);

            if (Plugboard.Contacts[inputKeyValue].RightIndex != inputKeyValue)
            {
                inputKeyValue = Plugboard.Contacts[inputKeyValue].RightIndex;

                Plugboard.Contacts[inputKeyValue].State = ContactState.LEFT_TO_RIGHT;
                Plugboard.MarkContact(Plugboard.Contacts[inputKeyValue]);
            }
            
            
            int encryptedValue = PerformRecursiveCurrentFlow(0, inputKeyValue, true);

            Plugboard.Contacts[encryptedValue].State = ContactState.RIGHT_TO_LEFT;
            Plugboard.MarkContact(Plugboard.Contacts[encryptedValue]);

            if (Plugboard.Contacts[encryptedValue].RightIndex != encryptedValue)
            {
                encryptedValue = Plugboard.Contacts[encryptedValue].RightIndex;

                Plugboard.Contacts[encryptedValue].State = ContactState.RIGHT_TO_LEFT;
                Plugboard.MarkContact(Plugboard.Contacts[encryptedValue]);
            }

            return encryptedValue;
        }

        private int PerformRecursiveCurrentFlow(int rotorNumber, int contactEntryIndex, bool leftToRight)
        {
            String rotorName = "rotor_" + rotorNumber;
            Contact selectedContact;

            if (leftToRight)
            {
                if (rotorNumber == Rotors.Count)
                {
                    selectedContact =
                        Reflector.Contacts.First(contact => contact.LeftIndex == contactEntryIndex||contact.RightIndex == contactEntryIndex);

                    Reflector.MarkContact(selectedContact);

                    selectedContact.State = ContactState.RIGHT_TO_LEFT;
                    Connections.Contacts[rotorName][selectedContact.LeftIndex != contactEntryIndex
                                                    ? selectedContact.LeftIndex
                                                    : selectedContact.RightIndex].State = ContactState.RIGHT_TO_LEFT;

                    Connections.MarkContact(Connections.Contacts[rotorName][selectedContact.LeftIndex != contactEntryIndex
                                                    ? selectedContact.LeftIndex
                                                    : selectedContact.RightIndex]);

                    Connections.Contacts[rotorName][contactEntryIndex].State = ContactState.LEFT_TO_RIGHT;

                    Connections.MarkContact(Connections.Contacts[rotorName][contactEntryIndex]);


                    return PerformRecursiveCurrentFlow(rotorNumber - 1,
                                                (selectedContact.LeftIndex != contactEntryIndex
                                                    ? selectedContact.LeftIndex
                                                    : selectedContact.RightIndex),false);
                }
                else
                {
                    selectedContact =
                        Rotors[rotorName].Contacts.First(contact => contact.LeftIndex == contactEntryIndex);

                    selectedContact.State = ContactState.LEFT_TO_RIGHT;

                    Rotors[rotorName].MarkContact(selectedContact);

                    Connections.Contacts[rotorName][contactEntryIndex].State = ContactState.LEFT_TO_RIGHT;
                    Connections.MarkContact(Connections.Contacts[rotorName][contactEntryIndex]);

                    return PerformRecursiveCurrentFlow(rotorNumber + 1, selectedContact.RightIndex, true);
                }
            }
            else
            {
                if (rotorNumber == -1)
                {
                    return contactEntryIndex;
                }
                else
                {
                    selectedContact =
                        Rotors[rotorName].Contacts.First(contact => contact.RightIndex == contactEntryIndex);

                    selectedContact.State = ContactState.RIGHT_TO_LEFT;

                    Rotors[rotorName].MarkContact(selectedContact);

                    Connections.Contacts[rotorName][selectedContact.LeftIndex].State = ContactState.RIGHT_TO_LEFT;
                    Connections.MarkContact(Connections.Contacts[rotorName][selectedContact.LeftIndex]);

                    return PerformRecursiveCurrentFlow(rotorNumber -1, selectedContact.LeftIndex, false);
                }
            }
        }

        public void ResetContactMarkings()
        {
            foreach (var rotor in Rotors.Values)
            {
                rotor.ResetContactMarkings();
            }

            Plugboard.ResetContactMarkings();

            Reflector.ResetContactMarkings();

            Connections.ResetContactMarkings();
        }

        private static String ConvertIndexToLetter(int index)
        {
            return Convert.ToChar(index + 65).ToString();
        }

        public String GenerateMachineKey()
        {
            String key = ConvertIndexToLetter(Rotors.Count);

            foreach (var rotor in Rotors.Values)
            {
                key += ConvertIndexToLetter(rotor.AlphabetOffset);
                key += ConvertIndexToLetter(rotor.CurrentIndex);

            }

            return key;
        }

        public String GetEncryptedString(String inputString)
        {
            String result="";

            for (int pos=0; pos<inputString.Length; pos++)
            {
                int letterValue = inputString.Substring(pos, 1).ToCharArray()[0];
                letterValue = letterValue <= 90 ? (letterValue - 65) : (letterValue - 97);

                if (letterValue < 0)
                {
                    return null;
                }

                this.AdvanceRotors();
                int encryptedValue = GetEncrytedKeyValue(letterValue);

                result += Convert.ToChar(encryptedValue+65).ToString();
            }

            return result;
        }
    }
}
