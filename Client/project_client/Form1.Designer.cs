namespace project_client
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
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_Username = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.logs_Connection = new System.Windows.Forms.RichTextBox();
            this.label_SPS = new System.Windows.Forms.Label();
            this.label_IF = new System.Windows.Forms.Label();
            this.logs_SPS = new System.Windows.Forms.RichTextBox();
            this.logs_IF = new System.Windows.Forms.RichTextBox();
            this.label_SPS_Message = new System.Windows.Forms.Label();
            this.label_IF_Message = new System.Windows.Forms.Label();
            this.textBox_SPS_Message = new System.Windows.Forms.TextBox();
            this.textBox_IF_Message = new System.Windows.Forms.TextBox();
            this.button_SPS_Send = new System.Windows.Forms.Button();
            this.button_IF_Send = new System.Windows.Forms.Button();
            this.button_SPS_Subscribe = new System.Windows.Forms.Button();
            this.button_SPS_Unsubscribe = new System.Windows.Forms.Button();
            this.button_IF_Subscribe = new System.Windows.Forms.Button();
            this.button_IF_Unsubscribe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(47, 56);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(20, 13);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP:";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(47, 87);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(29, 13);
            this.label_Port.TabIndex = 1;
            this.label_Port.Text = "Port:";
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(47, 116);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(58, 13);
            this.label_Username.TabIndex = 2;
            this.label_Username.Text = "Username:";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(112, 53);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(100, 20);
            this.textBox_IP.TabIndex = 4;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(112, 84);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 20);
            this.textBox_Port.TabIndex = 5;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(112, 113);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(100, 20);
            this.textBox_Username.TabIndex = 6;
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(112, 141);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 7;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(112, 170);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.button_Disconnect.TabIndex = 8;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // logs_Connection
            // 
            this.logs_Connection.Location = new System.Drawing.Point(249, 41);
            this.logs_Connection.Name = "logs_Connection";
            this.logs_Connection.Size = new System.Drawing.Size(309, 152);
            this.logs_Connection.TabIndex = 9;
            this.logs_Connection.Text = "";
            // 
            // label_SPS
            // 
            this.label_SPS.AutoSize = true;
            this.label_SPS.Location = new System.Drawing.Point(141, 240);
            this.label_SPS.Name = "label_SPS";
            this.label_SPS.Size = new System.Drawing.Size(46, 13);
            this.label_SPS.TabIndex = 10;
            this.label_SPS.Text = "SPS101";
            // 
            // label_IF
            // 
            this.label_IF.AutoSize = true;
            this.label_IF.Location = new System.Drawing.Point(428, 240);
            this.label_IF.Name = "label_IF";
            this.label_IF.Size = new System.Drawing.Size(34, 13);
            this.label_IF.TabIndex = 11;
            this.label_IF.Text = "IF100";
            // 
            // logs_SPS
            // 
            this.logs_SPS.Location = new System.Drawing.Point(50, 268);
            this.logs_SPS.Name = "logs_SPS";
            this.logs_SPS.Size = new System.Drawing.Size(228, 186);
            this.logs_SPS.TabIndex = 12;
            this.logs_SPS.Text = "";
            // 
            // logs_IF
            // 
            this.logs_IF.Location = new System.Drawing.Point(330, 268);
            this.logs_IF.Name = "logs_IF";
            this.logs_IF.Size = new System.Drawing.Size(228, 186);
            this.logs_IF.TabIndex = 13;
            this.logs_IF.Text = "";
            // 
            // label_SPS_Message
            // 
            this.label_SPS_Message.AutoSize = true;
            this.label_SPS_Message.Location = new System.Drawing.Point(47, 529);
            this.label_SPS_Message.Name = "label_SPS_Message";
            this.label_SPS_Message.Size = new System.Drawing.Size(53, 13);
            this.label_SPS_Message.TabIndex = 14;
            this.label_SPS_Message.Text = "Message:";
            // 
            // label_IF_Message
            // 
            this.label_IF_Message.AutoSize = true;
            this.label_IF_Message.Location = new System.Drawing.Point(327, 529);
            this.label_IF_Message.Name = "label_IF_Message";
            this.label_IF_Message.Size = new System.Drawing.Size(53, 13);
            this.label_IF_Message.TabIndex = 15;
            this.label_IF_Message.Text = "Message:";
            // 
            // textBox_SPS_Message
            // 
            this.textBox_SPS_Message.Location = new System.Drawing.Point(112, 526);
            this.textBox_SPS_Message.Name = "textBox_SPS_Message";
            this.textBox_SPS_Message.Size = new System.Drawing.Size(166, 20);
            this.textBox_SPS_Message.TabIndex = 16;
            // 
            // textBox_IF_Message
            // 
            this.textBox_IF_Message.Location = new System.Drawing.Point(392, 526);
            this.textBox_IF_Message.Name = "textBox_IF_Message";
            this.textBox_IF_Message.Size = new System.Drawing.Size(166, 20);
            this.textBox_IF_Message.TabIndex = 17;
            // 
            // button_SPS_Send
            // 
            this.button_SPS_Send.Location = new System.Drawing.Point(112, 552);
            this.button_SPS_Send.Name = "button_SPS_Send";
            this.button_SPS_Send.Size = new System.Drawing.Size(75, 23);
            this.button_SPS_Send.TabIndex = 18;
            this.button_SPS_Send.Text = "Send";
            this.button_SPS_Send.UseVisualStyleBackColor = true;
            this.button_SPS_Send.Click += new System.EventHandler(this.button_SPS_Send_Click);
            // 
            // button_IF_Send
            // 
            this.button_IF_Send.Location = new System.Drawing.Point(392, 552);
            this.button_IF_Send.Name = "button_IF_Send";
            this.button_IF_Send.Size = new System.Drawing.Size(75, 23);
            this.button_IF_Send.TabIndex = 19;
            this.button_IF_Send.Text = "Send";
            this.button_IF_Send.UseVisualStyleBackColor = true;
            this.button_IF_Send.Click += new System.EventHandler(this.button_IF_Send_Click);
            // 
            // button_SPS_Subscribe
            // 
            this.button_SPS_Subscribe.Location = new System.Drawing.Point(80, 484);
            this.button_SPS_Subscribe.Name = "button_SPS_Subscribe";
            this.button_SPS_Subscribe.Size = new System.Drawing.Size(75, 23);
            this.button_SPS_Subscribe.TabIndex = 20;
            this.button_SPS_Subscribe.Text = "Subscribe";
            this.button_SPS_Subscribe.UseVisualStyleBackColor = true;
            this.button_SPS_Subscribe.Click += new System.EventHandler(this.button_SPS_Subscribe_Click);
            // 
            // button_SPS_Unsubscribe
            // 
            this.button_SPS_Unsubscribe.Location = new System.Drawing.Point(173, 484);
            this.button_SPS_Unsubscribe.Name = "button_SPS_Unsubscribe";
            this.button_SPS_Unsubscribe.Size = new System.Drawing.Size(75, 23);
            this.button_SPS_Unsubscribe.TabIndex = 21;
            this.button_SPS_Unsubscribe.Text = "Unsubscribe";
            this.button_SPS_Unsubscribe.UseVisualStyleBackColor = true;
            this.button_SPS_Unsubscribe.Click += new System.EventHandler(this.button_SPS_Unsubscribe_Click);
            // 
            // button_IF_Subscribe
            // 
            this.button_IF_Subscribe.Location = new System.Drawing.Point(360, 484);
            this.button_IF_Subscribe.Name = "button_IF_Subscribe";
            this.button_IF_Subscribe.Size = new System.Drawing.Size(75, 23);
            this.button_IF_Subscribe.TabIndex = 22;
            this.button_IF_Subscribe.Text = "Subscribe";
            this.button_IF_Subscribe.UseVisualStyleBackColor = true;
            this.button_IF_Subscribe.Click += new System.EventHandler(this.button_IF_Subscribe_Click);
            // 
            // button_IF_Unsubscribe
            // 
            this.button_IF_Unsubscribe.Location = new System.Drawing.Point(456, 484);
            this.button_IF_Unsubscribe.Name = "button_IF_Unsubscribe";
            this.button_IF_Unsubscribe.Size = new System.Drawing.Size(75, 23);
            this.button_IF_Unsubscribe.TabIndex = 23;
            this.button_IF_Unsubscribe.Text = "Unsubscribe";
            this.button_IF_Unsubscribe.UseVisualStyleBackColor = true;
            this.button_IF_Unsubscribe.Click += new System.EventHandler(this.button_IF_Unsubscribe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 624);
            this.Controls.Add(this.button_IF_Unsubscribe);
            this.Controls.Add(this.button_IF_Subscribe);
            this.Controls.Add(this.button_SPS_Unsubscribe);
            this.Controls.Add(this.button_SPS_Subscribe);
            this.Controls.Add(this.button_IF_Send);
            this.Controls.Add(this.button_SPS_Send);
            this.Controls.Add(this.textBox_IF_Message);
            this.Controls.Add(this.textBox_SPS_Message);
            this.Controls.Add(this.label_IF_Message);
            this.Controls.Add(this.label_SPS_Message);
            this.Controls.Add(this.logs_IF);
            this.Controls.Add(this.logs_SPS);
            this.Controls.Add(this.label_IF);
            this.Controls.Add(this.label_SPS);
            this.Controls.Add(this.logs_Connection);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label_Username);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.label_IP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.RichTextBox logs_Connection;
        private System.Windows.Forms.Label label_SPS;
        private System.Windows.Forms.Label label_IF;
        private System.Windows.Forms.RichTextBox logs_SPS;
        private System.Windows.Forms.RichTextBox logs_IF;
        private System.Windows.Forms.Label label_SPS_Message;
        private System.Windows.Forms.Label label_IF_Message;
        private System.Windows.Forms.TextBox textBox_SPS_Message;
        private System.Windows.Forms.TextBox textBox_IF_Message;
        private System.Windows.Forms.Button button_SPS_Send;
        private System.Windows.Forms.Button button_IF_Send;
        private System.Windows.Forms.Button button_SPS_Subscribe;
        private System.Windows.Forms.Button button_SPS_Unsubscribe;
        private System.Windows.Forms.Button button_IF_Subscribe;
        private System.Windows.Forms.Button button_IF_Unsubscribe;
    }
}

