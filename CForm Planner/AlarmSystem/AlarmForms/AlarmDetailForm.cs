using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CForm_Planner.AlarmSystem.AlarmForms
{
    public partial class AlarmDetailForm : Form
    {
        public AlarmAdministration AlarmAdministration { get; }
        public Alarm Alarm { get; }

        public AlarmDetailForm(Alarm alarm, AlarmAdministration alarmAdministration)
        {
            Alarm = alarm;
            AlarmAdministration = alarmAdministration;
            InitializeComponent();
        }

        private void ChangeAlarm_button_Click(object sender, EventArgs e)
        {
            if (Hour_numericUpDown.Value == 24 && Min_numericUpDown.Value > 0)
            {
                MessageBox.Show("If you want to set a time after midnight please use 0 instead of 24");
            }
            else
            {
                DateTime alarmTime = new DateTime(1, 1, 1, Convert.ToInt32(Hour_numericUpDown.Value), Convert.ToInt32(Min_numericUpDown.Value), 0);
                bool set = false;
                if (On_radioButton.Checked == true)
                {
                    set = true;
                    Off_radioButton.Checked = false;
                }
                if (Off_radioButton.Checked == true)
                {
                    set = false;
                    On_radioButton.Checked = false;
                }
                try
                {
                    AlarmAdministration.ChangeAlarm(Alarm, alarmTime, set);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void RemoveAlarm_button_Click(object sender, EventArgs e)
        {
            try
            {
                AlarmAdministration.RemoveAlarm(Alarm);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Detail_Refresh()
        {
            if (Alarm != null)
            {
                Hour_numericUpDown.Value = Alarm.Alarmtime.Hour;
                Min_numericUpDown.Value = Alarm.Alarmtime.Minute;
                if (Alarm.AlarmSet == true)
                {
                    On_radioButton.Checked = true;
                    Off_radioButton.Checked = false;
                }
                else
                {
                    if (Alarm.AlarmSet == false)
                    {
                        On_radioButton.Checked = false;
                        Off_radioButton.Checked = true;
                    }
                }
            }
        }

        private void AlarmDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
