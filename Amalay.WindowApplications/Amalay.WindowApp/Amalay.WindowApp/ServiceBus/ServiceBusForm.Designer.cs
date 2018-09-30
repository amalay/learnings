namespace Amalay.WindowApp
{
    partial class ServiceBusForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTopics = new System.Windows.Forms.ComboBox();
            this.cmbSubscriptions = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnReceiveMessage = new System.Windows.Forms.Button();
            this.btnCreateTopic = new System.Windows.Forms.Button();
            this.btnSendJsonMessage = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbTopics);
            this.groupBox1.Controls.Add(this.cmbSubscriptions);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(68, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1086, 241);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Bus Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Topic Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subscription Name:";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.Location = new System.Drawing.Point(68, 365);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(200, 50);
            this.btnSendMessage.TabIndex = 31;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(805, 79);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "*";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1038, 365);
            this.btnClose.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 50);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(805, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "*";
            // 
            // cmbTopics
            // 
            this.cmbTopics.FormattingEnabled = true;
            this.cmbTopics.Location = new System.Drawing.Point(255, 74);
            this.cmbTopics.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbTopics.Name = "cmbTopics";
            this.cmbTopics.Size = new System.Drawing.Size(545, 33);
            this.cmbTopics.TabIndex = 13;
            this.cmbTopics.SelectedIndexChanged += new System.EventHandler(this.cmbTopics_SelectedIndexChanged);
            // 
            // cmbSubscriptions
            // 
            this.cmbSubscriptions.FormattingEnabled = true;
            this.cmbSubscriptions.Location = new System.Drawing.Point(255, 148);
            this.cmbSubscriptions.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbSubscriptions.Name = "cmbSubscriptions";
            this.cmbSubscriptions.Size = new System.Drawing.Size(545, 33);
            this.cmbSubscriptions.TabIndex = 14;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(427, 165);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 25);
            this.lblMessage.TabIndex = 33;
            // 
            // btnReceiveMessage
            // 
            this.btnReceiveMessage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReceiveMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveMessage.Location = new System.Drawing.Point(304, 365);
            this.btnReceiveMessage.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnReceiveMessage.Name = "btnReceiveMessage";
            this.btnReceiveMessage.Size = new System.Drawing.Size(245, 50);
            this.btnReceiveMessage.TabIndex = 33;
            this.btnReceiveMessage.Text = "Receive Message";
            this.btnReceiveMessage.UseVisualStyleBackColor = true;
            this.btnReceiveMessage.Click += new System.EventHandler(this.btnReceiveMessage_Click);
            // 
            // btnCreateTopic
            // 
            this.btnCreateTopic.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCreateTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTopic.Location = new System.Drawing.Point(597, 365);
            this.btnCreateTopic.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnCreateTopic.Name = "btnCreateTopic";
            this.btnCreateTopic.Size = new System.Drawing.Size(388, 50);
            this.btnCreateTopic.TabIndex = 34;
            this.btnCreateTopic.Text = "Create Topic and Subscription";
            this.btnCreateTopic.UseVisualStyleBackColor = true;
            this.btnCreateTopic.Click += new System.EventHandler(this.btnCreateTopic_Click);
            // 
            // btnSendJsonMessage
            // 
            this.btnSendJsonMessage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendJsonMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendJsonMessage.Location = new System.Drawing.Point(68, 454);
            this.btnSendJsonMessage.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnSendJsonMessage.Name = "btnSendJsonMessage";
            this.btnSendJsonMessage.Size = new System.Drawing.Size(282, 50);
            this.btnSendJsonMessage.TabIndex = 35;
            this.btnSendJsonMessage.Text = "Send Json Message";
            this.btnSendJsonMessage.UseVisualStyleBackColor = true;
            this.btnSendJsonMessage.Click += new System.EventHandler(this.btnSendJsonMessage_Click);
            // 
            // ServiceBusForm
            // 
            this.AcceptButton = this.btnSendMessage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1224, 545);
            this.Controls.Add(this.btnSendJsonMessage);
            this.Controls.Add(this.btnReceiveMessage);
            this.Controls.Add(this.btnCreateTopic);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceBusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Bus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServiceBusForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTopics;
        private System.Windows.Forms.ComboBox cmbSubscriptions;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReceiveMessage;
        private System.Windows.Forms.Button btnCreateTopic;
        private System.Windows.Forms.Button btnSendJsonMessage;
    }
}