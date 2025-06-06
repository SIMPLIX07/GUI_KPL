namespace index
{
    partial class RegisterPerusahaan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 141);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 0;
            label1.Text = "Masukkan Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 169);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 1;
            label2.Text = "Masukkan Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(270, 198);
            label3.Name = "label3";
            label3.Size = new Size(160, 15);
            label3.TabIndex = 2;
            label3.Text = "Masukkan Nama Perusahaan";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(270, 225);
            label4.Name = "label4";
            label4.Size = new Size(166, 15);
            label4.TabIndex = 3;
            label4.Text = "Masukkan Nomor Perusahaan";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(460, 141);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(460, 170);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 23);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(460, 199);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 23);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(460, 228);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 23);
            textBox4.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(350, 280);
            button1.Name = "button1";
            button1.Size = new Size(100, 30);
            button1.TabIndex = 8;
            button1.Text = "Daftar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // RegisterPerusahaan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterPerusahaan";
            Text = "Register Perusahaan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
    }
}
