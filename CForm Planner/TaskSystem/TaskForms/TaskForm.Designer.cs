namespace CForm_Planner.TaskSystem.TaskForms
{
    partial class TaskForm
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
            this.AddTask_button = new System.Windows.Forms.Button();
            this.ToDo_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // AddTask_button
            // 
            this.AddTask_button.Location = new System.Drawing.Point(308, 13);
            this.AddTask_button.Name = "AddTask_button";
            this.AddTask_button.Size = new System.Drawing.Size(132, 54);
            this.AddTask_button.TabIndex = 1;
            this.AddTask_button.Text = "New Task";
            this.AddTask_button.UseVisualStyleBackColor = true;
            this.AddTask_button.Click += new System.EventHandler(this.AddTask_button_Click);
            // 
            // ToDo_checkedListBox
            // 
            this.ToDo_checkedListBox.FormattingEnabled = true;
            this.ToDo_checkedListBox.Location = new System.Drawing.Point(13, 83);
            this.ToDo_checkedListBox.Name = "ToDo_checkedListBox";
            this.ToDo_checkedListBox.Size = new System.Drawing.Size(439, 446);
            this.ToDo_checkedListBox.TabIndex = 2;
            this.ToDo_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.ToDo_checkedListBox_SelectedIndexChanged);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 537);
            this.Controls.Add(this.ToDo_checkedListBox);
            this.Controls.Add(this.AddTask_button);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddTask_button;
        private System.Windows.Forms.CheckedListBox ToDo_checkedListBox;
    }
}