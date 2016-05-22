namespace CForm_Planner
{
    partial class TaskDetailForm
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
            this.ChangeTask_button = new System.Windows.Forms.Button();
            this.RemoveTask_button = new System.Windows.Forms.Button();
            this.TaskNotes_textBox = new System.Windows.Forms.TextBox();
            this.TaskTitel_textBox = new System.Windows.Forms.TextBox();
            this.TaskNotes_label = new System.Windows.Forms.Label();
            this.TaskTitel_label = new System.Windows.Forms.Label();
            this.Completed_label = new System.Windows.Forms.Label();
            this.Completed_radioButton = new System.Windows.Forms.RadioButton();
            this.TaskToAppointment_button = new System.Windows.Forms.Button();
            this.Min_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TaskMin_label = new System.Windows.Forms.Label();
            this.Hour_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TaskHour_label = new System.Windows.Forms.Label();
            this.TaskED_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Min_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hour_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeTask_button
            // 
            this.ChangeTask_button.Location = new System.Drawing.Point(238, 12);
            this.ChangeTask_button.Name = "ChangeTask_button";
            this.ChangeTask_button.Size = new System.Drawing.Size(192, 36);
            this.ChangeTask_button.TabIndex = 0;
            this.ChangeTask_button.Text = "Change Task";
            this.ChangeTask_button.UseVisualStyleBackColor = true;
            this.ChangeTask_button.Click += new System.EventHandler(this.ChangeTask_button_Click);
            // 
            // RemoveTask_button
            // 
            this.RemoveTask_button.Location = new System.Drawing.Point(12, 12);
            this.RemoveTask_button.Name = "RemoveTask_button";
            this.RemoveTask_button.Size = new System.Drawing.Size(192, 36);
            this.RemoveTask_button.TabIndex = 1;
            this.RemoveTask_button.Text = "Remove Task";
            this.RemoveTask_button.UseVisualStyleBackColor = true;
            this.RemoveTask_button.Click += new System.EventHandler(this.RemoveTask_button_Click);
            // 
            // TaskNotes_textBox
            // 
            this.TaskNotes_textBox.Location = new System.Drawing.Point(12, 309);
            this.TaskNotes_textBox.Multiline = true;
            this.TaskNotes_textBox.Name = "TaskNotes_textBox";
            this.TaskNotes_textBox.Size = new System.Drawing.Size(414, 262);
            this.TaskNotes_textBox.TabIndex = 7;
            // 
            // TaskTitel_textBox
            // 
            this.TaskTitel_textBox.Location = new System.Drawing.Point(12, 100);
            this.TaskTitel_textBox.Name = "TaskTitel_textBox";
            this.TaskTitel_textBox.Size = new System.Drawing.Size(414, 31);
            this.TaskTitel_textBox.TabIndex = 6;
            // 
            // TaskNotes_label
            // 
            this.TaskNotes_label.AutoSize = true;
            this.TaskNotes_label.Location = new System.Drawing.Point(12, 271);
            this.TaskNotes_label.Name = "TaskNotes_label";
            this.TaskNotes_label.Size = new System.Drawing.Size(127, 25);
            this.TaskNotes_label.TabIndex = 5;
            this.TaskNotes_label.Text = "Task Notes:";
            // 
            // TaskTitel_label
            // 
            this.TaskTitel_label.AutoSize = true;
            this.TaskTitel_label.Location = new System.Drawing.Point(12, 63);
            this.TaskTitel_label.Name = "TaskTitel_label";
            this.TaskTitel_label.Size = new System.Drawing.Size(112, 25);
            this.TaskTitel_label.TabIndex = 4;
            this.TaskTitel_label.Text = "Task Titel:";
            // 
            // Completed_label
            // 
            this.Completed_label.AutoSize = true;
            this.Completed_label.Location = new System.Drawing.Point(13, 211);
            this.Completed_label.Name = "Completed_label";
            this.Completed_label.Size = new System.Drawing.Size(174, 25);
            this.Completed_label.TabIndex = 8;
            this.Completed_label.Text = "Task Completed:";
            // 
            // Completed_radioButton
            // 
            this.Completed_radioButton.AutoSize = true;
            this.Completed_radioButton.Location = new System.Drawing.Point(216, 209);
            this.Completed_radioButton.Name = "Completed_radioButton";
            this.Completed_radioButton.Size = new System.Drawing.Size(142, 29);
            this.Completed_radioButton.TabIndex = 9;
            this.Completed_radioButton.TabStop = true;
            this.Completed_radioButton.Text = "completed";
            this.Completed_radioButton.UseVisualStyleBackColor = true;
            // 
            // TaskToAppointment_button
            // 
            this.TaskToAppointment_button.Location = new System.Drawing.Point(12, 578);
            this.TaskToAppointment_button.Name = "TaskToAppointment_button";
            this.TaskToAppointment_button.Size = new System.Drawing.Size(414, 43);
            this.TaskToAppointment_button.TabIndex = 10;
            this.TaskToAppointment_button.Text = "Make an appointment of task";
            this.TaskToAppointment_button.UseVisualStyleBackColor = true;
            this.TaskToAppointment_button.Click += new System.EventHandler(this.TaskToAppointment_button_Click);
            // 
            // Min_numericUpDown
            // 
            this.Min_numericUpDown.Location = new System.Drawing.Point(226, 164);
            this.Min_numericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.Min_numericUpDown.Name = "Min_numericUpDown";
            this.Min_numericUpDown.Size = new System.Drawing.Size(120, 31);
            this.Min_numericUpDown.TabIndex = 15;
            // 
            // TaskMin_label
            // 
            this.TaskMin_label.AutoSize = true;
            this.TaskMin_label.Location = new System.Drawing.Point(166, 168);
            this.TaskMin_label.Name = "TaskMin_label";
            this.TaskMin_label.Size = new System.Drawing.Size(53, 25);
            this.TaskMin_label.TabIndex = 14;
            this.TaskMin_label.Text = "Min:";
            // 
            // Hour_numericUpDown
            // 
            this.Hour_numericUpDown.Location = new System.Drawing.Point(89, 163);
            this.Hour_numericUpDown.Name = "Hour_numericUpDown";
            this.Hour_numericUpDown.Size = new System.Drawing.Size(70, 31);
            this.Hour_numericUpDown.TabIndex = 13;
            // 
            // TaskHour_label
            // 
            this.TaskHour_label.AutoSize = true;
            this.TaskHour_label.Location = new System.Drawing.Point(18, 163);
            this.TaskHour_label.Name = "TaskHour_label";
            this.TaskHour_label.Size = new System.Drawing.Size(64, 25);
            this.TaskHour_label.TabIndex = 12;
            this.TaskHour_label.Text = "Hour:";
            // 
            // TaskED_label
            // 
            this.TaskED_label.AutoSize = true;
            this.TaskED_label.Location = new System.Drawing.Point(12, 134);
            this.TaskED_label.Name = "TaskED_label";
            this.TaskED_label.Size = new System.Drawing.Size(237, 25);
            this.TaskED_label.TabIndex = 11;
            this.TaskED_label.Text = "Task estamed duration:";
            // 
            // TaskDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 625);
            this.Controls.Add(this.Min_numericUpDown);
            this.Controls.Add(this.TaskMin_label);
            this.Controls.Add(this.Hour_numericUpDown);
            this.Controls.Add(this.TaskHour_label);
            this.Controls.Add(this.TaskED_label);
            this.Controls.Add(this.TaskToAppointment_button);
            this.Controls.Add(this.Completed_radioButton);
            this.Controls.Add(this.Completed_label);
            this.Controls.Add(this.TaskNotes_textBox);
            this.Controls.Add(this.TaskTitel_textBox);
            this.Controls.Add(this.TaskNotes_label);
            this.Controls.Add(this.TaskTitel_label);
            this.Controls.Add(this.RemoveTask_button);
            this.Controls.Add(this.ChangeTask_button);
            this.Name = "TaskDetailForm";
            this.Text = "ToDoDetail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskDetailForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Min_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hour_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangeTask_button;
        private System.Windows.Forms.Button RemoveTask_button;
        private System.Windows.Forms.TextBox TaskNotes_textBox;
        private System.Windows.Forms.TextBox TaskTitel_textBox;
        private System.Windows.Forms.Label TaskNotes_label;
        private System.Windows.Forms.Label TaskTitel_label;
        private System.Windows.Forms.Label Completed_label;
        private System.Windows.Forms.RadioButton Completed_radioButton;
        private System.Windows.Forms.Button TaskToAppointment_button;
        private System.Windows.Forms.NumericUpDown Min_numericUpDown;
        private System.Windows.Forms.Label TaskMin_label;
        private System.Windows.Forms.NumericUpDown Hour_numericUpDown;
        private System.Windows.Forms.Label TaskHour_label;
        private System.Windows.Forms.Label TaskED_label;
    }
}