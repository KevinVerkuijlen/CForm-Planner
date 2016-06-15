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
            this.Today_label = new System.Windows.Forms.Label();
            this.TaskP1_label = new System.Windows.Forms.Label();
            this.TaskP2_label = new System.Windows.Forms.Label();
            this.Login_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.GamePropsal_button = new System.Windows.Forms.Button();
            this.Friend_button = new System.Windows.Forms.Button();
            this.upload_button = new System.Windows.Forms.Button();
            this.download_button = new System.Windows.Forms.Button();
            this.ToDo_button = new System.Windows.Forms.Button();
            this.Alarm_button = new System.Windows.Forms.Button();
            this.Agenda_button = new System.Windows.Forms.Button();
            this.Note_button = new System.Windows.Forms.Button();
            this.Account_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Alarm_timer
            // 
            this.Alarm_timer.Tick += new System.EventHandler(this.Alarm_timer_Tick);
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(273, 12);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(74, 25);
            this.Name_label.TabIndex = 5;
            this.Name_label.Text = "Name:";
            // 
            // LastName_label
            // 
            this.LastName_label.AutoSize = true;
            this.LastName_label.Location = new System.Drawing.Point(273, 49);
            this.LastName_label.Name = "LastName_label";
            this.LastName_label.Size = new System.Drawing.Size(121, 25);
            this.LastName_label.TabIndex = 6;
            this.LastName_label.Text = "Last Name:";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Location = new System.Drawing.Point(273, 83);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(71, 25);
            this.email_label.TabIndex = 7;
            this.email_label.Text = "Email:";
            // 
            // UName_label
            // 
            this.UName_label.AutoSize = true;
            this.UName_label.Location = new System.Drawing.Point(401, 12);
            this.UName_label.Name = "UName_label";
            this.UName_label.Size = new System.Drawing.Size(0, 25);
            this.UName_label.TabIndex = 8;
            // 
            // ULastName_label
            // 
            this.ULastName_label.AutoSize = true;
            this.ULastName_label.Location = new System.Drawing.Point(401, 49);
            this.ULastName_label.Name = "ULastName_label";
            this.ULastName_label.Size = new System.Drawing.Size(0, 25);
            this.ULastName_label.TabIndex = 9;
            // 
            // UEmail_label
            // 
            this.UEmail_label.AutoSize = true;
            this.UEmail_label.Location = new System.Drawing.Point(401, 83);
            this.UEmail_label.Name = "UEmail_label";
            this.UEmail_label.Size = new System.Drawing.Size(0, 25);
            this.UEmail_label.TabIndex = 10;
            // 
            // Today_label
            // 
            this.Today_label.AutoSize = true;
            this.Today_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Today_label.Location = new System.Drawing.Point(111, 312);
            this.Today_label.Name = "Today_label";
            this.Today_label.Size = new System.Drawing.Size(115, 37);
            this.Today_label.TabIndex = 13;
            this.Today_label.Text = "Today:";
            // 
            // TaskP1_label
            // 
            this.TaskP1_label.AutoSize = true;
            this.TaskP1_label.Location = new System.Drawing.Point(487, 296);
            this.TaskP1_label.Name = "TaskP1_label";
            this.TaskP1_label.Size = new System.Drawing.Size(114, 25);
            this.TaskP1_label.TabIndex = 14;
            this.TaskP1_label.Text = "Unfinished";
            // 
            // TaskP2_label
            // 
            this.TaskP2_label.AutoSize = true;
            this.TaskP2_label.Location = new System.Drawing.Point(487, 321);
            this.TaskP2_label.Name = "TaskP2_label";
            this.TaskP2_label.Size = new System.Drawing.Size(88, 25);
            this.TaskP2_label.TabIndex = 15;
            this.TaskP2_label.Text = "Tasks =";
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Login_label.Location = new System.Drawing.Point(111, 32);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(118, 46);
            this.Login_label.TabIndex = 17;
            this.Login_label.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(111, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 46);
            this.label1.TabIndex = 18;
            this.label1.Text = "Notes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(475, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 46);
            this.label2.TabIndex = 19;
            this.label2.Text = "Alarms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 37);
            this.label3.TabIndex = 20;
            this.label3.Text = "Agenda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Task";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label7.Location = new System.Drawing.Point(484, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 46);
            this.label7.TabIndex = 24;
            this.label7.Text = "Friends";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(485, 505);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 37);
            this.label8.TabIndex = 26;
            this.label8.Text = "Game";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(485, 542);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 37);
            this.label9.TabIndex = 27;
            this.label9.Text = "Proposal";
            // 
            // GamePropsal_button
            // 
            this.GamePropsal_button.BackgroundImage = global::CForm_Planner.Properties.Resources._38604;
            this.GamePropsal_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GamePropsal_button.Location = new System.Drawing.Point(377, 505);
            this.GamePropsal_button.Name = "GamePropsal_button";
            this.GamePropsal_button.Size = new System.Drawing.Size(92, 86);
            this.GamePropsal_button.TabIndex = 25;
            this.GamePropsal_button.UseVisualStyleBackColor = true;
            this.GamePropsal_button.Click += new System.EventHandler(this.GamePropsal_button_Click);
            // 
            // Friend_button
            // 
            this.Friend_button.BackgroundImage = global::CForm_Planner.Properties.Resources.friends_512;
            this.Friend_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Friend_button.Location = new System.Drawing.Point(377, 391);
            this.Friend_button.Name = "Friend_button";
            this.Friend_button.Size = new System.Drawing.Size(92, 86);
            this.Friend_button.TabIndex = 16;
            this.Friend_button.UseVisualStyleBackColor = true;
            this.Friend_button.Click += new System.EventHandler(this.Friend_button_Click);
            // 
            // upload_button
            // 
            this.upload_button.BackgroundImage = global::CForm_Planner.Properties.Resources.upload;
            this.upload_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upload_button.Location = new System.Drawing.Point(12, 505);
            this.upload_button.Name = "upload_button";
            this.upload_button.Size = new System.Drawing.Size(92, 86);
            this.upload_button.TabIndex = 12;
            this.upload_button.UseVisualStyleBackColor = true;
            this.upload_button.Click += new System.EventHandler(this.upload_button_Click);
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
            this.download_button.Click += new System.EventHandler(this.download_button_Click);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(112, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 37);
            this.label5.TabIndex = 29;
            this.label5.Text = "User data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(112, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 37);
            this.label6.TabIndex = 28;
            this.label6.Text = "Download";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(112, 542);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 37);
            this.label10.TabIndex = 31;
            this.label10.Text = "User data";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(112, 505);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 37);
            this.label11.TabIndex = 30;
            this.label11.Text = "Upload";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 615);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GamePropsal_button);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.Friend_button);
            this.Controls.Add(this.TaskP2_label);
            this.Controls.Add(this.TaskP1_label);
            this.Controls.Add(this.Today_label);
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
            this.Load += new System.EventHandler(this.Home_Load);
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
        private System.Windows.Forms.Label Today_label;
        private System.Windows.Forms.Label TaskP1_label;
        private System.Windows.Forms.Label TaskP2_label;
        private System.Windows.Forms.Button Friend_button;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button GamePropsal_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

