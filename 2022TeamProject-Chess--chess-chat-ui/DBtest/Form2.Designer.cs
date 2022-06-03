namespace DBtest
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btn_insert = new System.Windows.Forms.Button();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_pwd1 = new System.Windows.Forms.TextBox();
            this.txt_pwd2 = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_birth = new System.Windows.Forms.DateTimePicker();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_pw = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_insert
            // 
            this.btn_insert.BackColor = System.Drawing.Color.Transparent;
            this.btn_insert.FlatAppearance.BorderSize = 0;
            this.btn_insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_insert.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insert.ForeColor = System.Drawing.Color.White;
            this.btn_insert.Location = new System.Drawing.Point(149, 588);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(129, 35);
            this.btn_insert.TabIndex = 0;
            this.btn_insert.Text = "Submit";
            this.btn_insert.UseVisualStyleBackColor = false;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // txt_id
            // 
            this.txt_id.BackColor = System.Drawing.Color.SeaShell;
            this.txt_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_id.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.Location = new System.Drawing.Point(91, 86);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(251, 22);
            this.txt_id.TabIndex = 1;
            // 
            // txt_pwd1
            // 
            this.txt_pwd1.BackColor = System.Drawing.Color.SeaShell;
            this.txt_pwd1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pwd1.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pwd1.Location = new System.Drawing.Point(91, 161);
            this.txt_pwd1.Name = "txt_pwd1";
            this.txt_pwd1.PasswordChar = '●';
            this.txt_pwd1.Size = new System.Drawing.Size(251, 22);
            this.txt_pwd1.TabIndex = 2;
            // 
            // txt_pwd2
            // 
            this.txt_pwd2.BackColor = System.Drawing.Color.SeaShell;
            this.txt_pwd2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pwd2.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pwd2.Location = new System.Drawing.Point(91, 243);
            this.txt_pwd2.Name = "txt_pwd2";
            this.txt_pwd2.PasswordChar = '●';
            this.txt_pwd2.Size = new System.Drawing.Size(251, 22);
            this.txt_pwd2.TabIndex = 3;
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.SeaShell;
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_name.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(91, 324);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(251, 22);
            this.txt_name.TabIndex = 4;
            this.txt_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btn_name_KeyPress);
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.SeaShell;
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_email.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(91, 412);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(251, 22);
            this.txt_email.TabIndex = 5;
            // 
            // txt_phone
            // 
            this.txt_phone.BackColor = System.Drawing.Color.SeaShell;
            this.txt_phone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_phone.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.Location = new System.Drawing.Point(91, 489);
            this.txt_phone.MaxLength = 11;
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(251, 22);
            this.txt_phone.TabIndex = 6;
            this.txt_phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btn_phone_KeyPress);
            // 
            // txt_birth
            // 
            this.txt_birth.Location = new System.Drawing.Point(91, 561);
            this.txt_birth.Name = "txt_birth";
            this.txt_birth.Size = new System.Drawing.Size(249, 21);
            this.txt_birth.TabIndex = 8;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ID.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID.Location = new System.Drawing.Point(89, 60);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(29, 17);
            this.lbl_ID.TabIndex = 9;
            this.lbl_ID.Text = "ID";
            // 
            // lbl_pw
            // 
            this.lbl_pw.AutoSize = true;
            this.lbl_pw.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pw.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pw.Location = new System.Drawing.Point(89, 131);
            this.lbl_pw.Name = "lbl_pw";
            this.lbl_pw.Size = new System.Drawing.Size(35, 17);
            this.lbl_pw.TabIndex = 10;
            this.lbl_pw.Text = "PW";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(88, 288);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(54, 17);
            this.lbl_name.TabIndex = 11;
            this.lbl_name.Text = "Name";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.BackColor = System.Drawing.Color.Transparent;
            this.lbl_email.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(89, 370);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(54, 17);
            this.lbl_email.TabIndex = 12;
            this.lbl_email.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Birth";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_birth);
            this.panel1.Controls.Add(this.btn_insert);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_id);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_pwd1);
            this.panel1.Controls.Add(this.lbl_email);
            this.panel1.Controls.Add(this.txt_pwd2);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.txt_name);
            this.panel1.Controls.Add(this.lbl_pw);
            this.panel1.Controls.Add(this.txt_email);
            this.panel1.Controls.Add(this.lbl_ID);
            this.panel1.Controls.Add(this.txt_phone);
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 663);
            this.panel1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sign In";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "PW check";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 680);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_Closed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_pwd1;
        private System.Windows.Forms.TextBox txt_pwd2;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.DateTimePicker txt_birth;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_pw;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}