﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1;
    internal class Player
    {
    public string Name { get; set; }
    public string ResultRecord { get; set; }

    public int GetPoints()
    {
        return ResultRecord;
    }

    public override string ToString()
    {
        return ResultRecord;
    }
}

