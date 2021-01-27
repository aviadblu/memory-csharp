using System;

namespace MemoryGameLogic
{
    public class Card
    {
        private Guid _uniqeId;
        private string _img;
        public string Img => _img;

        public Guid Id => _uniqeId;

        public Card(string img)
        {
            _uniqeId = Guid.NewGuid();
            _img = img;
        }

        public Card(bool empty)
        {
            _uniqeId = Guid.Empty;
        }
    }
}