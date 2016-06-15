using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.GameSystem
{
    public class Proposal
    {
        public DateTime LastEndTime { get; private set; }
        public DateTime NextStarTime { get; private set; }
        public int TimeWindow { get; private set; }

        public Proposal(DateTime last, DateTime next, int time)
        {
            LastEndTime = last;
            NextStarTime = next;
            TimeWindow = time;
        }
    }
}
