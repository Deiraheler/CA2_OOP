using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1;
class Team: IComparable<Team>
{
    public string Name { get; set; }
    public int Points { get; set; }
    public List<Player> Players { get; set; }

    public string FormattedInfo
    {
        get
        {
            return $"{Name} - {ToString()}";
        }
    }

    public Team()
    {
        Players = new List<Player>();
    }

    public int CompareTo(Team team)
    {
        if(this.Points < team.Points)
        {
            return 1;
        }else if(this.Points > team.Points)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Getting points from all players and writes to (int) Points/ Sorts players after
    /// </summary>
    public void SetPoints()
    {
        Points = 0;

        Players.ForEach(player =>
        {
            Points += player.GetPoints();
        });

        Players.Sort();
    }

    /// <summary>
    /// Getting range of players and adding them to List players
    /// </summary>
    public void AddPlayers(IEnumerable<Player> players)
    {
        Players.AddRange(players);
        SetPoints();
    }

    /// <summary>
    /// Returns (int Points) in (string) data type
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Points.ToString();
    }
}
