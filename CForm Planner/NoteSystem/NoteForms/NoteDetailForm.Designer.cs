namespace CForm_Planner.NoteSystem
{
    partial class NoteDetailForm
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
            this.RemoveNote_button = new System.Windows.Forms.Button();
            this.ChangeNote_button = new System.Windows.Forms.Button();
            this.NoteInfor_label = new System.Windows.Forms.Label();
            this.NoteInfo_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RemoveNote_button
            // 
            this.RemoveNote_button.Location = new System.Drawing.Point(12, 7);
            this.RemoveNote_button.Name = "RemoveNote_button";
            this.RemoveNote_button.Size = new System.Drawing.Size(192, 36);
            this.RemoveNote_button.TabIndex = 3;
            this.RemoveNote_button.Text = "Remove Note";
            this.RemoveNote_button.UseVisualStyleBackColor = true;
            this.RemoveNote_button.Click += new System.EventHandler(this.RemoveNote_button_Click);
            // 
            // ChangeNote_button
            // 
            this.ChangeNote_button.Location = new System.Drawing.Point(238, 7);
            this.ChangeNote_button.Name = "ChangeNote_button";
            this.ChangeNote_button.Size = new System.Drawing.Size(192, 36);
            this.ChangeNote_button.TabIndex = 2;
            this.ChangeNote_button.Text = "Change Note";
            this.ChangeNote_button.UseVisualStyleBackColor = true;
            this.ChangeNote_button.Click += new System.EventHandler(this.ChangeNote_button_Click);
            // 
            // NoteInfor_label
            // 
            this.NoteInfor_label.AutoSize = true;
            this.NoteInfor_label.Location = new System.Drawing.Point(12, 60);
            this.NoteInfor_label.Name = "NoteInfor_label";
            this.NoteInfor_label.Size = new System.Drawing.Size(175, 25);
            this.NoteInfor_label.TabIndex = 5;
            this.NoteInfor_label.Text = "Note information:";
            // 
            // NoteInfo_textBox
            // 
            this.NoteInfo_textBox.Location = new System.Drawing.Point(12, 111);
            this.NoteInfo_textBox.Multiline = true;
            this.NoteInfo_textBox.Name = "NoteInfo_textBox";
            this.NoteInfo_textBox.Size = new System.Drawing.Size(438, 346);
            this.NoteInfo_textBox.TabIndex = 4;
            // 
            // NoteDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 551);
            this.Controls.Add(this.NoteInfor_label);
            this.Controls.Add(this.NoteInfo_textBox);
            this.Controls.Add(this.RemoveNote_button);
            this.Controls.Add(this.ChangeNote_button);
            this.Name = "NoteDetailForm";
            this.Text = "NoteDetailForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoteDetailForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RemoveNote_button;
        private System.Windows.Forms.Button ChangeNote_button;
        private System.Windows.Forms.Label NoteInfor_label;
        private System.Windows.Forms.TextBox NoteInfo_textBox;
    }
}