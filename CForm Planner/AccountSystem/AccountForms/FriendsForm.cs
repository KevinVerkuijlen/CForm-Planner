using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CForm_Planner.AccountSystem.AccountForms
{
    public partial class FriendsForm : Form
    {
        public Administration Administration { get; private set; }

        public FriendsForm(Administration administration)
        {
            Administration = administration;
            InitializeComponent();
        }

        private void FriendsForm_Load(object sender, EventArgs e)
        {
            Friend_Refresh();
        }

        private void FriendsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void SearchFriend_button_Click(object sender, EventArgs e)
        {
            if (Friend_textBox.Text != null)
            {
                try
                {
                    Result_listBox.DataBindings.Clear();
                    List<Account> result = Administration.SearchFriends(Friend_textBox.Text);
                    Result_listBox.DataSource = result;
                    Result_listBox.DisplayMember = "Display";
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill a name to search for");
            }
        }

        private void AddFriend_button_Click(object sender, EventArgs e)
        {
            if (Result_listBox.SelectedValue != null)
            {
                Account friend = (Account)Result_listBox.SelectedValue;
                try
                {
                    bool accept = Administration.AddFriend(Administration.User.EmailAdress, friend);
                    if (accept)
                    {
                        MessageBox.Show("Friend request has been send to " + friend.Name);
                        Friend_Refresh();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            if (pendingFriend_listBox.SelectedValue != null)
            {
                Account friend = (Account)pendingFriend_listBox.SelectedValue;
                try
                {
                    bool accept = Administration.AcceptFriend(Administration.User.EmailAdress, friend);
                    if (accept)
                    {
                        Friend_Refresh();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void Decline_button_Click(object sender, EventArgs e)
        {
            if (pendingFriend_listBox.SelectedValue != null)
            {
                Account friend = (Account)pendingFriend_listBox.SelectedValue;
                try
                {
                    Administration.DeclineFriend(Administration.User.EmailAdress, friend);
                    Friend_Refresh();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void RemoveFriend_button_Click(object sender, EventArgs e)
        {
            if (Friend_listBox.SelectedValue != null)
            {
                Account friend = (Account)Friend_listBox.SelectedValue;
                try
                {
                    Administration.RemoveFriend(Administration.User.EmailAdress, friend);
                    Friend_Refresh();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        public void Friend_Refresh()
        {
            Friend_listBox.DataBindings.Clear();
            pendingFriend_listBox.DataBindings.Clear();
            Result_listBox.DataBindings.Clear();
            try
            {
                Administration.GetFriends(Administration.User.EmailAdress);
                SelectionMode selectionMode = Friend_listBox.SelectionMode;
                Friend_listBox.SelectionMode = SelectionMode.None;
                Friend_listBox.DataSource = Administration.User.FriendsList;
                Friend_listBox.DisplayMember = "Display";
                Friend_listBox.SelectionMode = selectionMode;

                List<Account> pending = Administration.GetPendingFriends(Administration.User.EmailAdress);
                SelectionMode PselectionMode = pendingFriend_listBox.SelectionMode;
                pendingFriend_listBox.SelectionMode = SelectionMode.None;
                pendingFriend_listBox.DataSource = pending;
                pendingFriend_listBox.DisplayMember = "Display";
                pendingFriend_listBox.SelectionMode = PselectionMode;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
