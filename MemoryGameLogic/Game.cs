using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryGameLogic
{
    public class Game
    {
        public Spot[,] Board;
        public Card[] Collected;
        private Spot _activeFlip;
        private int[] _activeFlipSpot;

        public void StartNewGame(int size)
        {
            Board = CreateBoard(size);
        }

        public Spot[,] CreateBoard(int size)
        {
            if (size > 6)
            {
                Console.WriteLine($"Size limit is 10, set size to 10");
                size = 6;
            }

            if (size % 2 != 0)
            {
                throw new Exception("Please provide number that can be divide by 2");
            }

            var deck = ShuffleDeck(size);
            Collected = new Card[deck.Length];
            Spot[,] board = new Spot[size, size];
            var c = 0;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++, c++)
                {
                    board[i, j] = new Spot(deck[c]);
                }
            }

            return board;
        }

        private Card[] ShuffleDeck(int size)
        {
            if (size > 6)
                size = 6;

            var deckSize = (int) Math.Pow(size, 2);
            var rnd = new Random();
            return CreateUniqueCards(deckSize).OrderBy(x => rnd.Next()).ToArray();
        }

        private Card[] CreateUniqueCards(int size)
        {
            string[] imgDm =
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U"
            };
            var cards = new Card[size];
            var counter = 0;
            for (var i = 0; i < size; i += 2)
            {
                // here place unique image from list of images
                var card = new Card(imgDm[counter]);
                cards[i] = card;
                cards[i + 1] = card;
                counter++;
            }

            return cards;
        }

        public void FlipCard(int i, int j)
        {
            try
            {
                if (Board[i, j].Collected)
                {
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Index is out of board!");
                return;
            }

            if (Board[i, j].Collected)
            {
                Console.WriteLine("Please select hidden card!");
                return;
            }

            if (_activeFlip is null)
            {
                Console.WriteLine($"Flipping {i},{j} {Board[i, j].card.Id}");
                Board[i, j].Visible = true;
                _activeFlip = Board[i, j];
                _activeFlipSpot = new[] {i, j};
                return;
            }

            if (_activeFlipSpot[0] == i && _activeFlipSpot[1] == j)
            {
                Console.WriteLine("Dont be a smart ass!");
            }
            else if (_activeFlip.card.Id == Board[i, j].card.Id)
            {
                Collected[^1] = _activeFlip.card;
                RemoveCard(new[] {i, j}, _activeFlipSpot);
                Console.WriteLine($"Yeah, card {_activeFlip.card.Id} collected!");
            }
            else
            {
                Console.WriteLine("Wrong!");
                Board[i, j].Visible = true;

                var task = Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Board[i, j].Visible = false;
                    _activeFlip.Visible = false;
                    _activeFlip = null;
                    _activeFlipSpot = null;
                });
            }
        }

        private void RemoveCard(int[] spot1, int[] spot2)
        {
            Board[spot1[0], spot1[1]].Collected = true;
            Board[spot2[0], spot2[1]].Collected = true;
        }
    }
}