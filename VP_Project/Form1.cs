﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selamu Aleykum");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<25;i++)
            MessageBox.Show("Zdravo");
        }
    }
}
