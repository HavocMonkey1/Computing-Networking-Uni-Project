using System.ComponentModel;

namespace Client_GUI
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.Load = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.ListNotes = new System.Windows.Forms.ListBox();
            this.NoteHeading = new System.Windows.Forms.TextBox();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.NoteContent = new System.Windows.Forms.RichTextBox();
            this.NoteContentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Load
            // 
            this.Load.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Load.Location = new System.Drawing.Point(38, 12);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(96, 47);
            this.Load.TabIndex = 0;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Save.Location = new System.Drawing.Point(140, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(91, 47);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // ListNotes
            // 
            this.ListNotes.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ListNotes.FormattingEnabled = true;
            this.ListNotes.ItemHeight = 20;
            this.ListNotes.Items.AddRange(new object[] {"123", "456", "789"});
            this.ListNotes.Location = new System.Drawing.Point(38, 73);
            this.ListNotes.Name = "ListNotes";
            this.ListNotes.Size = new System.Drawing.Size(193, 324);
            this.ListNotes.Sorted = true;
            this.ListNotes.TabIndex = 3;
            // 
            // NoteHeading
            // 
            this.NoteHeading.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.NoteHeading.Location = new System.Drawing.Point(293, 22);
            this.NoteHeading.Name = "NoteHeading";
            this.NoteHeading.Size = new System.Drawing.Size(425, 37);
            this.NoteHeading.TabIndex = 4;
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.HeadingLabel.Location = new System.Drawing.Point(297, 5);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(118, 17);
            this.HeadingLabel.TabIndex = 5;
            this.HeadingLabel.Text = "Note Heading";
            // 
            // NoteContent
            // 
            this.NoteContent.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.NoteContent.Location = new System.Drawing.Point(293, 108);
            this.NoteContent.Name = "NoteContent";
            this.NoteContent.Size = new System.Drawing.Size(424, 306);
            this.NoteContent.TabIndex = 6;
            this.NoteContent.Text = "";
            // 
            // NoteContentLabel
            // 
            this.NoteContentLabel.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.NoteContentLabel.Location = new System.Drawing.Point(297, 83);
            this.NoteContentLabel.Name = "NoteContentLabel";
            this.NoteContentLabel.Size = new System.Drawing.Size(96, 16);
            this.NoteContentLabel.TabIndex = 7;
            this.NoteContentLabel.Text = "Note Content";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NoteContentLabel);
            this.Controls.Add(this.NoteContent);
            this.Controls.Add(this.HeadingLabel);
            this.Controls.Add(this.NoteHeading);
            this.Controls.Add(this.ListNotes);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Load);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.ListBox ListNotes;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.RichTextBox NoteContent;
        private System.Windows.Forms.Label NoteContentLabel;
        private System.Windows.Forms.TextBox NoteHeading;
        private System.Windows.Forms.Button Save;

        #endregion
    }
}