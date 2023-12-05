using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1;
    internal class Player
    {
    public string Name { get; set; }
    public string ResultRecord { get; set; }
    public int Points { get; set; }

    public string FormattedInfo
    {
        get {
            return $"{Name} - {ResultRecord} - {Points}"; 
        }
    }

    public Player(string name, string results)
    {
        Name = name;
        ResultRecord = results;

        SetPoints();
    }

    public void SetPoints()
    {
        char[] resultArray = ResultRecord.ToCharArray();
        char[] lastNItems = resultArray.Skip(resultArray.Length - 5).ToArray();

        foreach (var item in lastNItems)
        {
            switch (item)
            {
                case 'W':
                    Points += 3;
                    break;
                case 'D':
                    Points += 1;
                    break;
            }
        }
    }

    public int GetStars()
    {
        if (Points == 0) return 0;

        return (int)Math.Ceiling((double)Points / 5);
    }

    public override string ToString()
    {
        return Points.ToString();
    }
}

