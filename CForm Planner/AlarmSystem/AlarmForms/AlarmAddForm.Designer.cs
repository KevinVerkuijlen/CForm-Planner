namespace CForm_Planner.AlarmSystem.AlarmForms
{
    partial class AlarmAddForm
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
            this.Min_label = new System.Windows.Forms.Label();
            this.Hour_label = new System.Windows.Forms.Label();
            this.Min_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Hour_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AddAlarm_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Min_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hour_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Min_label
            // 
            this.Min_label.AutoSize = true;
            this.Min_label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Min_label.Location = new System.Drawing.Point(215, 11);
            this.Min_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Min_label.Name = "Min_label";
            this.Min_label.Size = new System.Drawing.Size(80, 46);
            this.Min_label.TabIndex = 10;
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
            this.Hour_label.TabIndex = 9;
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
            this.Min_numericUpDown.TabIndex = 8;
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
            this.Hour_numericUpDown.TabIndex = 7;
            // 
            // AddAlarm_button
            // 
            this.AddAlarm_button.Location = new System.Drawing.Point(87, 89);
            this.AddAlarm_button.Name = "AddAlarm_button";
            this.AddAlarm_button.Size = new System.Drawing.Size(261, 47);
            this.AddAlarm_button.TabIndex = 11;
            this.AddAlarm_button.Text = "Add Alarm";
            this.AddAlarm_button.UseVisualStyleBackColor = true;
            this.AddAlarm_button.Click += new System.EventHandler(this.AddAlarm_button_Click);
            // 
            // AlarmAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 495);
            this.Controls.Add(this.AddAlarm_button);
            this.Controls.Add(this.Min_label);
            this.Controls.Add(this.Hour_label);
            this.Controls.Add(this.Min_numericUpDown);
            this.Controls.Add(this.Hour_numericUpDown);
            this.Name = "AlarmAddForm";
            this.Text = "AlarmAddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmAddForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Min_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hour_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Min_label;
        private System.Windows.Forms.Label Hour_label;
        private System.Windows.Forms.NumericUpDown Min_numericUpDown;
        private System.Windows.Forms.NumericUpDown Hour_numericUpDown;
        private System.Windows.Forms.Button AddAlarm_button;

    }
}