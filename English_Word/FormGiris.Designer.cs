namespace English_Word
{
    partial class FormGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGiris));
            this.bGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bGiris
            // 
            this.bGiris.BackColor = System.Drawing.Color.Beige;
            this.bGiris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bGiris.BackgroundImage")));
            this.bGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bGiris.Font = new System.Drawing.Font("Garamond", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bGiris.Location = new System.Drawing.Point(283, 220);
            this.bGiris.Name = "bGiris";
            this.bGiris.Size = new System.Drawing.Size(159, 50);
            this.bGiris.TabIndex = 0;
            this.bGiris.UseVisualStyleBackColor = false;
            this.bGiris.Click += new System.EventHandler(this.bGiris_Click);
            // 
            // FormGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 410);
            this.Controls.Add(this.bGiris);
            this.Name = "FormGiris";
            this.Text = "Giriş";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bGiris;
    }
}