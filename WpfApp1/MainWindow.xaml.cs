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

        public MainWindow()
        {
            InitializeComponent();

            InitTeams();

            teamsList.ItemsSource = Teams;
            teamsList.DisplayMemberPath = "Name";
        }

        private void InitTeams()
        {
            Teams.AddRange(new List<Team>{
                new Team() { Name = "France" },
                new Team() { Name = "Italy" },
                new Team() { Name = "Spain" },
            });

            //Adding players for France
            Teams[0].Players.AddRange(new List<Player>
            {
                new Player { Name = "Marie", ResultRecord = "WWDDL" },
                new Player { Name = "Claude", ResultRecord = "DDDLW" },
                new Player { Name = "Antoine", ResultRecord = "LWDLW" }
            });

            //Adding players for Italy
            Teams[1].Players.AddRange(new List<Player>
            {
                new Player() { Name = "Marco", ResultRecord = "WWDLL" },
                new Player() { Name = "Giovanni", ResultRecord = "LLLLD" },
                new Player() { Name = "Valentina", ResultRecord = "DLWWW" }
            });

            //Adding players for Spain
            Teams[2].Players.AddRange(new List<Player>
            {
                new Player() { Name = "Maria", ResultRecord = "WWWWW" },
                new Player() { Name = "Jose", ResultRecord = "LLLLL" },
                new Player() { Name = "Pablo", ResultRecord = "DDDDD" }
            });
        }

        private void teamsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            if (teamsList.SelectedIndex != -1)
            {
                Team selectedTeam = teamsList.SelectedItem as Team;

                if (selectedTeam != null)
                {
                    playersList.ItemsSource = selectedTeam.Players;
                }
            }
        }
    }
}