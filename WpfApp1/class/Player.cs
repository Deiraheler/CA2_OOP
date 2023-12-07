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
            return $"{Name} - {ToString()} - {GetLastPoints()}"; 
        }
    }

    public Player(string name, string results)
    {
        Name = name;
        ResultRecord = results;

        SetPoints();
    }

    /// <summary>
    /// Setting points from all games
    /// </summary>
    public void SetPoints()
    {
        char[] resultArray = ResultRecord.ToCharArray();

        foreach (var item in resultArray)
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
    /// Getting points from 5 last games
    /// </summary>
    /// <returns>(int) Points from 5 last games</returns>
    public int GetLastPoints()
    {
        char[] lastPoints = ResultRecord.Skip(ResultRecord.Length - 5).ToArray();
        int points = 0;

        foreach (var item in lastPoints)
        {
            switch (item)
            {
                case 'W':
                    points += 3;
                    break;
                case 'D':
                    points += 1;
                    break;
            }
        }

        return points;
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
        char[] previousGames = ResultRecord.ToCharArray();
        previousGames = previousGames.Skip(1).ToArray();
        previousGames.Append(gameResult);
    }

    public override string ToString()
    {
        string lastGamesResults = ResultRecord.Skip(ResultRecord.Length - 5).ToString();

        return lastGamesResults;
    }
}

