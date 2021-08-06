namespace Enigma.Frames
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputTextArea = new System.Windows.Forms.TextBox();
            this.outputTextArea = new System.Windows.Forms.TextBox();
            this.topMenuBar = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber3 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber4 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber5 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber6 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber7 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber8 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber9 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotorsNumber10 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteTextToInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyTextFromInputAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureTheMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptAMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptAMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.whatIsThisAndHowItWorksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatTheSimulatorDoesAndDoesntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTextArea
            // 
            this.inputTextArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextArea.BackColor = System.Drawing.Color.White;
            this.inputTextArea.ForeColor = System.Drawing.Color.Red;
            this.inputTextArea.Location = new System.Drawing.Point(63, 632);
            this.inputTextArea.Name = "inputTextArea";
            this.inputTextArea.ReadOnly = true;
            this.inputTextArea.Size = new System.Drawing.Size(1039, 20);
            this.inputTextArea.TabIndex = 0;
            this.inputTextArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputTextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextArea_KeyDown);
            // 
            // outputTextArea
            // 
            this.outputTextArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextArea.BackColor = System.Drawing.Color.White;
            this.outputTextArea.ForeColor = System.Drawing.Color.Blue;
            this.outputTextArea.Location = new System.Drawing.Point(63, 606);
            this.outputTextArea.Name = "outputTextArea";
            this.outputTextArea.ReadOnly = true;
            this.outputTextArea.Size = new System.Drawing.Size(1039, 20);
            this.outputTextArea.TabIndex = 1;
            this.outputTextArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // topMenuBar
            // 
            this.topMenuBar.BackColor = System.Drawing.Color.PowderBlue;
            this.topMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
            this.clipboardToolStripMenuItem,
            this.howToToolStripMenuItem});
            this.topMenuBar.Location = new System.Drawing.Point(0, 0);
            this.topMenuBar.Name = "topMenuBar";
            this.topMenuBar.Size = new System.Drawing.Size(1184, 24);
            this.topMenuBar.TabIndex = 2;
            this.topMenuBar.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.resetToolStripMenuItem1});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.actionsToolStripMenuItem.Text = "Machine";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotorsNumber1,
            this.rotorsNumber2,
            this.rotorsNumber3,
            this.rotorsNumber4,
            this.rotorsNumber5,
            this.rotorsNumber6,
            this.rotorsNumber7,
            this.rotorsNumber8,
            this.rotorsNumber9,
            this.rotorsNumber10});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem2.Text = "Number of rotors";
            // 
            // rotorsNumber1
            // 
            this.rotorsNumber1.CheckOnClick = true;
            this.rotorsNumber1.Name = "rotorsNumber1";
            this.rotorsNumber1.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber1.Text = "1";
            this.rotorsNumber1.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber2
            // 
            this.rotorsNumber2.CheckOnClick = true;
            this.rotorsNumber2.Name = "rotorsNumber2";
            this.rotorsNumber2.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber2.Text = "2";
            this.rotorsNumber2.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber3
            // 
            this.rotorsNumber3.Checked = true;
            this.rotorsNumber3.CheckOnClick = true;
            this.rotorsNumber3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rotorsNumber3.Name = "rotorsNumber3";
            this.rotorsNumber3.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber3.Text = "3";
            this.rotorsNumber3.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber4
            // 
            this.rotorsNumber4.CheckOnClick = true;
            this.rotorsNumber4.Name = "rotorsNumber4";
            this.rotorsNumber4.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber4.Text = "4";
            this.rotorsNumber4.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber5
            // 
            this.rotorsNumber5.CheckOnClick = true;
            this.rotorsNumber5.Name = "rotorsNumber5";
            this.rotorsNumber5.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber5.Text = "5";
            this.rotorsNumber5.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber6
            // 
            this.rotorsNumber6.CheckOnClick = true;
            this.rotorsNumber6.Name = "rotorsNumber6";
            this.rotorsNumber6.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber6.Text = "6";
            this.rotorsNumber6.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber7
            // 
            this.rotorsNumber7.CheckOnClick = true;
            this.rotorsNumber7.Name = "rotorsNumber7";
            this.rotorsNumber7.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber7.Text = "7";
            this.rotorsNumber7.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber8
            // 
            this.rotorsNumber8.CheckOnClick = true;
            this.rotorsNumber8.Name = "rotorsNumber8";
            this.rotorsNumber8.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber8.Text = "8";
            this.rotorsNumber8.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber9
            // 
            this.rotorsNumber9.CheckOnClick = true;
            this.rotorsNumber9.Name = "rotorsNumber9";
            this.rotorsNumber9.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber9.Text = "9";
            this.rotorsNumber9.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // rotorsNumber10
            // 
            this.rotorsNumber10.CheckOnClick = true;
            this.rotorsNumber10.Name = "rotorsNumber10";
            this.rotorsNumber10.Size = new System.Drawing.Size(86, 22);
            this.rotorsNumber10.Text = "10";
            this.rotorsNumber10.Click += new System.EventHandler(this.GenericRotorsNumberClick);
            // 
            // resetToolStripMenuItem1
            // 
            this.resetToolStripMenuItem1.Name = "resetToolStripMenuItem1";
            this.resetToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.resetToolStripMenuItem1.Text = "Reset";
            this.resetToolStripMenuItem1.Click += new System.EventHandler(this.resetToolStripMenuItem1_Click);
            // 
            // clipboardToolStripMenuItem
            // 
            this.clipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteTextToInputToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyTextFromInputAreaToolStripMenuItem,
            this.cToolStripMenuItem});
            this.clipboardToolStripMenuItem.Name = "clipboardToolStripMenuItem";
            this.clipboardToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.clipboardToolStripMenuItem.Text = "Clipboard";
            // 
            // pasteTextToInputToolStripMenuItem
            // 
            this.pasteTextToInputToolStripMenuItem.Name = "pasteTextToInputToolStripMenuItem";
            this.pasteTextToInputToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.pasteTextToInputToolStripMenuItem.Text = "Paste text into Input Area";
            this.pasteTextToInputToolStripMenuItem.Click += new System.EventHandler(this.pasteTextToInputToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // copyTextFromInputAreaToolStripMenuItem
            // 
            this.copyTextFromInputAreaToolStripMenuItem.Name = "copyTextFromInputAreaToolStripMenuItem";
            this.copyTextFromInputAreaToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.copyTextFromInputAreaToolStripMenuItem.Text = "Copy text from Input Area";
            this.copyTextFromInputAreaToolStripMenuItem.Click += new System.EventHandler(this.copyTextFromInputAreaToolStripMenuItem_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.cToolStripMenuItem.Text = "Copy text from Output Area";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // howToToolStripMenuItem
            // 
            this.howToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureTheMachineToolStripMenuItem,
            this.encryptAMessageToolStripMenuItem,
            this.decryptAMessageToolStripMenuItem,
            this.whatIsThisAndHowItWorksToolStripMenuItem,
            this.whatTheSimulatorDoesAndDoesntToolStripMenuItem});
            this.howToToolStripMenuItem.Name = "howToToolStripMenuItem";
            this.howToToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.howToToolStripMenuItem.Text = "How to ...";
            // 
            // configureTheMachineToolStripMenuItem
            // 
            this.configureTheMachineToolStripMenuItem.Name = "configureTheMachineToolStripMenuItem";
            this.configureTheMachineToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.configureTheMachineToolStripMenuItem.Text = "Setup the machine";
            this.configureTheMachineToolStripMenuItem.Click += new System.EventHandler(this.configureTheMachineToolStripMenuItem_Click);
            // 
            // encryptAMessageToolStripMenuItem
            // 
            this.encryptAMessageToolStripMenuItem.Name = "encryptAMessageToolStripMenuItem";
            this.encryptAMessageToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.encryptAMessageToolStripMenuItem.Text = "Encrypt a message";
            this.encryptAMessageToolStripMenuItem.Click += new System.EventHandler(this.encryptAMessageToolStripMenuItem_Click);
            // 
            // decryptAMessageToolStripMenuItem
            // 
            this.decryptAMessageToolStripMenuItem.Name = "decryptAMessageToolStripMenuItem";
            this.decryptAMessageToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.decryptAMessageToolStripMenuItem.Text = "Decrypt a message";
            this.decryptAMessageToolStripMenuItem.Click += new System.EventHandler(this.decryptAMessageToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 609);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(20, 635);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input :";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1108, 631);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // whatIsThisAndHowItWorksToolStripMenuItem
            // 
            this.whatIsThisAndHowItWorksToolStripMenuItem.Name = "whatIsThisAndHowItWorksToolStripMenuItem";
            this.whatIsThisAndHowItWorksToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.whatIsThisAndHowItWorksToolStripMenuItem.Text = "What is this and how it works ?";
            this.whatIsThisAndHowItWorksToolStripMenuItem.Click += new System.EventHandler(this.whatIsThisAndHowItWorksToolStripMenuItem_Click);
            // 
            // whatTheSimulatorDoesAndDoesntToolStripMenuItem
            // 
            this.whatTheSimulatorDoesAndDoesntToolStripMenuItem.Name = "whatTheSimulatorDoesAndDoesntToolStripMenuItem";
            this.whatTheSimulatorDoesAndDoesntToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.whatTheSimulatorDoesAndDoesntToolStripMenuItem.Text = "What the simulator does and doesn\'t";
            this.whatTheSimulatorDoesAndDoesntToolStripMenuItem.Click += new System.EventHandler(this.whatTheSimulatorDoesAndDoesntToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1184, 664);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTextArea);
            this.Controls.Add(this.inputTextArea);
            this.Controls.Add(this.topMenuBar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenuBar;
            this.MaximumSize = new System.Drawing.Size(1200, 702);
            this.MinimumSize = new System.Drawing.Size(16, 702);
            this.Name = "MainForm";
            this.Text = "Enigma";
            this.topMenuBar.ResumeLayout(false);
            this.topMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextArea;
        private System.Windows.Forms.TextBox outputTextArea;
        private System.Windows.Forms.MenuStrip topMenuBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem clipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteTextToInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTextFromInputAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem howToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber1;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber2;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber3;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber4;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber5;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber6;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber7;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber8;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber9;
        private System.Windows.Forms.ToolStripMenuItem rotorsNumber10;
        private System.Windows.Forms.ToolStripMenuItem configureTheMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptAMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptAMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatIsThisAndHowItWorksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatTheSimulatorDoesAndDoesntToolStripMenuItem;

    }
}

