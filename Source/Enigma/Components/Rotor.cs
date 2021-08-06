using System;
using System.Collections.Generic;
using System.Linq;

using Enigma.Logistics;
using Enigma.Enumerations;
using Enigma.Interfaces;

namespace Enigma.Components
{
    class Rotor : IResetableMarkings
    {
        public List<Contact> Contacts { get; set; }
        public int CurrentIndex { get; set; }
        public int StepIndex { get; set; }
        public String Name { get; set; }
        public int AlphabetOffset { set; get; }
        public int ConfigNumber { set; get; }

        private List<Contact> markedContacts;

        private ConfigurationHolder configHolder = ConfigurationHolder.GetInstance();

        public Rotor(int confNumber)
        {
            Name = "rotor_" + confNumber;
            CurrentIndex = 0;
            AlphabetOffset = 0;
            ConfigNumber = confNumber;
            StepIndex = Convert.ToInt32(configHolder.Settings["conf_"+confNumber+"_step"].ToCharArray()[0]) - 65;

            String contactWiring = configHolder.Settings["conf_" + confNumber];
            Contacts = new List<Contact>(26);

            for (int i = 0; i < 26; i++ )
            {

                int leftIndex = Convert.ToInt32(contactWiring.ToCharArray()[2 * i])-65;
                int rightIndex = Convert.ToInt32(contactWiring.ToCharArray()[2 * i + 1])-65;

                Contacts.Add(new Contact(leftIndex, rightIndex));
            }

            markedContacts = new List<Contact>(2);

        }

        public bool TurnUp()
        {
            for (int i=0; i<26; i++)
            {
                Contacts[i].LeftIndex= (Contacts[i].LeftIndex -1 + 26)%26;
                Contacts[i].RightIndex = (Contacts[i].RightIndex -1 + 26) % 26;
            }

            CurrentIndex = (CurrentIndex + 1) % 26;


            if (--StepIndex < 0) StepIndex += 26;

            if (StepIndex == 25)
            {
                return true;
            }
            return false;

        }

        public int TurnUp(int numberOfSteps)
        {
            int stepCounter = 0; // counts how many times the next rotor must be turned up
            for (int i = 0; i < numberOfSteps; i++ )
            {
                if (TurnUp()) stepCounter++;
            }

            return stepCounter;
        }

        public bool TurnDown()
        {
            for (int i = 0; i < 26; i++)
            {
                Contacts[i].LeftIndex = (Contacts[i].LeftIndex +1) % 26;
                Contacts[i].RightIndex = (Contacts[i].RightIndex +1) % 26;
            }

            if (--CurrentIndex < 0) CurrentIndex += 26;

            StepIndex = (StepIndex + 1) % 26;

            if (StepIndex == 0)
            {
                return true;
            }

            return false;

        }

        public int TurnDown(int numberOfSteps)
        {
            int stepCounter = 0; // counts how many times the next rotor must be turned down
            for (int i = 0; i < numberOfSteps; i++)
            {
                if (TurnDown()) stepCounter++;
            }

            return stepCounter;
        }

        public void AdvanceAlphabet()
        {
            CurrentIndex = (CurrentIndex + 1) % 26;
            AlphabetOffset = (AlphabetOffset + 1)%26;
        }

        public void WithdrawAlphabet()
        {
            if (--CurrentIndex < 0) CurrentIndex += 26;
            if (--AlphabetOffset < 0) AlphabetOffset += 26;
        }

        public int GetLeftIndex(int rightIndex)
        {
            return Contacts.First(contact => contact.RightIndex == rightIndex).LeftIndex;
        }

        public int GetRightIndex(int leftIndex)
        {
            return Contacts.First(contact => contact.LeftIndex == leftIndex).RightIndex;
        }

        public void MarkContact(Contact contactParam)
        {
            markedContacts.Add(contactParam);
        }

        public void ResetContactMarkings()
        {
            foreach (var markedContact in markedContacts)
            {
                markedContact.State = ContactState.NORMAL;
            }

            markedContacts.Clear();
        }
    }
}
