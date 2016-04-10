using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.AlarmSystem.AlarmForms
{
    public partial class AlarmAddForm : Form
    {
        public AlarmAdministration alarmAdministration;
        public Account user;

        public AlarmAddForm()
        {
            InitializeComponent();
        }

        private void AddAlarm_button_Click(object sender, EventArgs e)
        {
            string userEmail = "";
            if (user != null)
            {
                userEmail = user.EmailAdress;
            }
            if (Hour_numericUpDown.Value == 24 && Min_numericUpDown.Value > 0)
            {
                MessageBox.Show("If you want to set a time after midnight please use 0 instead of 24");
            }
            else
            {
                DateTime alarmTime = new DateTime(1, 1, 1, Convert.ToInt32(Hour_numericUpDown.Value), Convert.ToInt32(Min_numericUpDown.Value), 0);
                try
                {
                    Alarm newAlarm = new Alarm(alarmTime, false, userEmail);
                    alarmAdministration.AddAlarm(newAlarm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void AlarmAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
