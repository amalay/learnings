namespace Amalay.WindowApp
{
    partial class ChildForm
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblInputText = new System.Windows.Forms.Label();
            this.lblOutputText = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(470, 376);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 25);
            this.lblMessage.TabIndex = 35;
            // 
            // lblInputText
            // 
            this.lblInputText.AutoSize = true;
            this.lblInputText.Location = new System.Drawing.Point(46, 72);
            this.lblInputText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblInputText.Name = "lblInputText";
            this.lblInputText.Size = new System.Drawing.Size(55, 25);
            this.lblInputText.TabIndex = 36;
            this.lblInputText.Text = "Input";
            // 
            // lblOutputText
            // 
            this.lblOutputText.AutoSize = true;
            this.lblOutputText.Location = new System.Drawing.Point(46, 189);
            this.lblOutputText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblOutputText.Name = "lblOutputText";
            this.lblOutputText.Size = new System.Drawing.Size(71, 25);
            this.lblOutputText.TabIndex = 37;
            this.lblOutputText.Text = "Output";
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(51, 528);
            this.btnClear.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(200, 50);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(415, 528);
            this.btnClose.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 50);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(46, 120);
            this.lblInput.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(74, 25);
            this.lblInput.TabIndex = 40;
            this.lblInput.Text = "lblInput";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(46, 237);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(90, 25);
            this.lblOutput.TabIndex = 41;
            this.lblOutput.Text = "lblOutput";
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 655);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.lblOutputText);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChildForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Child";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.Label lblOutputText;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
    }
}