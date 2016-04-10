namespace CForm_Planner
{
    partial class Reminders
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
            this.Agenda_groupBox = new System.Windows.Forms.GroupBox();
            this.Task_groupBox = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.Agenda_groupBox.SuspendLayout();
            this.Task_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Agenda_groupBox
            // 
            this.Agenda_groupBox.Controls.Add(this.listBox1);
            this.Agenda_groupBox.Location = new System.Drawing.Point(41, 13);
            this.Agenda_groupBox.Name = "Agenda_groupBox";
            this.Agenda_groupBox.Size = new System.Drawing.Size(414, 210);
            this.Agenda_groupBox.TabIndex = 0;
            this.Agenda_groupBox.TabStop = false;
            this.Agenda_groupBox.Text = "Agenda Reminders";
            // 
            // Task_groupBox
            // 
            this.Task_groupBox.Controls.Add(this.checkedListBox1);
            this.Task_groupBox.Location = new System.Drawing.Point(41, 241);
            this.Task_groupBox.Name = "Task_groupBox";
            this.Task_groupBox.Size = new System.Drawing.Size(414, 264);
            this.Task_groupBox.TabIndex = 1;
            this.Task_groupBox.TabStop = false;
            this.Task_groupBox.Text = "Task Reminders";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(50, 90);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 79);
            this.listBox1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(72, 168);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 82);
            this.checkedListBox1.TabIndex = 0;
            // 
            // Reminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 541);
            this.Controls.Add(this.Task_groupBox);
            this.Controls.Add(this.Agenda_groupBox);
            this.Name = "Reminders";
            this.Text = "Reminders";
            this.Agenda_groupBox.ResumeLayout(false);
            this.Task_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Agenda_groupBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox Task_groupBox;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}