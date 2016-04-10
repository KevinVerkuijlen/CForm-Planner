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
            this.components = new System.ComponentModel.Container();
            this.Alarm_timer = new System.Windows.Forms.Timer(this.components);
            this.Name_label = new System.Windows.Forms.Label();
            this.LastName_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.UName_label = new System.Windows.Forms.Label();
            this.ULastName_label = new System.Windows.Forms.Label();
            this.UEmail_label = new System.Windows.Forms.Label();
            this.upload_button = new System.Windows.Forms.Button();
            this.download_button = new System.Windows.Forms.Button();
            this.ToDo_button = new System.Windows.Forms.Button();
            this.Alarm_button = new System.Windows.Forms.Button();
            this.Agenda_button = new System.Windows.Forms.Button();
            this.Note_button = new System.Windows.Forms.Button();
            this.Account_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Alarm_timer
            // 
            this.Alarm_timer.Tick += new System.EventHandler(this.Alarm_timer_Tick);
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(151, 12);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(74, 25);
            this.Name_label.TabIndex = 5;
            this.Name_label.Text = "Name:";
            // 
            // LastName_label
            // 
            this.LastName_label.AutoSize = true;
            this.LastName_label.Location = new System.Drawing.Point(151, 49);
            this.LastName_label.Name = "LastName_label";
            this.LastName_label.Size = new System.Drawing.Size(121, 25);
            this.LastName_label.TabIndex = 6;
            this.LastName_label.Text = "Last Name:";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Location = new System.Drawing.Point(151, 83);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(71, 25);
            this.email_label.TabIndex = 7;
            this.email_label.Text = "Email:";
            // 
            // UName_label
            // 
            this.UName_label.AutoSize = true;
            this.UName_label.Location = new System.Drawing.Point(279, 12);
            this.UName_label.Name = "UName_label";
            this.UName_label.Size = new System.Drawing.Size(0, 25);
            this.UName_label.TabIndex = 8;
            // 
            // ULastName_label
            // 
            this.ULastName_label.AutoSize = true;
            this.ULastName_label.Location = new System.Drawing.Point(279, 49);
            this.ULastName_label.Name = "ULastName_label";
            this.ULastName_label.Size = new System.Drawing.Size(0, 25);
            this.ULastName_label.TabIndex = 9;
            // 
            // UEmail_label
            // 
            this.UEmail_label.AutoSize = true;
            this.UEmail_label.Location = new System.Drawing.Point(279, 83);
            this.UEmail_label.Name = "UEmail_label";
            this.UEmail_label.Size = new System.Drawing.Size(0, 25);
            this.UEmail_label.TabIndex = 10;
            // 
            // upload_button
            // 
            this.upload_button.BackgroundImage = global::CForm_Planner.Properties.Resources.upload;
            this.upload_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upload_button.Location = new System.Drawing.Point(377, 391);
            this.upload_button.Name = "upload_button";
            this.upload_button.Size = new System.Drawing.Size(92, 86);
            this.upload_button.TabIndex = 12;
            this.upload_button.UseVisualStyleBackColor = true;
            // 
            // download_button
            // 
            this.download_button.BackgroundImage = global::CForm_Planner.Properties.Resources.download;
            this.download_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.download_button.Location = new System.Drawing.Point(13, 391);
            this.download_button.Name = "download_button";
            this.download_button.Size = new System.Drawing.Size(93, 86);
            this.download_button.TabIndex = 11;
            this.download_button.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.upload_button);
            this.Controls.Add(this.download_button);
            this.Controls.Add(this.UEmail_label);
            this.Controls.Add(this.ULastName_label);
            this.Controls.Add(this.UName_label);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.LastName_label);
            this.Controls.Add(this.Name_label);
            this.Controls.Add(this.ToDo_button);
            this.Controls.Add(this.Alarm_button);
            this.Controls.Add(this.Agenda_button);
            this.Controls.Add(this.Note_button);
            this.Controls.Add(this.Account_button);
            this.Name = "Home";
            this.Text = "Planner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Account_button;
        private System.Windows.Forms.Button Note_button;
        private System.Windows.Forms.Button Agenda_button;
        private System.Windows.Forms.Button Alarm_button;
        private System.Windows.Forms.Button ToDo_button;
        private System.Windows.Forms.Timer Alarm_timer;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.Label LastName_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label UName_label;
        private System.Windows.Forms.Label ULastName_label;
        private System.Windows.Forms.Label UEmail_label;
        private System.Windows.Forms.Button download_button;
        private System.Windows.Forms.Button upload_button;
    }
}

