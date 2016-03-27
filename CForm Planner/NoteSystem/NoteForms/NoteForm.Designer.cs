namespace CForm_Planner.NoteSystem
{
    partial class NoteForm
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
            this.Notes_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.NewNote_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Notes_checkedListBox
            // 
            this.Notes_checkedListBox.FormattingEnabled = true;
            this.Notes_checkedListBox.Location = new System.Drawing.Point(12, 61);
            this.Notes_checkedListBox.Name = "Notes_checkedListBox";
            this.Notes_checkedListBox.Size = new System.Drawing.Size(439, 446);
            this.Notes_checkedListBox.TabIndex = 0;
            this.Notes_checkedListBox.SelectedIndexChanged += new System.EventHandler(this.Notes_checkedListBox_SelectedIndexChanged);
            // 
            // NewNote_button
            // 
            this.NewNote_button.Location = new System.Drawing.Point(311, 12);
            this.NewNote_button.Name = "NewNote_button";
            this.NewNote_button.Size = new System.Drawing.Size(130, 43);
            this.NewNote_button.TabIndex = 2;
            this.NewNote_button.Text = "New Note";
            this.NewNote_button.UseVisualStyleBackColor = true;
            this.NewNote_button.Click += new System.EventHandler(this.NewNote_button_Click);
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 523);
            this.Controls.Add(this.NewNote_button);
            this.Controls.Add(this.Notes_checkedListBox);
            this.Name = "NoteForm";
            this.Text = "NoteForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoteForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox Notes_checkedListBox;
        private System.Windows.Forms.Button NewNote_button;
    }
}