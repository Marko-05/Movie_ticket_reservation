namespace WindowsFormsApp1
{
    partial class Izbor
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUkupno = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.btnPonisti = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMesta = new System.Windows.Forms.TextBox();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(411, 37);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(750, 222);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1227, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ukupno:";
            // 
            // tbUkupno
            // 
            this.tbUkupno.Enabled = false;
            this.tbUkupno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUkupno.Location = new System.Drawing.Point(1232, 203);
            this.tbUkupno.Margin = new System.Windows.Forms.Padding(4);
            this.tbUkupno.Multiline = true;
            this.tbUkupno.Name = "tbUkupno";
            this.tbUkupno.ReadOnly = true;
            this.tbUkupno.Size = new System.Drawing.Size(174, 40);
            this.tbUkupno.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(43, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 300);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotvrdi.Location = new System.Drawing.Point(1273, 405);
            this.btnPotvrdi.Margin = new System.Windows.Forms.Padding(4);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(256, 86);
            this.btnPotvrdi.TabIndex = 16;
            this.btnPotvrdi.Text = "Potvrdi podatke";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // btnPonisti
            // 
            this.btnPonisti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPonisti.Location = new System.Drawing.Point(1273, 499);
            this.btnPonisti.Margin = new System.Windows.Forms.Padding(4);
            this.btnPonisti.Name = "btnPonisti";
            this.btnPonisti.Size = new System.Drawing.Size(256, 86);
            this.btnPonisti.TabIndex = 17;
            this.btnPonisti.Text = "Poništi mesta";
            this.btnPonisti.UseVisualStyleBackColor = true;
            this.btnPonisti.Click += new System.EventHandler(this.btnPonisti_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1227, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Odabrana mesta:";
            // 
            // tbMesta
            // 
            this.tbMesta.Enabled = false;
            this.tbMesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMesta.Location = new System.Drawing.Point(1232, 114);
            this.tbMesta.Margin = new System.Windows.Forms.Padding(4);
            this.tbMesta.Multiline = true;
            this.tbMesta.Name = "tbMesta";
            this.tbMesta.ReadOnly = true;
            this.tbMesta.Size = new System.Drawing.Size(253, 40);
            this.tbMesta.TabIndex = 19;
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzlaz.Location = new System.Drawing.Point(1273, 593);
            this.btnIzlaz.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(256, 86);
            this.btnIzlaz.TabIndex = 20;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(411, 303);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(750, 490);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(43, 441);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(329, 155);
            this.richTextBox2.TabIndex = 22;
            this.richTextBox2.Text = "";
            // 
            // Izbor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1632, 815);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.tbMesta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPonisti);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbUkupno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Izbor";
            this.Text = "Izbor mesta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Izbor_FormClosing);
            this.Load += new System.EventHandler(this.Izbor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUkupno;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Button btnPonisti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMesta;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}