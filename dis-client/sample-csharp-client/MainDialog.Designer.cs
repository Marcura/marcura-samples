namespace Marcura.Dis.Client.Sample
{
    partial class MainDialog
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
            this.btnGetPortCallStatus = new System.Windows.Forms.Button();
            this.txtPrincipalId = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblIur = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtInterfaceUniqueRef = new System.Windows.Forms.TextBox();
            this.btnCreatePortCall = new System.Windows.Forms.Button();
            this.btnGetProforma = new System.Windows.Forms.Button();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.lblRequest = new System.Windows.Forms.Label();
            this.lblResponse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetPortCallStatus
            // 
            this.btnGetPortCallStatus.Location = new System.Drawing.Point(159, 107);
            this.btnGetPortCallStatus.Name = "btnGetPortCallStatus";
            this.btnGetPortCallStatus.Size = new System.Drawing.Size(124, 23);
            this.btnGetPortCallStatus.TabIndex = 0;
            this.btnGetPortCallStatus.Text = "Get Port Call Status";
            this.btnGetPortCallStatus.UseVisualStyleBackColor = true;
            this.btnGetPortCallStatus.Click += new System.EventHandler(this.btnGetPortCallStatus_Click);
            // 
            // txtPrincipalId
            // 
            this.txtPrincipalId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrincipalId.Enabled = false;
            this.txtPrincipalId.Location = new System.Drawing.Point(159, 55);
            this.txtPrincipalId.Name = "txtPrincipalId";
            this.txtPrincipalId.Size = new System.Drawing.Size(430, 20);
            this.txtPrincipalId.TabIndex = 67;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(14, 59);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(59, 13);
            this.lblFullName.TabIndex = 69;
            this.lblFullName.Text = "Principal Id";
            // 
            // lblIur
            // 
            this.lblIur.AutoSize = true;
            this.lblIur.Location = new System.Drawing.Point(14, 84);
            this.lblIur.Name = "lblIur";
            this.lblIur.Size = new System.Drawing.Size(139, 13);
            this.lblIur.TabIndex = 68;
            this.lblIur.Text = "Interface Unique Reference";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(14, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(385, 13);
            this.lblInfo.TabIndex = 66;
            this.lblInfo.Text = "Provide Princiapl Id as well as Interface Unique Reference and send the request";
            // 
            // txtInterfaceUniqueRef
            // 
            this.txtInterfaceUniqueRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInterfaceUniqueRef.Location = new System.Drawing.Point(159, 81);
            this.txtInterfaceUniqueRef.Name = "txtInterfaceUniqueRef";
            this.txtInterfaceUniqueRef.Size = new System.Drawing.Size(430, 20);
            this.txtInterfaceUniqueRef.TabIndex = 70;
            // 
            // btnCreatePortCall
            // 
            this.btnCreatePortCall.Location = new System.Drawing.Point(311, 107);
            this.btnCreatePortCall.Name = "btnCreatePortCall";
            this.btnCreatePortCall.Size = new System.Drawing.Size(124, 23);
            this.btnCreatePortCall.TabIndex = 71;
            this.btnCreatePortCall.Text = "Create Port Call";
            this.btnCreatePortCall.UseVisualStyleBackColor = true;
            this.btnCreatePortCall.Click += new System.EventHandler(this.btnCreatePortCall_Click);
            // 
            // btnGetProforma
            // 
            this.btnGetProforma.Location = new System.Drawing.Point(472, 107);
            this.btnGetProforma.Name = "btnGetProforma";
            this.btnGetProforma.Size = new System.Drawing.Size(118, 23);
            this.btnGetProforma.TabIndex = 72;
            this.btnGetProforma.Text = "Get Proforma";
            this.btnGetProforma.UseVisualStyleBackColor = true;
            this.btnGetProforma.Click += new System.EventHandler(this.btnGetProforma_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(17, 190);
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRequest.Size = new System.Drawing.Size(279, 396);
            this.txtRequest.TabIndex = 73;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(318, 190);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(279, 396);
            this.txtResponse.TabIndex = 74;
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(17, 171);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(47, 13);
            this.lblRequest.TabIndex = 75;
            this.lblRequest.Text = "Request";
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(318, 170);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(55, 13);
            this.lblResponse.TabIndex = 76;
            this.lblResponse.Text = "Response";
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 624);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.lblRequest);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.btnGetProforma);
            this.Controls.Add(this.btnCreatePortCall);
            this.Controls.Add(this.txtInterfaceUniqueRef);
            this.Controls.Add(this.txtPrincipalId);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblIur);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnGetPortCallStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dis Client Sample";
            this.Shown += new System.EventHandler(this.MainDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetPortCallStatus;
        private System.Windows.Forms.TextBox txtPrincipalId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblIur;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtInterfaceUniqueRef;
        private System.Windows.Forms.Button btnCreatePortCall;
        private System.Windows.Forms.Button btnGetProforma;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblResponse;
    }
}

