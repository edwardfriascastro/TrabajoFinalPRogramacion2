﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
            dataGridView1.DataSource = Negocio.Negocio.Instance.SeleccionarReporte();

        }

        
    }
}
