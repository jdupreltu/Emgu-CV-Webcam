using System.Windows.Forms;

namespace WebcamHW
{
    partial class Form1
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
            this.emguPictureBox = new System.Windows.Forms.PictureBox();
            this.binaryPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.emguPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // emguPictureBox
            // 
            this.emguPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.emguPictureBox.Location = new System.Drawing.Point(29, 31);
            this.emguPictureBox.Name = "emguPictureBox";
            this.emguPictureBox.Size = new System.Drawing.Size(800, 524);
            this.emguPictureBox.TabIndex = 0;
            this.emguPictureBox.TabStop = false;
            // 
            // binaryPictureBox
            // 
            this.binaryPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.binaryPictureBox.Location = new System.Drawing.Point(857, 31);
            this.binaryPictureBox.Name = "binaryPictureBox";
            this.binaryPictureBox.Size = new System.Drawing.Size(800, 524);
            this.binaryPictureBox.TabIndex = 1;
            this.binaryPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1692, 589);
            this.Controls.Add(this.binaryPictureBox);
            this.Controls.Add(this.emguPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.emguPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox emguPictureBox;
        private PictureBox binaryPictureBox;
    }
}

