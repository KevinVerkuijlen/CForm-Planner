using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.TaskSystem
{
    public class Task
    {
        public string Titel { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
        public string Accountemail { get; set; }

        public Task(string titel, string notes, string accountEmail)
        {
            if (titel == null)
            {
                throw new ArgumentNullException("titel", "titel is empty");
            }
            if (notes == null)
            {
                throw new ArgumentNullException("notes", "notes is empty");
            }
            this.Titel = titel;
            this.Notes = notes;
            this.Completed = false;
            this.Accountemail = accountEmail;
        }
    }
}
