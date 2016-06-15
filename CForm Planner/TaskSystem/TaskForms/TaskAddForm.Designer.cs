namespace CForm_Planner
{
    partial class TaskAddForm
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
            this.TaskTitel_label = new System.Windows.Forms.Label();
            this.TaskNotes_label = new System.Windows.Forms.Label();
            this.TaskTitel_textBox = new System.Windows.Forms.TextBox();
            this.TaskNotes_textBox = new System.Windows.Forms.TextBox();
            this.AddTask_button = new System.Windows.Forms.Button();
            this.TaskED_label = new System.Windows.Forms.Label();
            this.TaskHour_label = new System.Windows.Forms.Label();
            this.Hour_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TaskMin_label = new System.Windows.Forms.Label();
            this.Min_numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Hour_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskTitel_label
            // 
            this.TaskTitel_label.AutoSize = true;
            this.TaskTitel_label.Location = new System.Drawing.Point(13, 21);
            this.TaskTitel_label.Name = "TaskTitel_label";
            this.TaskTitel_label.Size = new System.Drawing.Size(112, 25);
            this.TaskTitel_label.TabIndex = 0;
            this.TaskTitel_label.Text = "Task Titel:";
            // 
            // TaskNotes_label
            // 
            this.TaskNotes_label.AutoSize = true;
            this.TaskNotes_label.Location = new System.Drawing.Point(12, 173);
            this.TaskNotes_label.Name = "TaskNotes_label";
            this.TaskNotes_label.Size = new System.Drawing.Size(127, 25);
            this.TaskNotes_label.TabIndex = 1;
            this.TaskNotes_label.Text = "Task Notes:";
            // 
            // TaskTitel_textBox
            // 
            this.TaskTitel_textBox.Location = new System.Drawing.Point(13, 58);
            this.TaskTitel_textBox.Name = "TaskTitel_textBox";
            this.TaskTitel_textBox.Size = new System.Drawing.Size(324, 31);
            this.TaskTitel_textBox.TabIndex = 2;
            // 
            // TaskNotes_textBox
            // 
            this.TaskNotes_textBox.Location = new System.Drawing.Point(12, 211);
            this.TaskNotes_textBox.Multiline = true;
            this.TaskNotes_textBox.Name = "TaskNotes_textBox";
            this.TaskNotes_textBox.Size = new System.Drawing.Size(324, 262);
            this.TaskNotes_textBox.TabIndex = 3;
            // 
            // AddTask_button
            // 
            this.AddTask_button.Location = new System.Drawing.Point(226, 13);
            this.AddTask_button.Name = "AddTask_button";
            this.AddTask_button.Size = new System.Drawing.Size(111, 41);
            this.AddTask_button.TabIndex = 4;
            this.AddTask_button.Text = "Add Task";
            this.AddTask_button.UseVisualStyleBackColor = true;
            this.AddTask_button.Click += new System.EventHandler(this.AddTask_button_Click);
            // 
            // TaskED_label
            // 
            this.TaskED_label.AutoSize = true;
            this.TaskED_label.Location = new System.Drawing.Point(12, 96);
            this.TaskED_label.Name = "TaskED_label";
            this.TaskED_label.Size = new System.Drawing.Size(237, 25);
            this.TaskED_label.TabIndex = 5;
            this.TaskED_label.Text = "Task estamed duration:";
            // 
            // TaskHour_label
            // 
            this.TaskHour_label.AutoSize = true;
            this.TaskHour_label.Location = new System.Drawing.Point(18, 125);
            this.TaskHour_label.Name = "TaskHour_label";
            this.TaskHour_label.Size = new System.Drawing.Size(64, 25);
            this.TaskHour_label.TabIndex = 6;
            this.TaskHour_label.Text = "Hour:";
            // 
            // Hour_numericUpDown
            // 
            this.Hour_numericUpDown.Location = new System.Drawing.Point(89, 125);
            this.Hour_numericUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Hour_numericUpDown.Name = "Hour_numericUpDown";
            this.Hour_numericUpDown.Size = new System.Drawing.Size(70, 31);
            this.Hour_numericUpDown.TabIndex = 7;
            // 
            // TaskMin_label
            // 
            this.TaskMin_label.AutoSize = true;
            this.TaskMin_label.Location = new System.Drawing.Point(166, 130);
            this.TaskMin_label.Name = "TaskMin_label";
            this.TaskMin_label.Size = new System.Drawing.Size(53, 25);
            this.TaskMin_label.TabIndex = 8;
            this.TaskMin_label.Text = "Min:";
            // 
            // Min_numericUpDown
            // 
            this.Min_numericUpDown.Location = new System.Drawing.Point(226, 126);
            this.Min_numericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.Min_numericUpDown.Name = "Min_numericUpDown";
            this.Min_numericUpDown.Size = new System.Drawing.Size(72, 31);
            this.Min_numericUpDown.TabIndex = 9;
            // 
            // TaskAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 485);
            this.Controls.Add(this.Min_numericUpDown);
            this.Controls.Add(this.TaskMin_label);
            this.Controls.Add(this.Hour_numericUpDown);
            this.Controls.Add(this.TaskHour_label);
            this.Controls.Add(this.TaskED_label);
            this.Controls.Add(this.AddTask_button);
            this.Controls.Add(this.TaskNotes_textBox);
            this.Controls.Add(this.TaskTitel_textBox);
            this.Controls.Add(this.TaskNotes_label);
            this.Controls.Add(this.TaskTitel_label);
            this.Name = "TaskAddForm";
            this.Text = "ToDo list";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskAddForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Hour_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TaskTitel_label;
        private System.Windows.Forms.Label TaskNotes_label;
        private System.Windows.Forms.TextBox TaskTitel_textBox;
        private System.Windows.Forms.TextBox TaskNotes_textBox;
        private System.Windows.Forms.Button AddTask_button;
        private System.Windows.Forms.Label TaskED_label;
        private System.Windows.Forms.Label TaskHour_label;
        private System.Windows.Forms.NumericUpDown Hour_numericUpDown;
        private System.Windows.Forms.Label TaskMin_label;
        private System.Windows.Forms.NumericUpDown Min_numericUpDown;
    }
}