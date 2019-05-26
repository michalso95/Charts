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
        public Double time, temp, humidity, uv, methane, wind, damp;
        PointPairList list_temp = new PointPairList();
        PointPairList list_humi = new PointPairList();
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
        ZedGraphControl graph_humi = new ZedGraphControl();
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
            try
            {
                read = new Reader(path);
                foreach (var x in read.Lista)
                {
                    time = Convert.ToDouble(x.time);
                    temp = Convert.ToDouble(x.temperature);
                    humidity = Convert.ToDouble(x.humidity);
                    uv = Convert.ToDouble(x.ultraviolet);
                    damp = Convert.ToDouble(x.damp);
                    methane = Convert.ToDouble(x.methane);
                    wind = Convert.ToDouble(x.wind);

                    //list_time.Add(time);
                    list_temp.Add(time, temp);
                    list_humi.Add(time, humidity);
                    list_uv.Add(time, uv);
                    list_damp.Add(time, damp);
                    list_meth.Add(time, methane);
                    list_wind.Add(time, wind);
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
            plot_temp.XAxis.Title.Text = "TIME";
            plot_temp.YAxis.Title.Text = "TEMPERATURE";
            
            LineItem line_temp = plot_temp.AddCurve("temperature", list_temp, Color.Red, SymbolType.None);
            line_temp.Color = Color.Green;
            line_temp.Line.Width = 5;
            graph_temp.AxisChange();

            graph_temp.SaveAs("temperature_chart.png");
        }

        private void plot_humi()
        {
            GraphPane plot_humi = graph_humi.GraphPane;
            plot_humi.Title.Text = "Humidity";
            plot_humi.XAxis.Title.Text = "TIME";
            plot_humi.YAxis.Title.Text = "HUMIDITY";

            LineItem line_temp = plot_humi.AddCurve("humidity", list_humi, Color.Red, SymbolType.Circle);
            graph_humi.AxisChange();

            graph_humi.SaveAs("humidity_chart.png");
        }

        private void plot_uv()
        {
            GraphPane plot_uv = graph_uv.GraphPane;
            plot_uv.Title.Text = "UV";
            plot_uv.XAxis.Title.Text = "TIME";
            plot_uv.YAxis.Title.Text = "UV";

            LineItem line_uv = plot_uv.AddCurve("UV", list_uv, Color.Red, SymbolType.Circle);
            graph_uv.AxisChange();

            graph_uv.SaveAs("uv_chart.png");
        }

        private void plot_damp()
        {
            GraphPane plot_damp = graph_damp.GraphPane;
            plot_damp.Title.Text = "Damp";
            plot_damp.XAxis.Title.Text = "TIME";
            plot_damp.YAxis.Title.Text = "DAMP";

            LineItem line_damp = plot_damp.AddCurve("damp", list_damp, Color.Red, SymbolType.Circle);
            graph_damp.AxisChange();

            graph_damp.SaveAs("damp.png");
        }

        private void plot_meth()
        {
            GraphPane plot_meth = graph_meth.GraphPane;
            plot_meth.Title.Text = "METHANE";
            plot_meth.XAxis.Title.Text = "TIME";
            plot_meth.YAxis.Title.Text = "METHANE";

            LineItem line_meth = plot_meth.AddCurve("methane", list_meth, Color.Red, SymbolType.Circle);
            graph_meth.AxisChange();

            graph_meth.SaveAs("methane_chart.png");
        }

        private void plot_wind()
        {
            GraphPane plot_wind = graph_wind.GraphPane;
            plot_wind.Title.Text = "Wind";
            plot_wind.XAxis.Title.Text = "TIME";
            plot_wind.YAxis.Title.Text = "WIND";

            LineItem line_wind = plot_wind.AddCurve("wind", list_wind, Color.Red, SymbolType.Circle);
            graph_wind.AxisChange();

            graph_wind.SaveAs("wind_chart.png");
        }

        private void setsize()
        {
            graph_temp.Location = new Point(10, 10);
            graph_temp.Size = new Size(1000, 1000);

            graph_humi.Location = new Point(10, 10);
            graph_humi.Size = new Size(1000, 1000);

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
            if ((check_temp.Checked == false) && (check_humidity.Checked == false) && (check_uv.Checked == false) && (check_damp.Checked == false) && (check_methane.Checked == false) && (check_wind.Checked == false))
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
                    if (check_humidity.Checked == true) { plot_humi(); }
                    if (check_wind.Checked == true) { plot_wind(); }
                    if (check_uv.Checked == true) { plot_uv(); }
                    if (check_methane.Checked == true) { plot_meth(); }
                    if (check_damp.Checked == true) { plot_damp(); }

                }
            }
        }
    }
}
