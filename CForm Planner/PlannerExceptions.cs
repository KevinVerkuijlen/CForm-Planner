using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner
{
    public class PlannerExceptions : Exception
    {
        public PlannerExceptions(string message)
            : base(message)
        {
        }
    }
}
