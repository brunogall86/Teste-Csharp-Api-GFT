using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Questao2.Model
{
    public class ConsolidateData
    {
        public string Team { get; private set; }
        private IList<int> Goals { get; set; }
        public ConsolidateData(string team)
        {
            Team = team;
            Goals = new List<int>();            
        }

        public void AddGoals(int totalGoals)
        {
             Goals.Add(totalGoals);    
        }

        public int TotalGoals()
        {
            return Goals.Sum();
        }

        
    }
}