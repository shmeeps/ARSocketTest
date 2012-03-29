namespace CAVESocketTest
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
            this.forwardButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.takeOffButton = new System.Windows.Forms.Button();
            this.emergencyButton = new System.Windows.Forms.Button();
            this.flatTrimButton = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.connectedStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.landButton = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(106, 12);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 0;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(12, 42);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(75, 23);
            this.leftButton.TabIndex = 1;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(106, 42);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Backward";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(197, 42);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(75, 23);
            this.rightButton.TabIndex = 3;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(197, 71);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(75, 23);
            this.upButton.TabIndex = 4;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(197, 100);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(75, 23);
            this.downButton.TabIndex = 5;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // takeOffButton
            // 
            this.takeOffButton.Location = new System.Drawing.Point(12, 71);
            this.takeOffButton.Name = "takeOffButton";
            this.takeOffButton.Size = new System.Drawing.Size(169, 23);
            this.takeOffButton.TabIndex = 6;
            this.takeOffButton.Text = "Take Off";
            this.takeOffButton.UseVisualStyleBackColor = true;
            this.takeOffButton.Click += new System.EventHandler(this.takeOffButton_Click);
            // 
            // emergencyButton
            // 
            this.emergencyButton.Location = new System.Drawing.Point(12, 129);
            this.emergencyButton.Name = "emergencyButton";
            this.emergencyButton.Size = new System.Drawing.Size(169, 121);
            this.emergencyButton.TabIndex = 7;
            this.emergencyButton.Text = "Emergency";
            this.emergencyButton.UseVisualStyleBackColor = true;
            this.emergencyButton.Click += new System.EventHandler(this.emergencyButton_Click);
            // 
            // flatTrimButton
            // 
            this.flatTrimButton.Location = new System.Drawing.Point(197, 129);
            this.flatTrimButton.Name = "flatTrimButton";
            this.flatTrimButton.Size = new System.Drawing.Size(75, 121);
            this.flatTrimButton.TabIndex = 8;
            this.flatTrimButton.Text = "Flat Trim";
            this.flatTrimButton.UseVisualStyleBackColor = true;
            this.flatTrimButton.Click += new System.EventHandler(this.flatTrimButton_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 285);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(260, 195);
            this.output.TabIndex = 9;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 10;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(197, 12);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 11;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectedStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 485);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // connectedStatus
            // 
            this.connectedStatus.Name = "connectedStatus";
            this.connectedStatus.Size = new System.Drawing.Size(79, 17);
            this.connectedStatus.Text = "Disconnected";
            // 
            // landButton
            // 
            this.landButton.Location = new System.Drawing.Point(12, 100);
            this.landButton.Name = "landButton";
            this.landButton.Size = new System.Drawing.Size(169, 23);
            this.landButton.TabIndex = 13;
            this.landButton.Text = "Land";
            this.landButton.UseVisualStyleBackColor = true;
            this.landButton.Click += new System.EventHandler(this.landButton_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(12, 256);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(260, 23);
            this.test.TabIndex = 14;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 507);
            this.Controls.Add(this.test);
            this.Controls.Add(this.landButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.output);
            this.Controls.Add(this.flatTrimButton);
            this.Controls.Add(this.emergencyButton);
            this.Controls.Add(this.takeOffButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.forwardButton);
            this.Name = "Form1";
            this.Text = "CAVESocketTest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button takeOffButton;
        private System.Windows.Forms.Button emergencyButton;
        private System.Windows.Forms.Button flatTrimButton;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel connectedStatus;
        private System.Windows.Forms.Button landButton;
        private System.Windows.Forms.Button test;
    }
}

