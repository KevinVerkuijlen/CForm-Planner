namespace CForm_Planner.AlarmSystem.AlarmForms
{
    partial class AlarmForm
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
            this.Alarm_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.AddAlarm_button = new System.Windows.Forms.Button();
            this.Alarm_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Alarm_checkedListBox
            // 
            this.Alarm_checkedListBox.FormattingEnabled = true;
            this.Alarm_checkedListBox.Location = new System.Drawing.Point(12, 71);
            this.Alarm_checkedListBox.Name = "Alarm_checkedListBox";
            this.Alarm_checkedListBox.Size = new System.Drawing.Size(414, 394);
            this.Alarm_checkedListBox.TabIndex = 0;
            this.Alarm_checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Alarm_checkedListBox_ItemCheck);
            this.Alarm_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.Alarm_checkedListBox_SelectedIndexChanged);
            // 
            // AddAlarm_button
            // 
            this.AddAlarm_button.Location = new System.Drawing.Point(263, 12);
            this.AddAlarm_button.Name = "AddAlarm_button";
            this.AddAlarm_button.Size = new System.Drawing.Size(163, 53);
            this.AddAlarm_button.TabIndex = 1;
            this.AddAlarm_button.Text = "Add Alarm";
            this.AddAlarm_button.UseVisualStyleBackColor = true;
            this.AddAlarm_button.Click += new System.EventHandler(this.AddAlarm_button_Click);
            // 
            // Alarm_timer
            // 
            this.Alarm_timer.Interval = 1000;
            this.Alarm_timer.Tick += new System.EventHandler(this.Alarm_timer_Tick);
            // 
            // AlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 477);
            this.Controls.Add(this.AddAlarm_button);
            this.Controls.Add(this.Alarm_checkedListBox);
            this.Name = "AlarmForm";
            this.Text = "AlarmForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmForm_FormClosing);
            this.Load += new System.EventHandler(this.AlarmForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox Alarm_checkedListBox;
        private System.Windows.Forms.Button AddAlarm_button;
        private System.Windows.Forms.Timer Alarm_timer;
    }
}