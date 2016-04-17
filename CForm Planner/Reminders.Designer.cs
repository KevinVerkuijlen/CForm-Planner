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
            this.TotalAppointments_label = new System.Windows.Forms.Label();
            this.SchoolAppointments_label = new System.Windows.Forms.Label();
            this.GameAppointments_label = new System.Windows.Forms.Label();
            this.NormalAppointmenst_label = new System.Windows.Forms.Label();
            this.ToDoTasks_label = new System.Windows.Forms.Label();
            this.Agenda_groupBox.SuspendLayout();
            this.Task_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Agenda_groupBox
            // 
            this.Agenda_groupBox.Controls.Add(this.NormalAppointmenst_label);
            this.Agenda_groupBox.Controls.Add(this.GameAppointments_label);
            this.Agenda_groupBox.Controls.Add(this.SchoolAppointments_label);
            this.Agenda_groupBox.Controls.Add(this.TotalAppointments_label);
            this.Agenda_groupBox.Location = new System.Drawing.Point(12, 12);
            this.Agenda_groupBox.Name = "Agenda_groupBox";
            this.Agenda_groupBox.Size = new System.Drawing.Size(414, 160);
            this.Agenda_groupBox.TabIndex = 0;
            this.Agenda_groupBox.TabStop = false;
            this.Agenda_groupBox.Text = "Agenda Reminders";
            // 
            // Task_groupBox
            // 
            this.Task_groupBox.Controls.Add(this.ToDoTasks_label);
            this.Task_groupBox.Location = new System.Drawing.Point(12, 178);
            this.Task_groupBox.Name = "Task_groupBox";
            this.Task_groupBox.Size = new System.Drawing.Size(414, 84);
            this.Task_groupBox.TabIndex = 1;
            this.Task_groupBox.TabStop = false;
            this.Task_groupBox.Text = "Task Reminders";
            // 
            // TotalAppointments_label
            // 
            this.TotalAppointments_label.AutoSize = true;
            this.TotalAppointments_label.Location = new System.Drawing.Point(7, 31);
            this.TotalAppointments_label.Name = "TotalAppointments_label";
            this.TotalAppointments_label.Size = new System.Drawing.Size(356, 25);
            this.TotalAppointments_label.TabIndex = 1;
            this.TotalAppointments_label.Text = "This week you have .. appiontments";
            // 
            // SchoolAppointments_label
            // 
            this.SchoolAppointments_label.AutoSize = true;
            this.SchoolAppointments_label.Location = new System.Drawing.Point(7, 98);
            this.SchoolAppointments_label.Name = "SchoolAppointments_label";
            this.SchoolAppointments_label.Size = new System.Drawing.Size(259, 25);
            this.SchoolAppointments_label.TabIndex = 2;
            this.SchoolAppointments_label.Text = ".. appointments for school";
            // 
            // GameAppointments_label
            // 
            this.GameAppointments_label.AutoSize = true;
            this.GameAppointments_label.Location = new System.Drawing.Point(7, 127);
            this.GameAppointments_label.Name = "GameAppointments_label";
            this.GameAppointments_label.Size = new System.Drawing.Size(260, 25);
            this.GameAppointments_label.TabIndex = 3;
            this.GameAppointments_label.Text = ".. appointments for games";
            // 
            // NormalAppointmenst_label
            // 
            this.NormalAppointmenst_label.AutoSize = true;
            this.NormalAppointmenst_label.Location = new System.Drawing.Point(12, 70);
            this.NormalAppointmenst_label.Name = "NormalAppointmenst_label";
            this.NormalAppointmenst_label.Size = new System.Drawing.Size(230, 25);
            this.NormalAppointmenst_label.TabIndex = 4;
            this.NormalAppointmenst_label.Text = ".. normal appointments";
            // 
            // ToDoTasks_label
            // 
            this.ToDoTasks_label.AutoSize = true;
            this.ToDoTasks_label.Location = new System.Drawing.Point(7, 40);
            this.ToDoTasks_label.Name = "ToDoTasks_label";
            this.ToDoTasks_label.Size = new System.Drawing.Size(346, 25);
            this.ToDoTasks_label.TabIndex = 1;
            this.ToDoTasks_label.Text = "You still have .. uncompleted tasks";
            // 
            // Reminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 283);
            this.Controls.Add(this.Task_groupBox);
            this.Controls.Add(this.Agenda_groupBox);
            this.Name = "Reminders";
            this.Text = "Reminders";
            this.Load += new System.EventHandler(this.Reminders_Load);
            this.Agenda_groupBox.ResumeLayout(false);
            this.Agenda_groupBox.PerformLayout();
            this.Task_groupBox.ResumeLayout(false);
            this.Task_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Agenda_groupBox;
        private System.Windows.Forms.GroupBox Task_groupBox;
        private System.Windows.Forms.Label TotalAppointments_label;
        private System.Windows.Forms.Label NormalAppointmenst_label;
        private System.Windows.Forms.Label GameAppointments_label;
        private System.Windows.Forms.Label SchoolAppointments_label;
        private System.Windows.Forms.Label ToDoTasks_label;
    }
}