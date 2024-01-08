namespace project_server
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
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.button_Listen = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.logs_Connected_Clients = new System.Windows.Forms.RichTextBox();
            this.logs_IF_Subscribers = new System.Windows.Forms.RichTextBox();
            this.logs_SPS_Subscribers = new System.Windows.Forms.RichTextBox();
            this.label_Connected_Clients = new System.Windows.Forms.Label();
            this.label_SPS_Subscribers = new System.Windows.Forms.Label();
            this.label_IF_Subscribers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(32, 65);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(29, 13);
            this.label_Port.TabIndex = 0;
            this.label_Port.Text = "Port:";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(67, 62);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 20);
            this.textBox_Port.TabIndex = 1;
            // 
            // button_Listen
            // 
            this.button_Listen.Location = new System.Drawing.Point(67, 88);
            this.button_Listen.Name = "button_Listen";
            this.button_Listen.Size = new System.Drawing.Size(75, 23);
            this.button_Listen.TabIndex = 2;
            this.button_Listen.Text = "Listen";
            this.button_Listen.UseVisualStyleBackColor = true;
            this.button_Listen.Click += new System.EventHandler(this.button_Listen_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(35, 140);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(530, 196);
            this.logs.TabIndex = 3;
            this.logs.Text = "";
            // 
            // logs_Connected_Clients
            // 
            this.logs_Connected_Clients.Location = new System.Drawing.Point(35, 409);
            this.logs_Connected_Clients.Name = "logs_Connected_Clients";
            this.logs_Connected_Clients.Size = new System.Drawing.Size(145, 166);
            this.logs_Connected_Clients.TabIndex = 4;
            this.logs_Connected_Clients.Text = "";
            // 
            // logs_IF_Subscribers
            // 
            this.logs_IF_Subscribers.Location = new System.Drawing.Point(420, 409);
            this.logs_IF_Subscribers.Name = "logs_IF_Subscribers";
            this.logs_IF_Subscribers.Size = new System.Drawing.Size(145, 166);
            this.logs_IF_Subscribers.TabIndex = 5;
            this.logs_IF_Subscribers.Text = "";
            // 
            // logs_SPS_Subscribers
            // 
            this.logs_SPS_Subscribers.Location = new System.Drawing.Point(227, 409);
            this.logs_SPS_Subscribers.Name = "logs_SPS_Subscribers";
            this.logs_SPS_Subscribers.Size = new System.Drawing.Size(145, 166);
            this.logs_SPS_Subscribers.TabIndex = 6;
            this.logs_SPS_Subscribers.Text = "";
            // 
            // label_Connected_Clients
            // 
            this.label_Connected_Clients.AutoSize = true;
            this.label_Connected_Clients.Location = new System.Drawing.Point(32, 382);
            this.label_Connected_Clients.Name = "label_Connected_Clients";
            this.label_Connected_Clients.Size = new System.Drawing.Size(96, 13);
            this.label_Connected_Clients.TabIndex = 7;
            this.label_Connected_Clients.Text = "Connected Clients:";
            // 
            // label_SPS_Subscribers
            // 
            this.label_SPS_Subscribers.AutoSize = true;
            this.label_SPS_Subscribers.Location = new System.Drawing.Point(224, 382);
            this.label_SPS_Subscribers.Name = "label_SPS_Subscribers";
            this.label_SPS_Subscribers.Size = new System.Drawing.Size(110, 13);
            this.label_SPS_Subscribers.TabIndex = 8;
            this.label_SPS_Subscribers.Text = "SPS 101 Subscribers:";
            // 
            // label_IF_Subscribers
            // 
            this.label_IF_Subscribers.AutoSize = true;
            this.label_IF_Subscribers.Location = new System.Drawing.Point(417, 382);
            this.label_IF_Subscribers.Name = "label_IF_Subscribers";
            this.label_IF_Subscribers.Size = new System.Drawing.Size(98, 13);
            this.label_IF_Subscribers.TabIndex = 9;
            this.label_IF_Subscribers.Text = "IF 100 Subscribers:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 624);
            this.Controls.Add(this.label_IF_Subscribers);
            this.Controls.Add(this.label_SPS_Subscribers);
            this.Controls.Add(this.label_Connected_Clients);
            this.Controls.Add(this.logs_SPS_Subscribers);
            this.Controls.Add(this.logs_IF_Subscribers);
            this.Controls.Add(this.logs_Connected_Clients);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_Listen);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label_Port);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button button_Listen;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.RichTextBox logs_Connected_Clients;
        private System.Windows.Forms.RichTextBox logs_IF_Subscribers;
        private System.Windows.Forms.RichTextBox logs_SPS_Subscribers;
        private System.Windows.Forms.Label label_Connected_Clients;
        private System.Windows.Forms.Label label_SPS_Subscribers;
        private System.Windows.Forms.Label label_IF_Subscribers;
    }
}

