using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;
using CForm_Planner.AccountSystem;
using CForm_Planner.AgendaSystem;

namespace CForm_Planner.GameSystem
{
    public partial class GameProposalForm : Form
    {
        public Account User { get; private set; }
        public Administration Administration { get; private set; }
        public CalendarEventAdministration CalendarEventAdministration { get; private set; }

        public GameProposalForm(Administration administration, CalendarEventAdministration calendarEventAdministration)
        {
            InitializeComponent();
            User = administration.User;
            Administration = administration;
            CalendarEventAdministration = calendarEventAdministration;
            
        }

        private void GameProposalForm_Load(object sender, EventArgs e)
        {
            Administration.GetFriends(Administration.User.EmailAdress);

            SelectionMode selectionMode = Friend_checkedListBox.SelectionMode;
            Friend_checkedListBox.SelectionMode = SelectionMode.None;
            Friend_checkedListBox.DataSource = Administration.User.FriendsList;
            Friend_checkedListBox.DisplayMember = "Display";
            Friend_checkedListBox.SelectionMode = selectionMode;

            game_comboBox.Items.Clear();
            List<string> games = CalendarEventAdministration.GetGames();
            foreach (string game in games)
            {
                game_comboBox.Items.Add(game);
            }
           
        }

        private void proposal_button_Click(object sender, EventArgs e)
        {
            string players = User.EmailAdress;
            foreach (Account friend in Friend_checkedListBox.CheckedItems)
            {
                players += ", " + friend.EmailAdress;
            }

            if (Start_numericUpDown.Value >= End_numericUpDown.Value)
            {
                MessageBox.Show("End needs to be later then start");
            }
            else if (days_numericUpDown.Value < 1)
            {

            }
            else if (game_comboBox.Text == null)
            {

            }
            else if (raid_comboBox.Text == null)
            {

            }
            else
            {
                try
                {
                    proposal_listBox.Items.Clear();
                    List<Proposal> proposals = CalendarEventAdministration.GameProposal(players, game_comboBox.Text,
                        raid_comboBox.Text, Convert.ToInt32(days_numericUpDown.Value),
                        Convert.ToInt32(Start_numericUpDown.Value), Convert.ToInt32(End_numericUpDown.Value));
                    foreach (Proposal proposal in proposals)
                    {
                        proposal_listBox.Items.Add("Lastendtime: " + proposal.LastEndTime + " Nexstarttime: " +
                                                   proposal.NextStarTime + " timewindow: " + proposal.TimeWindow);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void game_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            raid_comboBox.Items.Clear();
            List<string> raids = CalendarEventAdministration.GetRaids(game_comboBox.SelectedItem.ToString());
            foreach (string raid in raids)
            {
                raid_comboBox.Items.Add(raid);
            }
        }

        private void GameProposalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
