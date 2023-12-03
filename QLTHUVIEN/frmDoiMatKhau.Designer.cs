namespace QLTHUVIEN
{
    partial class frmdoimk
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
            this.lblmkcu = new System.Windows.Forms.Label();
            this.lblmkmoi = new System.Windows.Forms.Label();
            this.lblnhaplaimkmoi = new System.Windows.Forms.Label();
            this.txtmkcu = new System.Windows.Forms.TextBox();
            this.txtmkmoi = new System.Windows.Forms.TextBox();
            this.txtnhaplaimkmoi = new System.Windows.Forms.TextBox();
            this.btndoimk = new System.Windows.Forms.Button();
            this.btnQuaylai = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblmkcu
            // 
            this.lblmkcu.AutoSize = true;
            this.lblmkcu.Location = new System.Drawing.Point(227, 165);
            this.lblmkcu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmkcu.Name = "lblmkcu";
            this.lblmkcu.Size = new System.Drawing.Size(100, 18);
            this.lblmkcu.TabIndex = 0;
            this.lblmkcu.Text = "Mật khẩu cũ";
            // 
            // lblmkmoi
            // 
            this.lblmkmoi.AutoSize = true;
            this.lblmkmoi.Location = new System.Drawing.Point(227, 242);
            this.lblmkmoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmkmoi.Name = "lblmkmoi";
            this.lblmkmoi.Size = new System.Drawing.Size(110, 18);
            this.lblmkmoi.TabIndex = 1;
            this.lblmkmoi.Text = "Mật khẩu mới";
            // 
            // lblnhaplaimkmoi
            // 
            this.lblnhaplaimkmoi.AutoSize = true;
            this.lblnhaplaimkmoi.Location = new System.Drawing.Point(227, 325);
            this.lblnhaplaimkmoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnhaplaimkmoi.Name = "lblnhaplaimkmoi";
            this.lblnhaplaimkmoi.Size = new System.Drawing.Size(176, 18);
            this.lblnhaplaimkmoi.TabIndex = 2;
            this.lblnhaplaimkmoi.Text = "Nhập lại mật khẩu mới";
            // 
            // txtmkcu
            // 
            this.txtmkcu.Location = new System.Drawing.Point(543, 175);
            this.txtmkcu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtmkcu.Name = "txtmkcu";
            this.txtmkcu.PasswordChar = '*';
            this.txtmkcu.Size = new System.Drawing.Size(151, 24);
            this.txtmkcu.TabIndex = 3;
            // 
            // txtmkmoi
            // 
            this.txtmkmoi.Location = new System.Drawing.Point(543, 255);
            this.txtmkmoi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtmkmoi.Name = "txtmkmoi";
            this.txtmkmoi.PasswordChar = '*';
            this.txtmkmoi.Size = new System.Drawing.Size(151, 24);
            this.txtmkmoi.TabIndex = 4;
            // 
            // txtnhaplaimkmoi
            // 
            this.txtnhaplaimkmoi.Location = new System.Drawing.Point(543, 325);
            this.txtnhaplaimkmoi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtnhaplaimkmoi.Name = "txtnhaplaimkmoi";
            this.txtnhaplaimkmoi.PasswordChar = '*';
            this.txtnhaplaimkmoi.Size = new System.Drawing.Size(151, 24);
            this.txtnhaplaimkmoi.TabIndex = 5;
            // 
            // btndoimk
            // 
            this.btndoimk.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btndoimk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoimk.Location = new System.Drawing.Point(221, 428);
            this.btndoimk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btndoimk.Name = "btndoimk";
            this.btndoimk.Size = new System.Drawing.Size(168, 46);
            this.btndoimk.TabIndex = 6;
            this.btndoimk.Text = "ĐỔI MẬT KHẨU";
            this.btndoimk.UseVisualStyleBackColor = false;
            this.btndoimk.Click += new System.EventHandler(this.btndoimk_Click);
            // 
            // btnQuaylai
            // 
            this.btnQuaylai.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuaylai.Location = new System.Drawing.Point(636, 428);
            this.btnQuaylai.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQuaylai.Name = "btnQuaylai";
            this.btnQuaylai.Size = new System.Drawing.Size(168, 46);
            this.btnQuaylai.TabIndex = 8;
            this.btnQuaylai.Text = "QUAY LẠI";
            this.btnQuaylai.UseVisualStyleBackColor = false;
            this.btnQuaylai.Click += new System.EventHandler(this.btnQuaylai_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(543, 117);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(151, 24);
            this.txtUser.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "USER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 31);
            this.label2.TabIndex = 14;
            this.label2.Text = "CẬP NHẬT MẬT KHẨU";
            // 
            // frmdoimk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1026, 568);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuaylai);
            this.Controls.Add(this.btndoimk);
            this.Controls.Add(this.txtnhaplaimkmoi);
            this.Controls.Add(this.txtmkmoi);
            this.Controls.Add(this.txtmkcu);
            this.Controls.Add(this.lblnhaplaimkmoi);
            this.Controls.Add(this.lblmkmoi);
            this.Controls.Add(this.lblmkcu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmdoimk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi_Mật_Khẩu";
            this.Load += new System.EventHandler(this.frmdoimk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmkcu;
        private System.Windows.Forms.Label lblmkmoi;
        private System.Windows.Forms.Label lblnhaplaimkmoi;
        private System.Windows.Forms.TextBox txtmkcu;
        private System.Windows.Forms.TextBox txtmkmoi;
        private System.Windows.Forms.TextBox txtnhaplaimkmoi;
        private System.Windows.Forms.Button btndoimk;
        private System.Windows.Forms.Button btnQuaylai;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}