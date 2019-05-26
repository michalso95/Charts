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

namespace Charts
{
    public partial class charts : Form
    {
        Reader read;
        public Double time, temp, humidity, uv, methane, wind, damp;
        List<Double> list_time = new List<double>();
        List<Double> list_temp = new List<double>();
        List<Double> list_humi = new List<double>();
        List<Double> list_meth = new List<double>();
        List<Double> list_damp = new List<double>();
        List<Double> list_wind = new List<double>();
        List<Double> list_uv = new List<double>();

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

                    list_time.Add(time);
                    list_temp.Add(temp);
                    list_humi.Add(humidity);
                    list_uv.Add(uv);
                    list_damp.Add(damp);
                    list_meth.Add(methane);
                    list_wind.Add(wind);
                }
            }
            catch (Exception eq)
            {
                MessageBox.Show("zly plik danych");
            }
        }

        private void make_btn_Click(object sender, EventArgs e)
        {
            if (check_temp.Checked == false && check_humidity.Checked == false && check_uv.Checked == false && check_damp.Checked == false && check_methane.Checked == false && check_wind.Checked == false)
            {
                MessageBox.Show("No checked charts");
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog();
                string path;
                dlg.Filter = "CSV Files(*.csv)|*.csv|All files(*.*)|*.*";
                path = dlg.FileName.ToString();
                reading_csv(path);


            }
        }
    }
}
