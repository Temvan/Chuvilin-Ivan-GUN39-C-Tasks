using System;
using System.Collections.Generic;
using FinalTask.Casino.CasinoGames;

namespace FinalTask.Casino.CasinoGames.Blackjack
{
    public class BlackjackGame : CasinoGameBase
    {
        private readonly int _cardCount;
        private Deck _deck;
        private readonly List<Card> _playerHand = new();
        private readonly List<Card> _dealerHand = new();

        public BlackjackGame(int cardCount)
        {
            if (cardCount < 4)
                throw new ArgumentOutOfRangeException(nameof(cardCount), "Minimum 4 cards for the game");

            _cardCount = cardCount;
        }

        protected override void FactoryMethod()
        {
            _deck = new Deck(_cardCount);
            _playerHand.Clear();
            _dealerHand.Clear();
        }

        public override void StartGame()
        {
            FactoryMethod();
            _playerHand.Add(_deck.DrawCard());
            _playerHand.Add(_deck.DrawCard());
            _dealerHand.Add(_deck.DrawCard());
            _dealerHand.Add(_deck.DrawCard());

            ResolveRound();
        }

        private void ResolveRound()
        {
            int playerScore = CalculateScore(_playerHand);
            int dealerScore = CalculateScore(_dealerHand);

            Console.WriteLine($"Player: {string.Join(", ", _playerHand)} (Score: {playerScore})");
            Console.WriteLine($"Dealer: {string.Join(", ", _dealerHand)} (Score: {dealerScore})");

            if (playerScore > 21 && dealerScore > 21) 
                {
                 OnDrawInvoke(); 
                 return;
                }
            if (playerScore > 21) 
                {
                 OnLoseInvoke(); 
                 return; 
                }
            if (dealerScore > 21) 
                {
                OnWinInvoke(); 
                return; 
                }

            while (playerScore == dealerScore)
            {
                if (_deck.Count < 2) { OnDrawInvoke(); return; }

                _playerHand.Add(_deck.DrawCard());
                _dealerHand.Add(_deck.DrawCard());

                playerScore = CalculateScore(_playerHand);
                dealerScore = CalculateScore(_dealerHand);

                Console.WriteLine($"Draw cards: Player={playerScore}, Dealer={dealerScore}");

                if (playerScore == dealerScore && playerScore < 21) continue;
                if (playerScore <= 21 && (dealerScore > 21 || playerScore > dealerScore)) 
                    { 
                    OnWinInvoke(); 
                    return; 
                    }
                if (dealerScore <= 21 && (playerScore > 21 || dealerScore > playerScore)) 
                    { 
                    OnLoseInvoke(); 
                    return; 
                    }
                if (playerScore >= 21 && dealerScore >= 21) 
                    { OnDrawInvoke(); 
                    return; 
                    }           
            }

            if (playerScore > dealerScore)
                 OnWinInvoke();
            else OnLoseInvoke();
        }

        private int CalculateScore(List<Card> hand)
        {
            int score = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                score += (int)card.Rank;
                if (card.Rank == Rank.Ace) aceCount++;
            }

            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }
    }
}