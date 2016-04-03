namespace CForm_Planner.AgendaSystem.AgendaForms
{
    partial class AgendaAddForm
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
            this.Start_TimePicker = new System.Windows.Forms.DateTimePicker();
            this.TypeOfAppiontmentgroupBox = new System.Windows.Forms.GroupBox();
            this.Game_radioButton = new System.Windows.Forms.RadioButton();
            this.School_radioButton = new System.Windows.Forms.RadioButton();
            this.Normal_radioButton = new System.Windows.Forms.RadioButton();
            this.Start_datePicker = new System.Windows.Forms.DateTimePicker();
            this.End_datePicker = new System.Windows.Forms.DateTimePicker();
            this.End_TimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDate_label = new System.Windows.Forms.Label();
            this.EndDate_label = new System.Windows.Forms.Label();
            this.StartTime_label = new System.Windows.Forms.Label();
            this.EndTime_label = new System.Windows.Forms.Label();
            this.Titel_label = new System.Windows.Forms.Label();
            this.Titel_textBox = new System.Windows.Forms.TextBox();
            this.Note_textBox = new System.Windows.Forms.TextBox();
            this.Note_label = new System.Windows.Forms.Label();
            this.Game_label = new System.Windows.Forms.Label();
            this.Game_textBox = new System.Windows.Forms.TextBox();
            this.Subject_label = new System.Windows.Forms.Label();
            this.Subject_textBox = new System.Windows.Forms.TextBox();
            this.Assignment_label = new System.Windows.Forms.Label();
            this.Assignment_textBox = new System.Windows.Forms.TextBox();
            this.Add_button = new System.Windows.Forms.Button();
            this.TypeOfAppiontmentgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_TimePicker
            // 
            this.Start_TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.Start_TimePicker.Location = new System.Drawing.Point(548, 207);
            this.Start_TimePicker.Name = "Start_TimePicker";
            this.Start_TimePicker.ShowUpDown = true;
            this.Start_TimePicker.Size = new System.Drawing.Size(148, 31);
            this.Start_TimePicker.TabIndex = 0;
            // 
            // TypeOfAppiontmentgroupBox
            // 
            this.TypeOfAppiontmentgroupBox.Controls.Add(this.Game_radioButton);
            this.TypeOfAppiontmentgroupBox.Controls.Add(this.School_radioButton);
            this.TypeOfAppiontmentgroupBox.Controls.Add(this.Normal_radioButton);
            this.TypeOfAppiontmentgroupBox.Location = new System.Drawing.Point(12, 12);
            this.TypeOfAppiontmentgroupBox.Name = "TypeOfAppiontmentgroupBox";
            this.TypeOfAppiontmentgroupBox.Size = new System.Drawing.Size(684, 86);
            this.TypeOfAppiontmentgroupBox.TabIndex = 1;
            this.TypeOfAppiontmentgroupBox.TabStop = false;
            this.TypeOfAppiontmentgroupBox.Text = "Type of appiontment";
            // 
            // Game_radioButton
            // 
            this.Game_radioButton.AutoSize = true;
            this.Game_radioButton.Location = new System.Drawing.Point(516, 47);
            this.Game_radioButton.Name = "Game_radioButton";
            this.Game_radioButton.Size = new System.Drawing.Size(100, 29);
            this.Game_radioButton.TabIndex = 2;
            this.Game_radioButton.TabStop = true;
            this.Game_radioButton.Text = "Game";
            this.Game_radioButton.UseVisualStyleBackColor = true;
            this.Game_radioButton.CheckedChanged += new System.EventHandler(this.Game_radioButton_CheckedChanged);
            // 
            // School_radioButton
            // 
            this.School_radioButton.AutoSize = true;
            this.School_radioButton.Location = new System.Drawing.Point(267, 47);
            this.School_radioButton.Name = "School_radioButton";
            this.School_radioButton.Size = new System.Drawing.Size(109, 29);
            this.School_radioButton.TabIndex = 1;
            this.School_radioButton.TabStop = true;
            this.School_radioButton.Text = "School";
            this.School_radioButton.UseVisualStyleBackColor = true;
            this.School_radioButton.CheckedChanged += new System.EventHandler(this.School_radioButton_CheckedChanged);
            // 
            // Normal_radioButton
            // 
            this.Normal_radioButton.AutoSize = true;
            this.Normal_radioButton.Location = new System.Drawing.Point(7, 47);
            this.Normal_radioButton.Name = "Normal_radioButton";
            this.Normal_radioButton.Size = new System.Drawing.Size(111, 29);
            this.Normal_radioButton.TabIndex = 0;
            this.Normal_radioButton.TabStop = true;
            this.Normal_radioButton.Text = "Normal";
            this.Normal_radioButton.UseVisualStyleBackColor = true;
            this.Normal_radioButton.CheckedChanged += new System.EventHandler(this.Normal_radioButton_CheckedChanged);
            // 
            // Start_datePicker
            // 
            this.Start_datePicker.Location = new System.Drawing.Point(138, 205);
            this.Start_datePicker.Name = "Start_datePicker";
            this.Start_datePicker.Size = new System.Drawing.Size(268, 31);
            this.Start_datePicker.TabIndex = 2;
            // 
            // End_datePicker
            // 
            this.End_datePicker.Location = new System.Drawing.Point(138, 244);
            this.End_datePicker.Name = "End_datePicker";
            this.End_datePicker.Size = new System.Drawing.Size(268, 31);
            this.End_datePicker.TabIndex = 3;
            // 
            // End_TimePicker
            // 
            this.End_TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.End_TimePicker.Location = new System.Drawing.Point(548, 242);
            this.End_TimePicker.Name = "End_TimePicker";
            this.End_TimePicker.ShowUpDown = true;
            this.End_TimePicker.Size = new System.Drawing.Size(148, 31);
            this.End_TimePicker.TabIndex = 4;
            // 
            // StartDate_label
            // 
            this.StartDate_label.AutoSize = true;
            this.StartDate_label.Location = new System.Drawing.Point(14, 212);
            this.StartDate_label.Name = "StartDate_label";
            this.StartDate_label.Size = new System.Drawing.Size(114, 25);
            this.StartDate_label.TabIndex = 5;
            this.StartDate_label.Text = "Start Date:";
            // 
            // EndDate_label
            // 
            this.EndDate_label.AutoSize = true;
            this.EndDate_label.Location = new System.Drawing.Point(14, 250);
            this.EndDate_label.Name = "EndDate_label";
            this.EndDate_label.Size = new System.Drawing.Size(107, 25);
            this.EndDate_label.TabIndex = 6;
            this.EndDate_label.Text = "End Date:";
            // 
            // StartTime_label
            // 
            this.StartTime_label.AutoSize = true;
            this.StartTime_label.Location = new System.Drawing.Point(426, 208);
            this.StartTime_label.Name = "StartTime_label";
            this.StartTime_label.Size = new System.Drawing.Size(116, 25);
            this.StartTime_label.TabIndex = 7;
            this.StartTime_label.Text = "Start Time:";
            // 
            // EndTime_label
            // 
            this.EndTime_label.AutoSize = true;
            this.EndTime_label.Location = new System.Drawing.Point(426, 247);
            this.EndTime_label.Name = "EndTime_label";
            this.EndTime_label.Size = new System.Drawing.Size(109, 25);
            this.EndTime_label.TabIndex = 8;
            this.EndTime_label.Text = "End Time:";
            // 
            // Titel_label
            // 
            this.Titel_label.AutoSize = true;
            this.Titel_label.Location = new System.Drawing.Point(14, 122);
            this.Titel_label.Name = "Titel_label";
            this.Titel_label.Size = new System.Drawing.Size(59, 25);
            this.Titel_label.TabIndex = 9;
            this.Titel_label.Text = "Titel:";
            // 
            // Titel_textBox
            // 
            this.Titel_textBox.Location = new System.Drawing.Point(80, 122);
            this.Titel_textBox.Name = "Titel_textBox";
            this.Titel_textBox.Size = new System.Drawing.Size(222, 31);
            this.Titel_textBox.TabIndex = 10;
            // 
            // Note_textBox
            // 
            this.Note_textBox.Location = new System.Drawing.Point(19, 346);
            this.Note_textBox.Multiline = true;
            this.Note_textBox.Name = "Note_textBox";
            this.Note_textBox.Size = new System.Drawing.Size(677, 254);
            this.Note_textBox.TabIndex = 11;
            // 
            // Note_label
            // 
            this.Note_label.AutoSize = true;
            this.Note_label.Location = new System.Drawing.Point(14, 304);
            this.Note_label.Name = "Note_label";
            this.Note_label.Size = new System.Drawing.Size(74, 25);
            this.Note_label.TabIndex = 12;
            this.Note_label.Text = "Notes:";
            // 
            // Game_label
            // 
            this.Game_label.AutoSize = true;
            this.Game_label.Location = new System.Drawing.Point(14, 170);
            this.Game_label.Name = "Game_label";
            this.Game_label.Size = new System.Drawing.Size(75, 25);
            this.Game_label.TabIndex = 13;
            this.Game_label.Text = "Game:";
            // 
            // Game_textBox
            // 
            this.Game_textBox.Location = new System.Drawing.Point(95, 165);
            this.Game_textBox.Name = "Game_textBox";
            this.Game_textBox.Size = new System.Drawing.Size(293, 31);
            this.Game_textBox.TabIndex = 14;
            // 
            // Subject_label
            // 
            this.Subject_label.AutoSize = true;
            this.Subject_label.Location = new System.Drawing.Point(14, 168);
            this.Subject_label.Name = "Subject_label";
            this.Subject_label.Size = new System.Drawing.Size(90, 25);
            this.Subject_label.TabIndex = 15;
            this.Subject_label.Text = "Subject:";
            // 
            // Subject_textBox
            // 
            this.Subject_textBox.Location = new System.Drawing.Point(116, 168);
            this.Subject_textBox.Name = "Subject_textBox";
            this.Subject_textBox.Size = new System.Drawing.Size(186, 31);
            this.Subject_textBox.TabIndex = 16;
            // 
            // Assignment_label
            // 
            this.Assignment_label.AutoSize = true;
            this.Assignment_label.Location = new System.Drawing.Point(322, 168);
            this.Assignment_label.Name = "Assignment_label";
            this.Assignment_label.Size = new System.Drawing.Size(130, 25);
            this.Assignment_label.TabIndex = 17;
            this.Assignment_label.Text = "Assignment:";
            // 
            // Assignment_textBox
            // 
            this.Assignment_textBox.Location = new System.Drawing.Point(459, 168);
            this.Assignment_textBox.Name = "Assignment_textBox";
            this.Assignment_textBox.Size = new System.Drawing.Size(237, 31);
            this.Assignment_textBox.TabIndex = 18;
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(19, 607);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(677, 60);
            this.Add_button.TabIndex = 19;
            this.Add_button.Text = "Add appointment to your agenda";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // AgendaAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 679);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.Assignment_textBox);
            this.Controls.Add(this.Assignment_label);
            this.Controls.Add(this.Subject_textBox);
            this.Controls.Add(this.Subject_label);
            this.Controls.Add(this.Game_textBox);
            this.Controls.Add(this.Game_label);
            this.Controls.Add(this.Note_label);
            this.Controls.Add(this.Note_textBox);
            this.Controls.Add(this.Titel_textBox);
            this.Controls.Add(this.Titel_label);
            this.Controls.Add(this.EndTime_label);
            this.Controls.Add(this.StartTime_label);
            this.Controls.Add(this.EndDate_label);
            this.Controls.Add(this.StartDate_label);
            this.Controls.Add(this.End_TimePicker);
            this.Controls.Add(this.End_datePicker);
            this.Controls.Add(this.Start_datePicker);
            this.Controls.Add(this.TypeOfAppiontmentgroupBox);
            this.Controls.Add(this.Start_TimePicker);
            this.Name = "AgendaAddForm";
            this.Text = "AgendaAddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgendaAddForm_FormClosing);
            this.TypeOfAppiontmentgroupBox.ResumeLayout(false);
            this.TypeOfAppiontmentgroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Start_TimePicker;
        private System.Windows.Forms.GroupBox TypeOfAppiontmentgroupBox;
        private System.Windows.Forms.RadioButton Game_radioButton;
        private System.Windows.Forms.RadioButton School_radioButton;
        private System.Windows.Forms.RadioButton Normal_radioButton;
        private System.Windows.Forms.DateTimePicker Start_datePicker;
        private System.Windows.Forms.DateTimePicker End_datePicker;
        private System.Windows.Forms.DateTimePicker End_TimePicker;
        private System.Windows.Forms.Label StartDate_label;
        private System.Windows.Forms.Label EndDate_label;
        private System.Windows.Forms.Label StartTime_label;
        private System.Windows.Forms.Label EndTime_label;
        private System.Windows.Forms.Label Titel_label;
        private System.Windows.Forms.TextBox Titel_textBox;
        private System.Windows.Forms.TextBox Note_textBox;
        private System.Windows.Forms.Label Note_label;
        private System.Windows.Forms.Label Game_label;
        private System.Windows.Forms.TextBox Game_textBox;
        private System.Windows.Forms.Label Subject_label;
        private System.Windows.Forms.TextBox Subject_textBox;
        private System.Windows.Forms.Label Assignment_label;
        private System.Windows.Forms.TextBox Assignment_textBox;
        private System.Windows.Forms.Button Add_button;
    }
}