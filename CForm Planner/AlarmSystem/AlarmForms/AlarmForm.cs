﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CForm_Planner.AlarmSystem;

namespace CForm_Planner.AlarmSystem.AlarmForms
{
    public partial class AlarmForm : Form
    {
        public AlarmAdministration alarmAdministration = new AlarmAdministration();
        private int on = 0;
        public AlarmForm()
        {
            InitializeComponent();    
        }

        private void AddAlarm_button_Click(object sender, EventArgs e)
        {
            AlarmAddForm form = new AlarmAddForm();
            form.alarmAdministration = this.alarmAdministration;
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.alarmAdministration = form.alarmAdministration;
                Alarm_Refresh();
                this.Visible = true;
            }
        }            
        
        private void Alarm_checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Alarm_checkedListBox.SelectedItem != null)
            {
                AlarmDetailForm form = new AlarmDetailForm();
                form.alarmAdministration = this.alarmAdministration;
                foreach (Alarm a in alarmAdministration.Alarm_list)
                {
                    if (a.Alarmtime.ToString("HH:mm") == Alarm_checkedListBox.SelectedItem.ToString())
                    {
                        this.Visible = false;
                        form.details = a;
                        form.Detail_Refresh();
                        var closing = form.ShowDialog();

                        if (closing == DialogResult.OK)
                        {
                            this.alarmAdministration = form.alarmAdministration;
                            Alarm_Refresh();
                            this.Visible = true;
                            return;
                        }
                    }
                }
            }
        }

        private void AlarmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Alarm_Refresh()
        {
            Alarm_checkedListBox.Items.Clear();
            foreach (Alarm a in alarmAdministration.Alarm_list)
            {
                if (a.AlarmSet == true)
                {
                    Alarm_checkedListBox.Items.Add(a.Alarmtime.ToString("HH:mm"),true);
                }
                else
                {
                    Alarm_checkedListBox.Items.Add(a.Alarmtime.ToString("HH:mm"), false);
                }
            }
        }

        private void Alarm_checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                foreach (Alarm a in alarmAdministration.Alarm_list)
                {
                    if (a.Alarmtime.ToString("HH:mm") == Alarm_checkedListBox.Items[e.Index].ToString())
                    {
                        if (a.AlarmSet == false)
                        {
                            try
                            {
                                Alarm changedAlarm = new Alarm(a.Alarmtime, true, "");
                                alarmAdministration.ChangeAlarm(a, changedAlarm);
                                Alarm_Refresh();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    foreach (Alarm a in alarmAdministration.Alarm_list)
                    {
                        if (a.Alarmtime.ToString("HH:mm") == Alarm_checkedListBox.Items[e.Index].ToString())
                        {
                            Alarm changedAlarm = new Alarm(a.Alarmtime, false, "");
                            try
                            {
                                alarmAdministration.ChangeAlarm(a, changedAlarm);
                                Alarm_Refresh();
                                return;
                            }
                            catch (PlannerExceptions ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void Alarm_timer_Tick(object sender, EventArgs e)
        {
            if (on == 1)
            {
                foreach (Alarm a in alarmAdministration.Alarm_list)
                {
                    if (a.AlarmSet == true && Convert.ToInt16(DateTime.Now.ToString("HH")) == a.Alarmtime.Hour && Convert.ToInt32(DateTime.Now.ToString("mm")) == a.Alarmtime.Minute)
                    {
                        on = 0;
                        if (MessageBox.Show("Snooze", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Alarm offAlarm = new Alarm(a.Alarmtime, false, a.AccountEmail);
                            alarmAdministration.ChangeAlarm(a, offAlarm);
                            Alarm_Refresh();
                            on = 1;
                            return;
                        }
                    }
                }
            }
        }

        private void AlarmForm_Load(object sender, EventArgs e)
        {
            Alarm_timer.Start();
            on = 1;
        }
    }
}
