namespace yazlabpuzzle
{
    partial class skor
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
            this.sk = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sk
            // 
            this.sk.FormattingEnabled = true;
            this.sk.Location = new System.Drawing.Point(29, 12);
            this.sk.Name = "sk";
            this.sk.Size = new System.Drawing.Size(157, 407);
            this.sk.TabIndex = 0;
            // 
            // skor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 428);
            this.Controls.Add(this.sk);
            this.Name = "skor";
            this.Load += new System.EventHandler(this.skor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox sk;
    }
}