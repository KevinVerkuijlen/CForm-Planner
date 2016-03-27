namespace CForm_Planner.NoteSystem
{
    partial class NoteAddForm
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
            this.AddNote_button = new System.Windows.Forms.Button();
            this.NoteInfo_textBox = new System.Windows.Forms.TextBox();
            this.NoteInfor_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddNote_button
            // 
            this.AddNote_button.Location = new System.Drawing.Point(324, 13);
            this.AddNote_button.Name = "AddNote_button";
            this.AddNote_button.Size = new System.Drawing.Size(127, 45);
            this.AddNote_button.TabIndex = 0;
            this.AddNote_button.Text = "Add Note";
            this.AddNote_button.UseVisualStyleBackColor = true;
            this.AddNote_button.Click += new System.EventHandler(this.AddNote_button_Click);
            // 
            // NoteInfo_textBox
            // 
            this.NoteInfo_textBox.Location = new System.Drawing.Point(13, 64);
            this.NoteInfo_textBox.Multiline = true;
            this.NoteInfo_textBox.Name = "NoteInfo_textBox";
            this.NoteInfo_textBox.Size = new System.Drawing.Size(438, 346);
            this.NoteInfo_textBox.TabIndex = 1;
            // 
            // NoteInfor_label
            // 
            this.NoteInfor_label.AutoSize = true;
            this.NoteInfor_label.Location = new System.Drawing.Point(13, 13);
            this.NoteInfor_label.Name = "NoteInfor_label";
            this.NoteInfor_label.Size = new System.Drawing.Size(175, 25);
            this.NoteInfor_label.TabIndex = 2;
            this.NoteInfor_label.Text = "Note information:";
            // 
            // NoteAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 415);
            this.Controls.Add(this.NoteInfor_label);
            this.Controls.Add(this.NoteInfo_textBox);
            this.Controls.Add(this.AddNote_button);
            this.Name = "NoteAddForm";
            this.Text = "NoteAddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoteAddForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddNote_button;
        private System.Windows.Forms.TextBox NoteInfo_textBox;
        private System.Windows.Forms.Label NoteInfor_label;
    }
}