﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;

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
            _dbContext = new MyModel();       
            DisplayTableInForm();
        }
        private void gMapControl_Load_1(object sender, EventArgs e)
        {
            _map = new Map();
            _map.Init(ref gMapControl);
            _start = new PointLatLng();
            _finish = new PointLatLng();
        }


        private void DisplayTableInForm()
        {
            dataGridBrand.DataSource = _dbContext.Brands.ToList();
            dataGridBrand.Columns[2].Visible = false;

            dataGridDimension.DataSource = _dbContext.Dimensions.ToList();
            dataGridDimension.Columns[4].Visible = false;

            dataGridDriver.DataSource = _dbContext.Drivers.ToList();
            dataGridDriver.Columns[5].Visible = false;
            dataGridDriver.Columns[6].Visible = false;
            dataGridDriver.Columns[7].Visible = false;

            dataGridTransport.DataSource = _dbContext.Transports.ToList();
            dataGridTransport.Columns[6].Visible = false;
            dataGridTransport.Columns[7].Visible = false;
            dataGridTransport.Columns[8].Visible = false;
            dataGridTransport.Columns[9].Visible = false;
            dataGridTransport.Columns[10].Visible = false;


            dataGridWeight.DataSource = _dbContext.Weights.ToList();
            dataGridWeight.Columns[2].Visible = false;

            dataGridType.DataSource = _dbContext.Types.ToList();
            dataGridType.Columns[2].Visible = false;

            dataGridExperience.DataSource = _dbContext.Experiences.ToList();
            dataGridExperience.Columns[2].Visible = false;

            dataGridRoute.DataSource = _dbContext.Routes.ToList();
        }

        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            PointLatLng pointCurent = gMapControl.FromLocalToLatLng(e.X, e.Y);
            if (e.Button == MouseButtons.Left && _start.Lat == 0.0)
            {
                _start = pointCurent;
                _map.DrawMarker(ref gMapControl,_start);
               
            }
            else if (e.Button == MouseButtons.Left && _finish.Lat == 0.0)
            {
                _finish = pointCurent;
                _map.DrawMarker(ref gMapControl, _finish);
                List<PointLatLng> rount = _map.GetRoute(_start, _finish);
                _map.DrawRoute(ref gMapControl,ref rount);
                labDistanceShow.Text = _map.GetRouteDistance();
                labDurationShow.Text = _map.GetRouteDuration();
               
            }
            else if (e.Button == MouseButtons.Left && _finish.Lat != 0.0 && _start.Lat != 0.0)
            {
                _start = _finish = new PointLatLng(0.0, 0.0);
                _map.ClearMarkers();
                _map.ClearRoutes();  
            }
        }



        private MyModel _dbContext;
        private Map _map;
        private PointLatLng _start;
        private PointLatLng _finish;
    }
}
