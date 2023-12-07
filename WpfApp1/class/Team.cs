using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1;
class Team
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

    private int GetTeamPoints()
    {
        Points = 0;

        Players.ForEach(player =>
        {
           Points += player.GetLastPoints();
        });

        return Points;
    }

    public override string ToString()
    {
        return GetTeamPoints().ToString();
    }
}
