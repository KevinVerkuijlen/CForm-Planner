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
            this.SuspendLayout();
            // 
            // Friend_listBox
            // 
            this.Friend_listBox.FormattingEnabled = true;
            this.Friend_listBox.ItemHeight = 25;
            this.Friend_listBox.Location = new System.Drawing.Point(13, 13);
            this.Friend_listBox.Name = "Friend_listBox";
            this.Friend_listBox.Size = new System.Drawing.Size(184, 404);
            this.Friend_listBox.TabIndex = 0;
            // 
            // SearchFriend_button
            // 
            this.SearchFriend_button.Location = new System.Drawing.Point(204, 78);
            this.SearchFriend_button.Name = "SearchFriend_button";
            this.SearchFriend_button.Size = new System.Drawing.Size(201, 51);
            this.SearchFriend_button.TabIndex = 1;
            this.SearchFriend_button.Text = "Search for friend";
            this.SearchFriend_button.UseVisualStyleBackColor = true;
            // 
            // AddFriend_button
            // 
            this.AddFriend_button.Location = new System.Drawing.Point(204, 182);
            this.AddFriend_button.Name = "AddFriend_button";
            this.AddFriend_button.Size = new System.Drawing.Size(201, 51);
            this.AddFriend_button.TabIndex = 2;
            this.AddFriend_button.Text = "Add friend";
            this.AddFriend_button.UseVisualStyleBackColor = true;
            // 
            // RemoveFriend_button
            // 
            this.RemoveFriend_button.Location = new System.Drawing.Point(204, 239);
            this.RemoveFriend_button.Name = "RemoveFriend_button";
            this.RemoveFriend_button.Size = new System.Drawing.Size(201, 51);
            this.RemoveFriend_button.TabIndex = 3;
            this.RemoveFriend_button.Text = "Remove friend";
            this.RemoveFriend_button.UseVisualStyleBackColor = true;
            // 
            // Friend_textBox
            // 
            this.Friend_textBox.Location = new System.Drawing.Point(204, 41);
            this.Friend_textBox.Name = "Friend_textBox";
            this.Friend_textBox.Size = new System.Drawing.Size(296, 31);
            this.Friend_textBox.TabIndex = 4;
            // 
            // FriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 439);
            this.Controls.Add(this.Friend_textBox);
            this.Controls.Add(this.RemoveFriend_button);
            this.Controls.Add(this.AddFriend_button);
            this.Controls.Add(this.SearchFriend_button);
            this.Controls.Add(this.Friend_listBox);
            this.Name = "FriendsForm";
            this.Text = "FriendsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Friend_listBox;
        private System.Windows.Forms.Button SearchFriend_button;
        private System.Windows.Forms.Button AddFriend_button;
        private System.Windows.Forms.Button RemoveFriend_button;
        private System.Windows.Forms.TextBox Friend_textBox;
    }
}