using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzukBot.Game.Static.Classes
{
    public class Talent
    {
        public string Name
        {
            get;
            private set;
        }

        public int CurrentRank
        {
            get;
            private set;
        }

        public int MaxRank
        {
            get;
            private set;
        }

        public int Tab
        {
            get;
            private set;
        }

        public int Index
        {
            get;
            private set;
        }

        public Talent(string name, int currentRank, int maxRank, int tab, int index)
        {
            this.Name = name;
            this.CurrentRank = currentRank;
            this.MaxRank = maxRank;
            this.Tab = tab;
            this.Index = index;
        }
    }
}
