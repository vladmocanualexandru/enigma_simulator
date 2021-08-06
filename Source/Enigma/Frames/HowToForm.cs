﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Enigma.Frames
{
    public partial class HowToForm : Form
    {
        public HowToForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void appear(String title, String message)
        {
            this.Text = title;
            informationTextBox.Text = message;
            this.Visible = true;
        }
    }
}
