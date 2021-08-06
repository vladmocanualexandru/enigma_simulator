using System;
using System.Collections.Generic;
using Enigma.Enumerations;
using Enigma.Interfaces;

namespace Enigma.Components
{
    class InterRotorsConnection : IResetableMarkings
    {
        public Dictionary<String,List<Contact>> Contacts { get; set; }
        private List<Contact> markedContacts;

        public InterRotorsConnection(int numberOfRotors)
        {
            Contacts = new Dictionary<string, List<Contact>>(numberOfRotors);

            for (int i=0; i<=numberOfRotors; i++)
            {
                Contacts.Add("rotor_"+i,new List<Contact>(26));

                for (int j=0; j<26; j++)
                {
                    Contacts["rotor_"+i].Add(new Contact(j, j));
                }
            }

            markedContacts = new List<Contact>();
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
