﻿using StdMng2023.StdMng;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StdMng2023
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            fmStdADO fmado = new fmStdADO();
            fmado.MdiParent = this;
            fmado.Show();

        }
    }
}
