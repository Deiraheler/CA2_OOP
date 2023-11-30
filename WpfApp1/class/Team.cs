using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1;
class Team
{
    public string Name { get; set; }
    public List<Player> Players { get; set; }

    public Team()
    {
        Players = new List<Player>();
    }
}
