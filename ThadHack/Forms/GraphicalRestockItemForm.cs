﻿using System;
using System.Windows.Forms;

namespace ZzukBot.Forms
{
    internal partial class FormRestockItem : Form
    {
        internal FormRestockItem()
        {
            InitializeComponent();
            bOk.DialogResult = DialogResult.OK;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}