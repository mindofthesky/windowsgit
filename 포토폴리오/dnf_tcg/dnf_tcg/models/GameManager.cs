using DnfTcg.Models; // Player, Card 정의 포함
using System.Collections.Generic;
using System;

namespace DnfTcg.Models
{
    public class GameManager
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player OpponentPlayer => CurrentPlayer == Player1 ? Player2 : Player1;
        public int TurnNumber { get; private set; } = 1;
        
        public GameManager(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;
            CurrentPlayer = Player1;
        }

        public void StartTurn()
        {
            Console.WriteLine($"\n=== TURN {TurnNumber} ===");
            Console.WriteLine($"{CurrentPlayer.Name}'s turn begins. Lv{CurrentPlayer.Level}, HP: {CurrentPlayer.Health}, Hand: {CurrentPlayer.Hand.Count}");
            CurrentPlayer.HasLeveledUpThisTurn = false;
            AdjustHand(CurrentPlayer);
        }

        public void EndTurn()
        {
            AdjustHand(CurrentPlayer);
            Console.WriteLine($"{CurrentPlayer.Name}'s turn ends.");
            TurnNumber++;
            CurrentPlayer = OpponentPlayer;
            StartTurn();
        }

        private void AdjustHand(Player player)
        {
            // Draw up to 5
            if (player.Hand.Count < 5)
            {
                int drawCount = 5 - player.Hand.Count;
                for (int i = 0; i < drawCount && player.Deck.Count > 0; i++)
                {
                    var drawn = player.Deck[0];
                    player.Deck.RemoveAt(0);
                    player.Hand.Add(drawn);
                    Console.WriteLine($"{player.Name} draws: {drawn.Name}");
                }
            }
            // Discard down to 5
            else if (player.Hand.Count > 5)
            {
                Console.WriteLine($"{player.Name}, discard down to 5 cards.");
                while (player.Hand.Count > 5)
                {
                    var toDiscard = player.Hand[0]; // Simplified: discard first
                    player.Hand.RemoveAt(0);
                    Console.WriteLine($"{player.Name} discards: {toDiscard.Name}");
                }
            }
        }

        public void PlayCard(Card card)
        {
            if (CurrentPlayer.Level < card.LevelRequirement)
            {
                Console.WriteLine($"Cannot use {card.Name}. Required Lv {card.LevelRequirement}.");
                return;
            }

            card.Play(CurrentPlayer, OpponentPlayer);
            CurrentPlayer.Hand.Remove(card);
        }

        public void LevelUpPlayer()
        {
            CurrentPlayer.LevelUp();
        }
    }
}