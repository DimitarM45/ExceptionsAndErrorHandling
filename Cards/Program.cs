using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] validFaces =
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10",
                "J", "Q", "K", "A"
            };

            string[] cardsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<Card> cards = new List<Card>();

            foreach (string cardString in cardsInput)
            {
                string[] cardInfo = cardString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string face = cardInfo[0];
                string suit = cardInfo[1];

                Card card = null;

                try
                {
                    card = CreateCard(face, suit, validFaces);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);

                    continue;
                }

                cards.Add(card);
            }

            Console.WriteLine(string.Join(' ', cards));
        }

        static Card CreateCard(string face, string suit, string[] validFaces)
        {
            Card card = null;

            if (validFaces.Contains(face))
            {
                string suitSymbol = null;

                if (suit == "S")
                    suitSymbol = "\u2660";

                else if (suit == "H")
                    suitSymbol = "\u2665";

                else if (suit == "D")
                    suitSymbol = "\u2666";

                else if (suit == "C")
                    suitSymbol = "\u2663";

                else
                    throw new ArgumentException("Invalid card!");

                card = new Card(face, suitSymbol);
            }
            else
                throw new ArgumentException("Invalid card!");

            return card;
        }
    }

    class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; private set; }

        public string Suit { get; private set; }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}