﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAddingInformationToDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var model = new MyModel();
           
            dataGridBrand.DataSource = model.Brands.ToList();
            dataGridBrand.Columns[2].Visible = false;

            dataGridDimension.DataSource = model.Dimensions.ToList();
            dataGridDimension.Columns[4].Visible = false;

            dataGridDriver.DataSource = model.Drivers.ToList();
            dataGridDriver.Columns[5].Visible = false;
            dataGridDriver.Columns[6].Visible = false;
            dataGridDriver.Columns[7].Visible = false;

            dataGridTransport.DataSource = model.Transports.ToList();
            dataGridTransport.Columns[6].Visible = false;
            dataGridTransport.Columns[7].Visible = false;
            dataGridTransport.Columns[8].Visible = false;
            dataGridTransport.Columns[9].Visible = false;
            dataGridTransport.Columns[10].Visible = false;
            

            dataGridWeight.DataSource = model.Weights.ToList();
            dataGridWeight.Columns[2].Visible = false;

            dataGridType.DataSource = model.Types.ToList();
            dataGridType.Columns[2].Visible = false;

            dataGridExperience.DataSource = model.Experiences.ToList();
            dataGridExperience.Columns[2].Visible = false;

            dataGridRoute.DataSource = model.Routes.ToList();
        }
    }
}
