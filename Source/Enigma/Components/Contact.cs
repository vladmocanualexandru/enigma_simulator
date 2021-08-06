using Enigma.Enumerations;

namespace Enigma.Components
{
    public class Contact
    {
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }
        public ContactState State { get; set; }

        public Contact (int leftIndex, int rightIndex)
        {
            LeftIndex = leftIndex;
            RightIndex = rightIndex;
            State = ContactState.NORMAL;
        }

        public Contact Clone()
        {
            return new Contact(LeftIndex, RightIndex);
        }
    }
}
