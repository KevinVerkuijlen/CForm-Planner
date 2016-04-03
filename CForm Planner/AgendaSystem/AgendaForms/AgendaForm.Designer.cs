namespace CForm_Planner.AgendaSystem.AgendaForms
{
    partial class AgendaForm
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
            this.Agenda_monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.SelectedDate_label = new System.Windows.Forms.Label();
            this.EndDate_label = new System.Windows.Forms.Label();
            this.Appiontment_button = new System.Windows.Forms.Button();
            this.Appointment_listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Agenda_monthCalendar
            // 
            this.Agenda_monthCalendar.Location = new System.Drawing.Point(18, 18);
            this.Agenda_monthCalendar.Name = "Agenda_monthCalendar";
            this.Agenda_monthCalendar.TabIndex = 0;
            this.Agenda_monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Agenda_monthCalendar_DateChanged);
            // 
            // SelectedDate_label
            // 
            this.SelectedDate_label.AutoSize = true;
            this.SelectedDate_label.Location = new System.Drawing.Point(434, 18);
            this.SelectedDate_label.Name = "SelectedDate_label";
            this.SelectedDate_label.Size = new System.Drawing.Size(153, 25);
            this.SelectedDate_label.TabIndex = 1;
            this.SelectedDate_label.Text = "Selected Date:";
            // 
            // EndDate_label
            // 
            this.EndDate_label.AutoSize = true;
            this.EndDate_label.Location = new System.Drawing.Point(434, 53);
            this.EndDate_label.Name = "EndDate_label";
            this.EndDate_label.Size = new System.Drawing.Size(49, 25);
            this.EndDate_label.TabIndex = 2;
            this.EndDate_label.Text = "To: ";
            // 
            // Appiontment_button
            // 
            this.Appiontment_button.Location = new System.Drawing.Point(439, 97);
            this.Appiontment_button.Name = "Appiontment_button";
            this.Appiontment_button.Size = new System.Drawing.Size(255, 37);
            this.Appiontment_button.TabIndex = 4;
            this.Appiontment_button.Text = "Make new appiontment";
            this.Appiontment_button.UseVisualStyleBackColor = true;
            this.Appiontment_button.Click += new System.EventHandler(this.Appiontment_button_Click);
            // 
            // Appointment_listBox
            // 
            this.Appointment_listBox.FormattingEnabled = true;
            this.Appointment_listBox.ItemHeight = 25;
            this.Appointment_listBox.Location = new System.Drawing.Point(18, 346);
            this.Appointment_listBox.Name = "Appointment_listBox";
            this.Appointment_listBox.Size = new System.Drawing.Size(686, 304);
            this.Appointment_listBox.TabIndex = 5;
            this.Appointment_listBox.SelectedIndexChanged += new System.EventHandler(this.Appointment_listBox_SelectedIndexChanged);
            // 
            // AgendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 655);
            this.Controls.Add(this.Appointment_listBox);
            this.Controls.Add(this.Appiontment_button);
            this.Controls.Add(this.EndDate_label);
            this.Controls.Add(this.SelectedDate_label);
            this.Controls.Add(this.Agenda_monthCalendar);
            this.Name = "AgendaForm";
            this.Text = "AgendaForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgendaForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Agenda_monthCalendar;
        private System.Windows.Forms.Label SelectedDate_label;
        private System.Windows.Forms.Label EndDate_label;
        private System.Windows.Forms.Button Appiontment_button;
        private System.Windows.Forms.ListBox Appointment_listBox;
    }
}