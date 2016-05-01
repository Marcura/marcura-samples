namespace WindowsFormsApplication1
{
    partial class frmDispClient
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnPoll = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPrincipalId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(55, 338);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnPoll
            // 
            this.btnPoll.Enabled = false;
            this.btnPoll.Location = new System.Drawing.Point(304, 338);
            this.btnPoll.Name = "btnPoll";
            this.btnPoll.Size = new System.Drawing.Size(75, 23);
            this.btnPoll.TabIndex = 1;
            this.btnPoll.Text = "Poll";
            this.btnPoll.UseVisualStyleBackColor = true;
            this.btnPoll.Click += new System.EventHandler(this.btnPoll_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(55, 114);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(324, 190);
            this.txtConsole.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(55, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(155, 20);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(55, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(155, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "password";
            // 
            // txtPrincipalId
            // 
            this.txtPrincipalId.Location = new System.Drawing.Point(247, 28);
            this.txtPrincipalId.Name = "txtPrincipalId";
            this.txtPrincipalId.Size = new System.Drawing.Size(131, 20);
            this.txtPrincipalId.TabIndex = 5;
            this.txtPrincipalId.Text = "principalId";
            // 
            // frmDispClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 383);
            this.Controls.Add(this.txtPrincipalId);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnPoll);
            this.Controls.Add(this.btnLogin);
            this.Name = "frmDispClient";
            this.Text = "DISP Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnPoll;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPrincipalId;
    }
}

