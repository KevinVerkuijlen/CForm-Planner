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
            this.TaskNotes_textBox.Location = new System.Drawing.Point(12, 249);
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
            this.TaskNotes_label.Location = new System.Drawing.Point(12, 211);
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
            this.Completed_label.Location = new System.Drawing.Point(13, 151);
            this.Completed_label.Name = "Completed_label";
            this.Completed_label.Size = new System.Drawing.Size(174, 25);
            this.Completed_label.TabIndex = 8;
            this.Completed_label.Text = "Task Completed:";
            // 
            // Completed_radioButton
            // 
            this.Completed_radioButton.AutoSize = true;
            this.Completed_radioButton.Location = new System.Drawing.Point(216, 149);
            this.Completed_radioButton.Name = "Completed_radioButton";
            this.Completed_radioButton.Size = new System.Drawing.Size(142, 29);
            this.Completed_radioButton.TabIndex = 9;
            this.Completed_radioButton.TabStop = true;
            this.Completed_radioButton.Text = "completed";
            this.Completed_radioButton.UseVisualStyleBackColor = true;
            // 
            // TaskDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 523);
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
    }
}