namespace CForm_Planner
{
    partial class Home
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
            this.ToDo_button = new System.Windows.Forms.Button();
            this.Alarm_button = new System.Windows.Forms.Button();
            this.Agenda_button = new System.Windows.Forms.Button();
            this.Note_button = new System.Windows.Forms.Button();
            this.Account_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ToDo_button
            // 
            this.ToDo_button.BackgroundImage = global::CForm_Planner.Properties.Resources.Todo_Checklist;
            this.ToDo_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ToDo_button.Location = new System.Drawing.Point(377, 265);
            this.ToDo_button.Name = "ToDo_button";
            this.ToDo_button.Size = new System.Drawing.Size(92, 86);
            this.ToDo_button.TabIndex = 4;
            this.ToDo_button.UseVisualStyleBackColor = true;
            this.ToDo_button.Click += new System.EventHandler(this.ToDo_button_Click);
            // 
            // Alarm_button
            // 
            this.Alarm_button.BackgroundImage = global::CForm_Planner.Properties.Resources.Times_and_Dates;
            this.Alarm_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Alarm_button.Location = new System.Drawing.Point(377, 137);
            this.Alarm_button.Name = "Alarm_button";
            this.Alarm_button.Size = new System.Drawing.Size(92, 82);
            this.Alarm_button.TabIndex = 3;
            this.Alarm_button.UseVisualStyleBackColor = true;
            this.Alarm_button.Click += new System.EventHandler(this.Alarm_button_Click);
            // 
            // Agenda_button
            // 
            this.Agenda_button.BackgroundImage = global::CForm_Planner.Properties.Resources.calen;
            this.Agenda_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Agenda_button.Location = new System.Drawing.Point(13, 265);
            this.Agenda_button.Name = "Agenda_button";
            this.Agenda_button.Size = new System.Drawing.Size(92, 86);
            this.Agenda_button.TabIndex = 2;
            this.Agenda_button.UseVisualStyleBackColor = true;
            this.Agenda_button.Click += new System.EventHandler(this.Agenda_button_Click);
            // 
            // Note_button
            // 
            this.Note_button.BackgroundImage = global::CForm_Planner.Properties.Resources.edit_notes;
            this.Note_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Note_button.Location = new System.Drawing.Point(13, 137);
            this.Note_button.Name = "Note_button";
            this.Note_button.Size = new System.Drawing.Size(92, 82);
            this.Note_button.TabIndex = 1;
            this.Note_button.UseVisualStyleBackColor = true;
            this.Note_button.Click += new System.EventHandler(this.Note_button_Click);
            // 
            // Account_button
            // 
            this.Account_button.BackgroundImage = global::CForm_Planner.Properties.Resources.patient_cards_512;
            this.Account_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Account_button.Location = new System.Drawing.Point(12, 12);
            this.Account_button.Name = "Account_button";
            this.Account_button.Size = new System.Drawing.Size(93, 79);
            this.Account_button.TabIndex = 0;
            this.Account_button.UseVisualStyleBackColor = true;
            this.Account_button.Click += new System.EventHandler(this.Account_button_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 499);
            this.Controls.Add(this.ToDo_button);
            this.Controls.Add(this.Alarm_button);
            this.Controls.Add(this.Agenda_button);
            this.Controls.Add(this.Note_button);
            this.Controls.Add(this.Account_button);
            this.Name = "Home";
            this.Text = "Planner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Account_button;
        private System.Windows.Forms.Button Note_button;
        private System.Windows.Forms.Button Agenda_button;
        private System.Windows.Forms.Button Alarm_button;
        private System.Windows.Forms.Button ToDo_button;
    }
}

