using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1;
    internal class Player: IComparable<Player>
    {
    public string Name { get; set; }
    public string ResultRecord { get; set; }
    public int Points { get; set; }

    /// <summary>
    /// Binding this to player ListBox
    /// </summary>
    public string FormattedInfo
    {
        get {
            return $"{Name} - {ToString()} - {Points}"; 
        }
    }

    public int CompareTo(Player player)
    {
        if(this.Points < player.Points)
        {
            return 1;
        }else if(this.Points > player.Points)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public Player(string name, string results)
    {
        Name = name;
        ResultRecord = results;

        SetPoints();
    }

    /// <summary>
    /// Getting points from 5 last games
    /// </summary>
    /// <returns>(int) Points from 5 last games</returns>
    public void SetPoints()
    {
        char[] lastPoints = ResultRecord.Skip(ResultRecord.Length - 5).ToArray();
        Points = 0;

        foreach (var item in lastPoints)
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

    /// <summary>
    /// Return player points
    /// </summary>
    /// <returns>(int) points</returns>
    public int GetPoints()
    {
        return Points;
    }

    /// <summary>
    /// Getting value for solid stars from points amount
    /// </summary>
    /// <returns>(int) (0 - 3) Stars amount</returns>
    public int GetStars()
    {
        if (Points == 0) return 0;

        return (int)Math.Ceiling((double)Points / 5);
    }

    /// <summary>
    /// Adding new game result to previous games
    /// </summary>
    /// <param name="gameResult">('W','D','L')</param>
    public void setGameResult(char gameResult)
    {
        ResultRecord = ResultRecord.Insert(ResultRecord.Length, gameResult.ToString());
        SetPoints();
    }

    /// <summary>
    /// Returns 5 last games
    /// </summary>
    /// <returns>(string) last 5 games</returns>
    public override string ToString()
    {
        string lastGamesResults = String.Concat(ResultRecord.Skip(ResultRecord.Length - 5));

        return lastGamesResults;
    }
}

