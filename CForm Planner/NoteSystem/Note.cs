using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.NoteSystem
{
    [Serializable]
    public class Note
    {
        public string Information { get; set; }
        public string Accountemail { get; set; }

        public Note(string information, string accountemail)
        {
            if (information == null)
            {
                throw new ArgumentNullException("information", "information is empty");
            }
            this.Information = information;
            this.Accountemail = accountemail;
        }

    }
}
