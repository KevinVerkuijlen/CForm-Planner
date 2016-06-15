namespace CForm_Planner.AccountSystem.AccountForms
{
    partial class FriendsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Friend_listBox = new System.Windows.Forms.ListBox();
            this.SearchFriend_button = new System.Windows.Forms.Button();
            this.AddFriend_button = new System.Windows.Forms.Button();
            this.RemoveFriend_button = new System.Windows.Forms.Button();
            this.Friend_textBox = new System.Windows.Forms.TextBox();
            this.pendingFriend_listBox = new System.Windows.Forms.ListBox();
            this.Accept_button = new System.Windows.Forms.Button();
            this.Result_listBox = new System.Windows.Forms.ListBox();
            this.Decline_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Friend_listBox
            // 
            this.Friend_listBox.FormattingEnabled = true;
            this.Friend_listBox.ItemHeight = 25;
            this.Friend_listBox.Location = new System.Drawing.Point(13, 13);
            this.Friend_listBox.Name = "Friend_listBox";
            this.Friend_listBox.Size = new System.Drawing.Size(184, 329);
            this.Friend_listBox.TabIndex = 0;
            // 
            // SearchFriend_button
            // 
            this.SearchFriend_button.Location = new System.Drawing.Point(288, 79);
            this.SearchFriend_button.Name = "SearchFriend_button";
            this.SearchFriend_button.Size = new System.Drawing.Size(201, 51);
            this.SearchFriend_button.TabIndex = 1;
            this.SearchFriend_button.Text = "Search for friend";
            this.SearchFriend_button.UseVisualStyleBackColor = true;
            this.SearchFriend_button.Click += new System.EventHandler(this.SearchFriend_button_Click);
            // 
            // AddFriend_button
            // 
            this.AddFriend_button.Location = new System.Drawing.Point(288, 297);
            this.AddFriend_button.Name = "AddFriend_button";
            this.AddFriend_button.Size = new System.Drawing.Size(201, 51);
            this.AddFriend_button.TabIndex = 2;
            this.AddFriend_button.Text = "Add friend";
            this.AddFriend_button.UseVisualStyleBackColor = true;
            this.AddFriend_button.Click += new System.EventHandler(this.AddFriend_button_Click);
            // 
            // RemoveFriend_button
            // 
            this.RemoveFriend_button.Location = new System.Drawing.Point(13, 365);
            this.RemoveFriend_button.Name = "RemoveFriend_button";
            this.RemoveFriend_button.Size = new System.Drawing.Size(184, 51);
            this.RemoveFriend_button.TabIndex = 3;
            this.RemoveFriend_button.Text = "Remove friend";
            this.RemoveFriend_button.UseVisualStyleBackColor = true;
            this.RemoveFriend_button.Click += new System.EventHandler(this.RemoveFriend_button_Click);
            // 
            // Friend_textBox
            // 
            this.Friend_textBox.Location = new System.Drawing.Point(288, 42);
            this.Friend_textBox.Name = "Friend_textBox";
            this.Friend_textBox.Size = new System.Drawing.Size(201, 31);
            this.Friend_textBox.TabIndex = 4;
            // 
            // pendingFriend_listBox
            // 
            this.pendingFriend_listBox.FormattingEnabled = true;
            this.pendingFriend_listBox.ItemHeight = 25;
            this.pendingFriend_listBox.Location = new System.Drawing.Point(580, 13);
            this.pendingFriend_listBox.Name = "pendingFriend_listBox";
            this.pendingFriend_listBox.Size = new System.Drawing.Size(184, 404);
            this.pendingFriend_listBox.TabIndex = 5;
            // 
            // Accept_button
            // 
            this.Accept_button.Location = new System.Drawing.Point(787, 13);
            this.Accept_button.Name = "Accept_button";
            this.Accept_button.Size = new System.Drawing.Size(203, 85);
            this.Accept_button.TabIndex = 6;
            this.Accept_button.Text = "Accept friend";
            this.Accept_button.UseVisualStyleBackColor = true;
            this.Accept_button.Click += new System.EventHandler(this.Accept_button_Click);
            // 
            // Result_listBox
            // 
            this.Result_listBox.FormattingEnabled = true;
            this.Result_listBox.ItemHeight = 25;
            this.Result_listBox.Location = new System.Drawing.Point(288, 137);
            this.Result_listBox.Name = "Result_listBox";
            this.Result_listBox.Size = new System.Drawing.Size(200, 154);
            this.Result_listBox.TabIndex = 7;
            // 
            // Decline_button
            // 
            this.Decline_button.Location = new System.Drawing.Point(787, 105);
            this.Decline_button.Name = "Decline_button";
            this.Decline_button.Size = new System.Drawing.Size(203, 102);
            this.Decline_button.TabIndex = 8;
            this.Decline_button.Text = "Decline Friend";
            this.Decline_button.UseVisualStyleBackColor = true;
            this.Decline_button.Click += new System.EventHandler(this.Decline_button_Click);
            // 
            // FriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 439);
            this.Controls.Add(this.Decline_button);
            this.Controls.Add(this.Result_listBox);
            this.Controls.Add(this.Accept_button);
            this.Controls.Add(this.pendingFriend_listBox);
            this.Controls.Add(this.Friend_textBox);
            this.Controls.Add(this.RemoveFriend_button);
            this.Controls.Add(this.AddFriend_button);
            this.Controls.Add(this.SearchFriend_button);
            this.Controls.Add(this.Friend_listBox);
            this.Name = "FriendsForm";
            this.Text = "FriendsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FriendsForm_FormClosing);
            this.Load += new System.EventHandler(this.FriendsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Friend_listBox;
        private System.Windows.Forms.Button SearchFriend_button;
        private System.Windows.Forms.Button AddFriend_button;
        private System.Windows.Forms.Button RemoveFriend_button;
        private System.Windows.Forms.TextBox Friend_textBox;
        private System.Windows.Forms.ListBox pendingFriend_listBox;
        private System.Windows.Forms.Button Accept_button;
        private System.Windows.Forms.ListBox Result_listBox;
        private System.Windows.Forms.Button Decline_button;
    }
}