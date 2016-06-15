namespace CForm_Planner.GameSystem
{
    partial class GameProposalForm
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
            this.Players_label = new System.Windows.Forms.Label();
            this.Game_label = new System.Windows.Forms.Label();
            this.Raid_label = new System.Windows.Forms.Label();
            this.Days_label = new System.Windows.Forms.Label();
            this.Start_label = new System.Windows.Forms.Label();
            this.End_label = new System.Windows.Forms.Label();
            this.Friend_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.game_comboBox = new System.Windows.Forms.ComboBox();
            this.raid_comboBox = new System.Windows.Forms.ComboBox();
            this.days_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Start_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TaskHour_label = new System.Windows.Forms.Label();
            this.End_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.proposal_button = new System.Windows.Forms.Button();
            this.proposal_listBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.days_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Start_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.End_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Players_label
            // 
            this.Players_label.AutoSize = true;
            this.Players_label.Location = new System.Drawing.Point(14, 14);
            this.Players_label.Name = "Players_label";
            this.Players_label.Size = new System.Drawing.Size(90, 25);
            this.Players_label.TabIndex = 0;
            this.Players_label.Text = "Players:";
            // 
            // Game_label
            // 
            this.Game_label.AutoSize = true;
            this.Game_label.Location = new System.Drawing.Point(13, 221);
            this.Game_label.Name = "Game_label";
            this.Game_label.Size = new System.Drawing.Size(75, 25);
            this.Game_label.TabIndex = 1;
            this.Game_label.Text = "Game:";
            // 
            // Raid_label
            // 
            this.Raid_label.AutoSize = true;
            this.Raid_label.Location = new System.Drawing.Point(14, 268);
            this.Raid_label.Name = "Raid_label";
            this.Raid_label.Size = new System.Drawing.Size(62, 25);
            this.Raid_label.TabIndex = 2;
            this.Raid_label.Text = "Raid:";
            // 
            // Days_label
            // 
            this.Days_label.AutoSize = true;
            this.Days_label.Location = new System.Drawing.Point(14, 304);
            this.Days_label.Name = "Days_label";
            this.Days_label.Size = new System.Drawing.Size(323, 25);
            this.Days_label.TabIndex = 3;
            this.Days_label.Text = "Look for how many days ahead: ";
            // 
            // Start_label
            // 
            this.Start_label.AutoSize = true;
            this.Start_label.Location = new System.Drawing.Point(14, 343);
            this.Start_label.Name = "Start_label";
            this.Start_label.Size = new System.Drawing.Size(107, 25);
            this.Start_label.TabIndex = 4;
            this.Start_label.Text = "Between: ";
            // 
            // End_label
            // 
            this.End_label.AutoSize = true;
            this.End_label.Location = new System.Drawing.Point(278, 341);
            this.End_label.Name = "End_label";
            this.End_label.Size = new System.Drawing.Size(62, 25);
            this.End_label.TabIndex = 5;
            this.End_label.Text = "And: ";
            // 
            // Friend_checkedListBox
            // 
            this.Friend_checkedListBox.FormattingEnabled = true;
            this.Friend_checkedListBox.Location = new System.Drawing.Point(19, 42);
            this.Friend_checkedListBox.Name = "Friend_checkedListBox";
            this.Friend_checkedListBox.Size = new System.Drawing.Size(831, 160);
            this.Friend_checkedListBox.TabIndex = 6;
            // 
            // game_comboBox
            // 
            this.game_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.game_comboBox.FormattingEnabled = true;
            this.game_comboBox.Location = new System.Drawing.Point(123, 221);
            this.game_comboBox.Name = "game_comboBox";
            this.game_comboBox.Size = new System.Drawing.Size(727, 33);
            this.game_comboBox.TabIndex = 7;
            this.game_comboBox.SelectedIndexChanged += new System.EventHandler(this.game_comboBox_SelectedIndexChanged);
            // 
            // raid_comboBox
            // 
            this.raid_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raid_comboBox.FormattingEnabled = true;
            this.raid_comboBox.Location = new System.Drawing.Point(123, 260);
            this.raid_comboBox.Name = "raid_comboBox";
            this.raid_comboBox.Size = new System.Drawing.Size(727, 33);
            this.raid_comboBox.TabIndex = 8;
            // 
            // days_numericUpDown
            // 
            this.days_numericUpDown.Location = new System.Drawing.Point(344, 300);
            this.days_numericUpDown.Name = "days_numericUpDown";
            this.days_numericUpDown.Size = new System.Drawing.Size(82, 31);
            this.days_numericUpDown.TabIndex = 9;
            // 
            // Start_numericUpDown
            // 
            this.Start_numericUpDown.Location = new System.Drawing.Point(202, 338);
            this.Start_numericUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Start_numericUpDown.Name = "Start_numericUpDown";
            this.Start_numericUpDown.Size = new System.Drawing.Size(70, 31);
            this.Start_numericUpDown.TabIndex = 11;
            // 
            // TaskHour_label
            // 
            this.TaskHour_label.AutoSize = true;
            this.TaskHour_label.Location = new System.Drawing.Point(131, 341);
            this.TaskHour_label.Name = "TaskHour_label";
            this.TaskHour_label.Size = new System.Drawing.Size(64, 25);
            this.TaskHour_label.TabIndex = 10;
            this.TaskHour_label.Text = "Hour:";
            // 
            // End_numericUpDown
            // 
            this.End_numericUpDown.Location = new System.Drawing.Point(406, 338);
            this.End_numericUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.End_numericUpDown.Name = "End_numericUpDown";
            this.End_numericUpDown.Size = new System.Drawing.Size(70, 31);
            this.End_numericUpDown.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hour:";
            // 
            // proposal_button
            // 
            this.proposal_button.Location = new System.Drawing.Point(27, 375);
            this.proposal_button.Name = "proposal_button";
            this.proposal_button.Size = new System.Drawing.Size(823, 54);
            this.proposal_button.TabIndex = 18;
            this.proposal_button.Text = "Get proposal";
            this.proposal_button.UseVisualStyleBackColor = true;
            this.proposal_button.Click += new System.EventHandler(this.proposal_button_Click);
            // 
            // proposal_listBox
            // 
            this.proposal_listBox.FormattingEnabled = true;
            this.proposal_listBox.ItemHeight = 25;
            this.proposal_listBox.Location = new System.Drawing.Point(26, 449);
            this.proposal_listBox.Name = "proposal_listBox";
            this.proposal_listBox.Size = new System.Drawing.Size(824, 179);
            this.proposal_listBox.TabIndex = 19;
            // 
            // GameProposalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 658);
            this.Controls.Add(this.proposal_listBox);
            this.Controls.Add(this.proposal_button);
            this.Controls.Add(this.End_numericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Start_numericUpDown);
            this.Controls.Add(this.TaskHour_label);
            this.Controls.Add(this.days_numericUpDown);
            this.Controls.Add(this.raid_comboBox);
            this.Controls.Add(this.game_comboBox);
            this.Controls.Add(this.Friend_checkedListBox);
            this.Controls.Add(this.End_label);
            this.Controls.Add(this.Start_label);
            this.Controls.Add(this.Days_label);
            this.Controls.Add(this.Raid_label);
            this.Controls.Add(this.Game_label);
            this.Controls.Add(this.Players_label);
            this.Name = "GameProposalForm";
            this.Text = "GameProposalForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameProposalForm_FormClosing);
            this.Load += new System.EventHandler(this.GameProposalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.days_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Start_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.End_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Players_label;
        private System.Windows.Forms.Label Game_label;
        private System.Windows.Forms.Label Raid_label;
        private System.Windows.Forms.Label Days_label;
        private System.Windows.Forms.Label Start_label;
        private System.Windows.Forms.Label End_label;
        private System.Windows.Forms.CheckedListBox Friend_checkedListBox;
        private System.Windows.Forms.ComboBox game_comboBox;
        private System.Windows.Forms.ComboBox raid_comboBox;
        private System.Windows.Forms.NumericUpDown days_numericUpDown;
        private System.Windows.Forms.NumericUpDown Start_numericUpDown;
        private System.Windows.Forms.Label TaskHour_label;
        private System.Windows.Forms.NumericUpDown End_numericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button proposal_button;
        private System.Windows.Forms.ListBox proposal_listBox;
    }
}