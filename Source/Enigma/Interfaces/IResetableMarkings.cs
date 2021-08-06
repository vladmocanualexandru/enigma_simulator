using System.Collections.Generic;
using Enigma.Components;

namespace Enigma.Interfaces
{
    interface IResetableMarkings
    {
        void MarkContact(Contact contact);
        void ResetContactMarkings();
    }
}
