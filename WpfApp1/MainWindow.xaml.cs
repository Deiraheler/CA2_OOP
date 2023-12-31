﻿//Git repository: https://github.com/Deiraheler/CA2_OOP/tree/master
using System.Collections.ObjectModel;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List with all Teams
        List<Team> Teams = new List<Team>();
        Player? selectedPlayer;

        public MainWindow()
        {
            InitializeComponent();

            InitTeams();

            teamsList.ItemsSource = Teams;
        }

        /// <summary>
        /// Init function. Creating teams and adding players to them
        /// </summary>
        private void InitTeams()
        {
            Teams.Add(new Team() { Name = "France" });
            Teams.Add(new Team() { Name = "Italy" });
            Teams.Add(new Team() { Name = "Spain" });

            //Adding players for France
            Teams[0].AddPlayers(new List<Player>
            {
                new Player("Marie","WWDDL"),
                new Player("Claude","DDDLW"),
                new Player("Antoine","LWDLW")
            });

            //Adding players for Italy
            Teams[1].AddPlayers(new List<Player>
            {
                new Player("Marco","WWDLL"),
                new Player("Giovanni","LLLLD"),
                new Player("Valentina","DLWWW"),
            });

            //Adding players for Spain
            Teams[2].AddPlayers(new List<Player>
            {
                new Player("Maria","WWWWW"),
                new Player("Jose","LLLLL"),
                new Player("Pablo","DDDDD")
            });

            Teams.Sort();
        }

        private void teamsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clearCurrentPlayer();
            if (teamsList.SelectedIndex != -1)
            {
                Team selectedTeam = teamsList.SelectedItem as Team;

                if (selectedTeam != null)
                {
                    playersList.ItemsSource = selectedTeam.Players;
                }
            }
        }

        private void playersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clearCurrentPlayer();
            if (teamsList.SelectedIndex != -1)
            {
                selectedPlayer = playersList.SelectedItem as Player;

                if (selectedPlayer != null)
                {
                    setStars(selectedPlayer);
                }
            }
        }

        /// <summary>
        /// Changing stars state depending on player points
        /// </summary>
        /// <param name="player"></param>
        private void setStars(Player player)
        {
            clearStars();
            for (int i = 0; i < player.GetStars(); i++) {
                Image image = starsGrid.Children[i] as Image;
                image.Source = new BitmapImage(new Uri("pack://application:,,/images/starsolid.png", UriKind.Absolute));
            }
        } 

        /// <summary>
        /// Setting all stars to be star outline
        /// </summary>
        private void clearStars()
        {
            for (int i = 0; i < 3; i++)
            {
                Image image = starsGrid.Children[i] as Image;
                image.Source = new BitmapImage(new Uri("pack://application:,,/images/staroutline.png", UriKind.Absolute));
            }
        }

        /// <summary>
        /// Clears (Player SelectedPlayer) and clears stars
        /// </summary>
        private void clearCurrentPlayer()
        {
            selectedPlayer = null;
            clearStars();
        }

        /// <summary>
        /// Checking if player selected
        /// </summary>
        /// <returns>(Bool) true if player selected</returns>
        private bool checkPlayerSelect()
        {
            if (teamsList.SelectedIndex != -1)
            {
                selectedPlayer = playersList.SelectedItem as Player;

                if (selectedPlayer != null)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Updating Teams Points
        /// </summary>
        private void UpdatePoints()
        {
            Teams.ForEach(Team =>
            {
                Team.SetPoints();
            });

            Teams.Sort();
        }

        /// <summary>
        /// Event handler for buttons "WIN,LOSE,DRAW"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkPlayerSelect())
            {
                var button = sender as Button;
                string s = button.Content.ToString();

                if(s == "WIN")
                {
                    selectedPlayer.setGameResult('W');
                }else if (s == "DRAW")
                {
                    selectedPlayer.setGameResult('D');
                }
                else
                {
                    selectedPlayer.setGameResult('L');
                }

                UpdatePoints();
                RefreshLists();
                setStars(selectedPlayer);
            }
        }

        private void RefreshLists()
        {
            playersList.Items.Refresh();
            teamsList.Items.Refresh();
        }
    }
}