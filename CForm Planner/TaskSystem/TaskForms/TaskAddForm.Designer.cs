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
            this.TaskNotes_label.Location = new System.Drawing.Point(13, 99);
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
            this.TaskNotes_textBox.Location = new System.Drawing.Point(13, 137);
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
            // TaskAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 405);
            this.Controls.Add(this.AddTask_button);
            this.Controls.Add(this.TaskNotes_textBox);
            this.Controls.Add(this.TaskTitel_textBox);
            this.Controls.Add(this.TaskNotes_label);
            this.Controls.Add(this.TaskTitel_label);
            this.Name = "TaskAddForm";
            this.Text = "ToDo list";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskAddForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TaskTitel_label;
        private System.Windows.Forms.Label TaskNotes_label;
        private System.Windows.Forms.TextBox TaskTitel_textBox;
        private System.Windows.Forms.TextBox TaskNotes_textBox;
        private System.Windows.Forms.Button AddTask_button;

    }
}