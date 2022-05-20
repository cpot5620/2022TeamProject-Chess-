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
            this.SuspendLayout();
            // 
            // btn_insert
            // 
            this.btn_insert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_insert.Location = new System.Drawing.Point(0, 416);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(355, 34);
            this.btn_insert.TabIndex = 0;
            this.btn_insert.Text = "확인";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(76, 59);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(251, 21);
            this.txt_id.TabIndex = 1;
            // 
            // txt_pwd1
            // 
            this.txt_pwd1.Location = new System.Drawing.Point(76, 106);
            this.txt_pwd1.Name = "txt_pwd1";
            this.txt_pwd1.PasswordChar = '●';
            this.txt_pwd1.Size = new System.Drawing.Size(251, 21);
            this.txt_pwd1.TabIndex = 2;
            // 
            // txt_pwd2
            // 
            this.txt_pwd2.Location = new System.Drawing.Point(76, 152);
            this.txt_pwd2.Name = "txt_pwd2";
            this.txt_pwd2.PasswordChar = '●';
            this.txt_pwd2.Size = new System.Drawing.Size(251, 21);
            this.txt_pwd2.TabIndex = 3;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(76, 199);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(251, 21);
            this.txt_name.TabIndex = 4;
            this.txt_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btn_name_KeyPress);
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(76, 252);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(251, 21);
            this.txt_email.TabIndex = 5;
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(76, 300);
            this.txt_phone.MaxLength = 11;
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(251, 21);
            this.txt_phone.TabIndex = 6;
            this.txt_phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btn_phone_KeyPress);
            // 
            // txt_birth
            // 
            this.txt_birth.Location = new System.Drawing.Point(78, 356);
            this.txt_birth.Name = "txt_birth";
            this.txt_birth.Size = new System.Drawing.Size(249, 21);
            this.txt_birth.TabIndex = 8;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(31, 62);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(16, 12);
            this.lbl_ID.TabIndex = 9;
            this.lbl_ID.Text = "ID";
            // 
            // lbl_pw
            // 
            this.lbl_pw.AutoSize = true;
            this.lbl_pw.Location = new System.Drawing.Point(31, 134);
            this.lbl_pw.Name = "lbl_pw";
            this.lbl_pw.Size = new System.Drawing.Size(23, 12);
            this.lbl_pw.TabIndex = 10;
            this.lbl_pw.Text = "PW";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(22, 202);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(39, 12);
            this.lbl_name.TabIndex = 11;
            this.lbl_name.Text = "Name";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(24, 255);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(37, 12);
            this.lbl_email.TabIndex = 12;
            this.lbl_email.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Birth";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_pw);
            this.Controls.Add(this.lbl_ID);
            this.Controls.Add(this.txt_birth);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_pwd2);
            this.Controls.Add(this.txt_pwd1);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.btn_insert);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}