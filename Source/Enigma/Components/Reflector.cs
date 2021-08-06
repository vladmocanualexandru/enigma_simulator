using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enigma.Enumerations;
using Enigma.Logistics;
using Enigma.Interfaces;

namespace Enigma.Components
{
    class Reflector : IResetableMarkings
    {
        public List<Contact> Contacts { get; set; }

        public Contact MarkedContact { get; set; }

        public Reflector()
        {

            String contactWiring = ConfigurationHolder.GetInstance().Settings["reflector"];
            Contacts = new List<Contact>(13);

            for (int i = 0; i < 13; i++ )
            {

                int leftIndex = Convert.ToInt32(contactWiring.ToCharArray()[2 * i])-65;
                int rightIndex = Convert.ToInt32(contactWiring.ToCharArray()[2 * i + 1])-65;

                Contacts.Add(new Contact(leftIndex, rightIndex));
            }
            MarkedContact = Contacts[0];
        }

        #region IResetableMarkings Members

        public void MarkContact(Contact contact)
        {
            MarkedContact = contact;
        }

        public void ResetContactMarkings()
        {
            foreach (var contact in Contacts)
            {
                contact.State = ContactState.NORMAL;
            }

        }

        #endregion
    }
}
