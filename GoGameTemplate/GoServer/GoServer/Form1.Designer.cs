
namespace GoServer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBoxPort = new System.Windows.Forms.TextBox();
            this.TxtBoxIP = new System.Windows.Forms.TextBox();
            this.BtnStartServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(4, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 112);
            this.listBox1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "線上使用者";
            // 
            // TxtBoxPort
            // 
            this.TxtBoxPort.Location = new System.Drawing.Point(164, 55);
            this.TxtBoxPort.Name = "TxtBoxPort";
            this.TxtBoxPort.Size = new System.Drawing.Size(100, 22);
            this.TxtBoxPort.TabIndex = 11;
            this.TxtBoxPort.Text = "2025";
            // 
            // TxtBoxIP
            // 
            this.TxtBoxIP.Location = new System.Drawing.Point(164, 18);
            this.TxtBoxIP.Name = "TxtBoxIP";
            this.TxtBoxIP.Size = new System.Drawing.Size(100, 22);
            this.TxtBoxIP.TabIndex = 10;
            this.TxtBoxIP.Text = "127.0.0.1";
            // 
            // BtnStartServer
            // 
            this.BtnStartServer.Location = new System.Drawing.Point(164, 113);
            this.BtnStartServer.Name = "BtnStartServer";
            this.BtnStartServer.Size = new System.Drawing.Size(100, 23);
            this.BtnStartServer.TabIndex = 9;
            this.BtnStartServer.Text = "啟動伺服器";
            this.BtnStartServer.UseVisualStyleBackColor = true;
            this.BtnStartServer.Click += new System.EventHandler(this.BtnStartServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 147);
            this.Controls.Add(this.TxtBoxPort);
            this.Controls.Add(this.TxtBoxIP);
            this.Controls.Add(this.BtnStartServer);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBoxPort;
        private System.Windows.Forms.TextBox TxtBoxIP;
        private System.Windows.Forms.Button BtnStartServer;
    }
}

