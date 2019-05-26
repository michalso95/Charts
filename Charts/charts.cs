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

        private void plotgraph()
        {
            GraphPane plot_temp = graph_temp.GraphPane;
            plot_temp.Title.Text = "Temperature";
            plot_temp.XAxis.Title.Text = "TIME";
            plot_temp.YAxis.Title.Text = "TEMPERATURE";

            LineItem line_temp = plot_temp.AddCurve("temperature", list_temp, Color.Red, SymbolType.Circle);
            graph_temp.AxisChange();
        }

        private void setsize()
        {
            graph_temp.Location = new Point(10, 10);
            graph_temp.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20);
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
                    plotgraph();
                }

            }
        }
    }
}
