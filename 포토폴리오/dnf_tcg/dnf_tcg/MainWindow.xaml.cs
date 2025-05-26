using DnfTcg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dnf_tcg
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        GameManager game;

        public MainWindow()
        {
            InitializeComponent();

            var deck1 = DeckFactory.CreateStarterDeck();
            var deck2 = DeckFactory.CreateStarterDeck();

            var p1 = new Player { Name = "Player1", Deck = new List<Card>(deck1) };
            var p2 = new Player { Name = "Player2", Deck = new List<Card>(deck2) };

            game = new GameManager(p1, p2);
            game.StartTurn();

            RefreshUI();
        }

        void RefreshUI()
        {
            var cp = game.CurrentPlayer;

            StatusText.Text = $"{cp.Name} - HP: {cp.Health} | Lv: {cp.Level} | " +
                  $"큐브: {(cp.Level < 50 ? 0 : cp.CubeShards)} | 턴 {game.TurnNumber}";

            HandPanel.Children.Clear();
            for (int i = 0; i < cp.Hand.Count; i++)
            {
                var card = cp.Hand[i];
                var btn = new Button
                {
                    Content = $"{card.Name}\n(Lv{card.LevelRequirement})",
                    Margin = new Thickness(5),
                    Tag = i,
                    Width = 100,
                    Height = 60
                };
                btn.Click += CardButton_Click;
                HandPanel.Children.Add(btn);
            }
        }

        public void LevelUp_Click(object sender, RoutedEventArgs e)
        {
            game.LevelUpPlayer();
            RefreshUI();
        }

        public void EndTurn_Click(object sender, RoutedEventArgs e)
        {
            game.EndTurn();
            RefreshUI();
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)((Button)sender).Tag;
            var card = game.CurrentPlayer.Hand[index];
            game.PlayCard(card);
            RefreshUI();
        }

    }
}
