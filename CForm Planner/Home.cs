﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CForm_Planner.AccountSystem.AccountForms;
using CForm_Planner.AgendaSystem.AgendaForms;
using CForm_Planner.AlarmSystem.AlarmForms;
using CForm_Planner.NoteSystem;
using CForm_Planner.TaskSystem;

namespace CForm_Planner
{
    public partial class Home : Form
    {
        TaskAdministration a = new TaskAdministration();
        public Home()
        {
            InitializeComponent();
        }

        private void Account_button_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.Visible = true;
            }   
        }

        private void Note_button_Click(object sender, EventArgs e)
        {
            NoteForm form = new NoteForm();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.Visible = true;
            }   
        }

        private void Agenda_button_Click(object sender, EventArgs e)
        {
            AgendaForm form = new AgendaForm();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.Visible = true;
            }   
        }

        private void Alarm_button_Click(object sender, EventArgs e)
        {
            AlarmForm form = new AlarmForm();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.Visible = true;
            }   
        }

        private void ToDo_button_Click(object sender, EventArgs e)
        {
            CForm_Planner.TaskSystem.TaskForms.TaskForm form = new CForm_Planner.TaskSystem.TaskForms.TaskForm();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.Visible = true;
            }            
        }

        /* try
            {
                CForm_Planner.TaskSystem.Task b = new TaskSystem.Task("", "", "");
            }
            catch(ArgumentNullException ex){
                MessageBox.Show(ex.Message);
            }*/
    }
}
