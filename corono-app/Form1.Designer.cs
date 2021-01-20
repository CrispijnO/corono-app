
namespace corono_app

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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.postcodeTextBox = new System.Windows.Forms.TextBox();
            this.contactBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.percBox = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(168)))), ((int)(((byte)(196)))));
            this.pictureBox1.Location = new System.Drawing.Point(230, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 367);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(168)))), ((int)(((byte)(196)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label2.Location = new System.Drawing.Point(315, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Corona App";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtbox
            // 
            this.txtbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.txtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtbox.Location = new System.Drawing.Point(261, 74);
            this.txtbox.Multiline = true;
            this.txtbox.Name = "txtbox";
            this.txtbox.ReadOnly = true;
            this.txtbox.Size = new System.Drawing.Size(260, 76);
            this.txtbox.TabIndex = 6;
            this.txtbox.Text = "Met deze app kunt u uw kans om corona te contracteren met verband tot het aantal " +
    "mensen in uw woonplaats en het aantal mensen dat u op een dag tegenkomt";
            this.txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbox.TextChanged += new System.EventHandler(this.txtbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(168)))), ((int)(((byte)(196)))));
            this.label1.Location = new System.Drawing.Point(340, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Jouw Gegevens";
            // 
            // postcodeTextBox
            // 
            this.postcodeTextBox.Location = new System.Drawing.Point(334, 175);
            this.postcodeTextBox.Name = "postcodeTextBox";
            this.postcodeTextBox.Size = new System.Drawing.Size(120, 20);
            this.postcodeTextBox.TabIndex = 8;
            this.postcodeTextBox.Text = "Uw Postcode";
            this.postcodeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contactBox
            // 
            this.contactBox.Location = new System.Drawing.Point(334, 205);
            this.contactBox.Name = "contactBox";
            this.contactBox.Size = new System.Drawing.Size(120, 20);
            this.contactBox.TabIndex = 9;
            this.contactBox.Text = "Aantal Contactpersonen";
            this.contactBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(168)))), ((int)(((byte)(196)))));
            this.label3.Location = new System.Drawing.Point(331, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Jouw Besmettingskans";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.percBox);
            this.panel1.Location = new System.Drawing.Point(296, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // percBox
            // 
            this.percBox.AutoSize = true;
            this.percBox.Location = new System.Drawing.Point(80, 44);
            this.percBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.percBox.Name = "percBox";
            this.percBox.Size = new System.Drawing.Size(35, 13);
            this.percBox.TabIndex = 0;
            this.percBox.Text = "label4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Bereken";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.contactBox);
            this.Controls.Add(this.postcodeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.Name = "Form1";
            this.Text = "M";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox contactBox;
        private System.Windows.Forms.TextBox postcodeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label percBox;
    }
}