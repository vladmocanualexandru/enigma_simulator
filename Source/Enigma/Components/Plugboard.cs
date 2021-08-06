using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enigma.Enumerations;
using Enigma.Logistics;
using Enigma.Interfaces;

namespace Enigma.Components
{
    public class Plugboard : IResetableMarkings
    {
        public List<Contact> Contacts { get; set; }
        private List<Contact> markedContacts;

        public Plugboard()
        {

            Contacts = new List<Contact>(26);

            for (int i = 0; i < 26; i++ )
            {
                Contacts.Add(new Contact(i,i));
            }

            markedContacts = new List<Contact>(2);
        }

        public bool AddPlug(int index1, int index2)
        {
            var selectedContact = Contacts.First(contact => contact.LeftIndex == index1 || contact.RightIndex == index2);
            if (selectedContact.LeftIndex != selectedContact.RightIndex)
            {
                return false;
            }

            Contacts[index1].RightIndex = index2;
            Contacts[index2].RightIndex = index1;


            return true;
        }

        public void ClearAllPlugs()
        {
            foreach (var contact in Contacts)
            {
                contact.RightIndex = contact.LeftIndex;
            }
        }


        public void MarkContact(Contact contact)
        {
            markedContacts.Add(contact);
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
