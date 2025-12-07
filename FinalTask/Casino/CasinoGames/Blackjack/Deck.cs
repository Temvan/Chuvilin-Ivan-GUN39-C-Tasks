using System;
using System.Collections.Generic;

namespace FinalTask.Casino.CasinoGames.Blackjack
{
    public class Deck
    {
        private readonly Queue<Card> _cards = new();
        private readonly Random _random = new();

        public Deck(int cardCount)
        {
            if (cardCount < 4)
                throw new ArgumentOutOfRangeException($"Cards < 4", nameof(cardCount));

            var allCards = BuildDeck(cardCount);
            Shuffle(allCards);

            foreach (var card in allCards)
                _cards.Enqueue(card);
        }
        public Card DrawCard()
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Deck is empty");
            return _cards.Dequeue();
        }

        public int Count => _cards.Count;

        private List<Card> BuildDeck(int count)
        {
            var suits = (Suit[])Enum.GetValues(typeof(Suit));
            var ranks = (Rank[])Enum.GetValues(typeof(Rank));

            var pool = new List<Card>();
            foreach (var suit in suits)
                foreach (var rank in ranks)
                    pool.Add(new Card(suit, rank));

            while (pool.Count > count) pool.RemoveAt(_random.Next(pool.Count));
            while (pool.Count < count)
                pool.Add(new Card(suits[_random.Next(suits.Length)], ranks[_random.Next(ranks.Length)]));

            return pool;
        }

        private void Shuffle(List<Card> cards)
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }
    }
}