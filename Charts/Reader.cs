using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Windows.Forms;

namespace Charts
{
    class Reader
    {
        List<Row> lista;
        public List<Row> Lista { get => lista; set => lista = value; }

        public Reader(string zmienna1)
        {
            
            try
            {
                lista = new List<Row>();
                List<string> temp;
                temp = File.ReadAllLines(zmienna1).Skip(1).ToList();
                foreach (var x in temp)
                {
                    Row temprow = FromCsv(x);
                    if (temprow != null)
                    {
                        lista.Add(temprow);
                    }
                }
            }
            catch (Exception eq)
            {
                if (eq is UnauthorizedAccessException || eq is NullReferenceException || eq is FileNotFoundException)
                {
                    throw new Exception("plik danych pusty");
                }
            }
        }

        public Row FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            Row row = new Row();
            try
            {
                row.time = values[0];
                row.temperature = values[1];
                row.humidity = values[2];
                row.ultraviolet = values[3];
                row.damp = values[4];
                row.methane = values[5];
                row.wind = values[6];
                return row;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("2");
                return null;
            }
        }
    }
}

