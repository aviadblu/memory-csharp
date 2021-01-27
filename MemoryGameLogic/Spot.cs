namespace MemoryGameLogic
{
    public class Spot
    {
        public bool Visible = false;
        public Card card;
        public bool Collected = false;

        public Spot(Card card)
        {
            this.card = card;
        }

        public Spot(bool empty)
        {
            card = new Card("!");
        }
    }
}