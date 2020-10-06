namespace PortScaner
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
            this.helpButton = new System.Windows.Forms.Button();
            this.inputTextForm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.listOfPorts = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.White;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.helpButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.helpButton.Location = new System.Drawing.Point(828, 7);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 0;
            this.helpButton.Text = "HELP";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputTextForm
            // 
            this.inputTextForm.Location = new System.Drawing.Point(81, 9);
            this.inputTextForm.Name = "inputTextForm";
            this.inputTextForm.Size = new System.Drawing.Size(275, 20);
            this.inputTextForm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input port(s):";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(362, 7);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // listOfPorts
            // 
            this.listOfPorts.FormattingEnabled = true;
            this.listOfPorts.Location = new System.Drawing.Point(16, 44);
            this.listOfPorts.Name = "listOfPorts";
            this.listOfPorts.Size = new System.Drawing.Size(887, 173);
            this.listOfPorts.TabIndex = 4;
            this.listOfPorts.SelectedIndexChanged += new System.EventHandler(this.listOfPorts_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(16, 223);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(887, 214);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 449);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listOfPorts);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputTextForm);
            this.Controls.Add(this.helpButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Port Scanner v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.TextBox inputTextForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ListBox listOfPorts;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

