using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using CsvHelper;
using System.IO;

namespace Charts
{
    public partial class charts : Form
    {
        Reader read;
        public Double time, temp, pressure, uv, methane, wind, damp;
        //public string time;
        PointPairList list_temp = new PointPairList();
        PointPairList list_press = new PointPairList();
        PointPairList list_meth = new PointPairList();
        PointPairList list_damp = new PointPairList();
        PointPairList list_wind = new PointPairList();
        PointPairList list_uv = new PointPairList();
        //List<Double> list_time = new List<double>();
        //List<Double> list_temp = new List<double>();
        //List<Double> list_humi = new List<double>();
        //List<Double> list_meth = new List<double>();
        //List<Double> list_damp = new List<double>();
        //List<Double> list_wind = new List<double>();
        //List<Double> list_uv = new List<double>();
        ZedGraphControl graph_temp = new ZedGraphControl();
        ZedGraphControl graph_press = new ZedGraphControl();
        ZedGraphControl graph_meth = new ZedGraphControl();
        ZedGraphControl graph_damp = new ZedGraphControl();
        ZedGraphControl graph_wind = new ZedGraphControl();
        ZedGraphControl graph_uv = new ZedGraphControl();

        string path;

        public charts()
        {
            InitializeComponent();     
        }

        private void reading_csv(string path)
        {
            int hour=0, minute=0, sec=0;
            try
            {
                read = new Reader(path);
                foreach (var x in read.Lista)
                {
                    hour = (int)Convert.ToDouble(x.time.Substring(0, 1));
                    minute = (int)Convert.ToDouble(x.time.Substring(2, 2));
                    sec = (int)Convert.ToDouble(x.time.Substring(5, 2));
                    
               //     time = Convert.ToDouble(x.time);
                    temp = Convert.ToDouble(x.temperature)/1000;
                    pressure = Convert.ToDouble(x.pressure)/1000;
                    uv = Convert.ToDouble(x.ultraviolet)/1000;
                    damp = Convert.ToDouble(x.damp)/1000;
                    methane = Convert.ToDouble(x.methane)/1000;
                    wind = Convert.ToDouble(x.wind)/1000/3.6;

                    //list_time.Add(time);
                    list_temp.Add(new XDate(2019, 05, 29, hour, minute, sec), temp);
                    list_press.Add(new XDate(2019, 05, 29, hour, minute, sec), pressure);
                    list_uv.Add(new XDate(2019, 05, 29, hour, minute, sec), uv);
                    list_damp.Add(new XDate(2019, 05, 29, hour, minute, sec), damp);
                    list_meth.Add(new XDate(2019, 05, 29, hour, minute, sec), methane);
                    list_wind.Add(new XDate(2019, 05, 29, hour, minute, sec), wind);
                }
            }
            catch (Exception eq)
            {
                MessageBox.Show("zly plik danych");
            }
        }

        private void plot_temp()
        {
            GraphPane plot_temp = graph_temp.GraphPane;
            plot_temp.Title.Text = "Temperature";
            plot_temp.XAxis.Title.Text = "t (hh:mm:ss)";
            plot_temp.YAxis.Title.Text = "TEMPERATURE (C)";
            plot_temp.XAxis.MajorGrid.IsVisible = true;
            plot_temp.YAxis.MajorGrid.IsVisible = true;
            plot_temp.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            plot_temp.XAxis.Type = AxisType.Date;
            plot_temp.XAxis.Scale.Format = "hh:mm:ss";

            LineItem line_temp = plot_temp.AddCurve("",list_temp, Color.Green, SymbolType.None);
            line_temp.Line.Width = 5;
            graph_temp.AxisChange();

            graph_temp.SaveAs("temperature_chart.png");
        }

        private void plot_press()
        {
            GraphPane plot_press = graph_press.GraphPane;
            plot_press.Title.Text = "Pressure";
            plot_press.XAxis.Title.Text = "t (hh:mm:ss)";
            plot_press.YAxis.Title.Text = "PRESSURE (Pa)";
            plot_press.XAxis.MajorGrid.IsVisible = true;
            plot_press.YAxis.MajorGrid.IsVisible = true;
            plot_press.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            plot_press.XAxis.Type = AxisType.Date;
            plot_press.XAxis.Scale.Format = "hh:mm:ss";

            LineItem line_press = plot_press.AddCurve("", list_press, Color.Green, SymbolType.None);
            line_press.Line.Width = 5;
            graph_press.AxisChange();

            graph_press.SaveAs("pressure_chart.png");
        }

        private void plot_uv()
        {
            GraphPane plot_uv = graph_uv.GraphPane;
            plot_uv.Title.Text = "UV";
            plot_uv.XAxis.Title.Text = "t (hh:mm:ss)";
            plot_uv.YAxis.Title.Text = "UV";
            plot_uv.XAxis.MajorGrid.IsVisible = true;
            plot_uv.YAxis.MajorGrid.IsVisible = true;
            plot_uv.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            plot_uv.YAxis.Scale.Min = 1;
            plot_uv.YAxis.Scale.Max = 8;
            plot_uv.XAxis.Type = AxisType.Date;
            plot_uv.XAxis.Scale.Format = "hh:mm:ss";

            LineItem line_uv = plot_uv.AddCurve("", list_uv, Color.Green, SymbolType.None);
            line_uv.Line.Width = 5;
            graph_uv.AxisChange();

            graph_uv.SaveAs("uv_chart.png");
        }

        private void plot_damp()
        {
            GraphPane plot_damp = graph_damp.GraphPane;
            plot_damp.Title.Text = "CO";
            plot_damp.XAxis.Title.Text = "t (hh:mm:ss)";
            plot_damp.YAxis.Title.Text = "CO (ppm)";
            plot_damp.XAxis.MajorGrid.IsVisible = true;
            plot_damp.YAxis.MajorGrid.IsVisible = true;
            plot_damp.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            plot_damp.YAxis.Scale.Min = 0.1;
            plot_damp.YAxis.Scale.Max = 0.5;
            plot_damp.XAxis.Type = AxisType.Date;
            plot_damp.XAxis.Scale.Format = "hh:mm:ss";

            LineItem line_damp = plot_damp.AddCurve("", list_damp, Color.Green, SymbolType.None);
            line_damp.Line.Width = 5;
            graph_damp.AxisChange();

            graph_damp.SaveAs("damp.png");
        }

        private void plot_meth()
        {
            GraphPane plot_meth = graph_meth.GraphPane;
            plot_meth.Title.Text = "METHANE";
            plot_meth.XAxis.Title.Text = "t (hh:mm:ss)";
            plot_meth.YAxis.Title.Text = "METHANE (ppm)";
            plot_meth.XAxis.MajorGrid.IsVisible = true;
            plot_meth.YAxis.MajorGrid.IsVisible = true;
            plot_meth.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            plot_meth.XAxis.Type = AxisType.Date;
            plot_meth.XAxis.Scale.Format = "hh:mm:ss";
            plot_meth.YAxis.Scale.Min = 1600;
            plot_meth.YAxis.Scale.Max = 1800;

            LineItem line_meth = plot_meth.AddCurve("", list_meth, Color.Green, SymbolType.None);
            line_meth.Line.Width = 5;
            graph_meth.AxisChange();

            graph_meth.SaveAs("methane_chart.png");
        }

        private void plot_wind()
        {
            GraphPane plot_wind = graph_wind.GraphPane;
            plot_wind.Title.Text = "Wind";
            plot_wind.XAxis.Title.Text = "t (hh:mm:ss)";
            plot_wind.YAxis.Title.Text = "WIND (m/s)";
            plot_wind.XAxis.MajorGrid.IsVisible = true;
            plot_wind.YAxis.MajorGrid.IsVisible = true;
            plot_wind.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            plot_wind.XAxis.Type = AxisType.Date;
            plot_wind.XAxis.Scale.Format = "hh:mm:ss";

            LineItem line_wind = plot_wind.AddCurve("", list_wind, Color.Green, SymbolType.None);
            line_wind.Line.Width = 5;
            graph_wind.AxisChange();

            graph_wind.SaveAs("wind_chart.png");
        }

        private void setsize()
        {
            graph_temp.Location = new Point(10, 10);
            graph_temp.Size = new Size(1000, 1000);

            graph_press.Location = new Point(10, 10);
            graph_press.Size = new Size(1000, 1000);

            graph_damp.Location = new Point(10, 10);
            graph_damp.Size = new Size(1000, 1000);

            graph_uv.Location = new Point(10, 10);
            graph_uv.Size = new Size(1000, 1000);

            graph_meth.Location = new Point(10, 10);
            graph_meth.Size = new Size(1000, 1000);

            graph_wind.Location = new Point(10, 10);
            graph_wind.Size = new Size(1000, 1000);

        }

        private void make_btn_Click(object sender, EventArgs e)
        {
            if ((check_temp.Checked == false) && (check_press.Checked == false) && (check_uv.Checked == false) && (check_damp.Checked == false) && (check_methane.Checked == false) && (check_wind.Checked == false))
            {
                MessageBox.Show("No checked charts");
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "CSV Files(*.csv)|*.csv|All files(*.*)|*.*";          
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path = dlg.InitialDirectory.ToString() + dlg.FileName.ToString();
                    reading_csv(path);
                    setsize();
                    if (check_temp.Checked == true) { plot_temp(); }
                    if (check_press.Checked == true) { plot_press(); }
                    if (check_wind.Checked == true) { plot_wind(); }
                    if (check_uv.Checked == true) { plot_uv(); }
                    if (check_methane.Checked == true) { plot_meth(); }
                    if (check_damp.Checked == true) { plot_damp(); }

                }
            }
        }
    }
}
