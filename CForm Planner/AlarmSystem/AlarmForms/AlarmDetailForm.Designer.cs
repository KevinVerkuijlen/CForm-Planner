namespace CForm_Planner.AlarmSystem.AlarmForms
{
    partial class AlarmDetailForm
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
            this.ChangeAlarm_button = new System.Windows.Forms.Button();
            this.Min_label = new System.Windows.Forms.Label();
            this.Hour_label = new System.Windows.Forms.Label();
            this.Min_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Hour_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.On_radioButton = new System.Windows.Forms.RadioButton();
            this.Off_radioButton = new System.Windows.Forms.RadioButton();
            this.RemoveAlarm_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Min_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hour_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeAlarm_button
            // 
            this.ChangeAlarm_button.Location = new System.Drawing.Point(203, 127);
            this.ChangeAlarm_button.Name = "ChangeAlarm_button";
            this.ChangeAlarm_button.Size = new System.Drawing.Size(200, 47);
            this.ChangeAlarm_button.TabIndex = 16;
            this.ChangeAlarm_button.Text = "Change Alarm";
            this.ChangeAlarm_button.UseVisualStyleBackColor = true;
            this.ChangeAlarm_button.Click += new System.EventHandler(this.ChangeAlarm_button_Click);
            // 
            // Min_label
            // 
            this.Min_label.AutoSize = true;
            this.Min_label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Min_label.Location = new System.Drawing.Point(215, 11);
            this.Min_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Min_label.Name = "Min_label";
            this.Min_label.Size = new System.Drawing.Size(80, 46);
            this.Min_label.TabIndex = 15;
            this.Min_label.Text = "mm";
            // 
            // Hour_label
            // 
            this.Hour_label.AutoSize = true;
            this.Hour_label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hour_label.Location = new System.Drawing.Point(15, 9);
            this.Hour_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Hour_label.Name = "Hour_label";
            this.Hour_label.Size = new System.Drawing.Size(60, 46);
            this.Hour_label.TabIndex = 14;
            this.Hour_label.Text = "hh";
            // 
            // Min_numericUpDown
            // 
            this.Min_numericUpDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Min_numericUpDown.Location = new System.Drawing.Point(307, 13);
            this.Min_numericUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.Min_numericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.Min_numericUpDown.Name = "Min_numericUpDown";
            this.Min_numericUpDown.Size = new System.Drawing.Size(96, 47);
            this.Min_numericUpDown.TabIndex = 13;
            // 
            // Hour_numericUpDown
            // 
            this.Hour_numericUpDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hour_numericUpDown.Location = new System.Drawing.Point(87, 11);
            this.Hour_numericUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.Hour_numericUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Hour_numericUpDown.Name = "Hour_numericUpDown";
            this.Hour_numericUpDown.Size = new System.Drawing.Size(96, 47);
            this.Hour_numericUpDown.TabIndex = 12;
            // 
            // On_radioButton
            // 
            this.On_radioButton.AutoSize = true;
            this.On_radioButton.Location = new System.Drawing.Point(157, 79);
            this.On_radioButton.Name = "On_radioButton";
            this.On_radioButton.Size = new System.Drawing.Size(71, 29);
            this.On_radioButton.TabIndex = 17;
            this.On_radioButton.TabStop = true;
            this.On_radioButton.Text = "On";
            this.On_radioButton.UseVisualStyleBackColor = true;
            // 
            // Off_radioButton
            // 
            this.Off_radioButton.AutoSize = true;
            this.Off_radioButton.Location = new System.Drawing.Point(246, 79);
            this.Off_radioButton.Name = "Off_radioButton";
            this.Off_radioButton.Size = new System.Drawing.Size(71, 29);
            this.Off_radioButton.TabIndex = 18;
            this.Off_radioButton.TabStop = true;
            this.Off_radioButton.Text = "Off";
            this.Off_radioButton.UseVisualStyleBackColor = true;
            // 
            // RemoveAlarm_button
            // 
            this.RemoveAlarm_button.Location = new System.Drawing.Point(23, 127);
            this.RemoveAlarm_button.Name = "RemoveAlarm_button";
            this.RemoveAlarm_button.Size = new System.Drawing.Size(160, 46);
            this.RemoveAlarm_button.TabIndex = 19;
            this.RemoveAlarm_button.Text = "Remove Alarm";
            this.RemoveAlarm_button.UseVisualStyleBackColor = true;
            this.RemoveAlarm_button.Click += new System.EventHandler(this.RemoveAlarm_button_Click);
            // 
            // AlarmDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 447);
            this.Controls.Add(this.RemoveAlarm_button);
            this.Controls.Add(this.Off_radioButton);
            this.Controls.Add(this.On_radioButton);
            this.Controls.Add(this.ChangeAlarm_button);
            this.Controls.Add(this.Min_label);
            this.Controls.Add(this.Hour_label);
            this.Controls.Add(this.Min_numericUpDown);
            this.Controls.Add(this.Hour_numericUpDown);
            this.Name = "AlarmDetailForm";
            this.Text = "AlarmDetailForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmDetailForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Min_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hour_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangeAlarm_button;
        private System.Windows.Forms.Label Min_label;
        private System.Windows.Forms.Label Hour_label;
        private System.Windows.Forms.NumericUpDown Min_numericUpDown;
        private System.Windows.Forms.NumericUpDown Hour_numericUpDown;
        private System.Windows.Forms.RadioButton On_radioButton;
        private System.Windows.Forms.RadioButton Off_radioButton;
        private System.Windows.Forms.Button RemoveAlarm_button;
    }
}