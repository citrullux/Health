using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Health_Monitor
{
    public partial class MainWindow : Form
    {
        private BindingList<Person> list;
        public MainWindow()
        {
            InitializeComponent();
            list = new BindingList<Person>();
            //Привязки
            grid.DataSource = list;
        }
        public void Add(Person person)
        {
            list.Add(person);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new AddDialog(this);
            dialog.Show();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            var fname = "data.csv";
            dialog.DefaultExt = "csv";
            dialog.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fname = dialog.FileName;
            }
            
            using (StreamWriter sr = new StreamWriter(fname, false, Encoding.GetEncoding(1251)))
            {               
                foreach (Person p in list)
                {
                    sr.Write(p.name + "; ");
                    sr.Write(p.gender + "; ");
                    sr.Write(p.age + "; ");
                    sr.Write(p.diag + "; ");
                    sr.Write(p.volume + "; ");
                    sr.Write(p.time + "; ");
                    sr.Write(p.hbf_idle + "; ");
                    sr.Write(p.hbf_load + "; ");
                    sr.Write(p.hbf_return + "; ");
                    sr.Write(p.syst + "; ");
                    sr.Write(p.dyast + "; ");
                    sr.Write(p.lift + "; ");
                    sr.Write(p.height + "; ");
                    sr.Write(p.weight + "; ");
                    sr.Write(p.circle + "; ");
                    sr.Write(p.circleFull + "; ");
                    sr.Write(p.flexibility + "; ");
                    sr.Write(p.jump + "; ");
                    sr.Write(p.dynam + "; ");
                    sr.Write(p.oExcurcion + "; ");
                    sr.Write(p.oPinj + "; ");
                    sr.Write(p.oKerd + "; ");
                    sr.Write(p.oRoof + "; ");
                    sr.Write(p.oShap + "; ");
                    sr.Write(p.oSkir + "; ");
                    sr.Write(p.oFunc + "; ");
                    sr.Write(p.oType + "; ");
                    sr.Write(p.oSTR + "; ");
                    sr.Write(p.oEcon + "; ");
                    sr.Write(p.oSumm + "; ");
                    sr.Write(p.oConc + "; ");
                    sr.Write(Environment.NewLine);
                }
            }
        }

        private void btnImp_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            var fname = "data.csv";
            dialog.DefaultExt = "csv";
            dialog.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fname = dialog.FileName;
            }

            using (StreamReader sr = new StreamReader(fname, Encoding.GetEncoding(1251)))
            {
                List<Person> objects = new List<Person>();
                {
                   string line;
                   while((line = sr.ReadLine()) != null)
                   {
                       Person obj = new Person();
                       string[] fields = line.Split(';');
                       obj.name = fields[0].Trim();
                       obj.gender = fields[1].Trim()[0];
                       obj.age = double.Parse(fields[2]);
                       obj.diag = fields[3].Trim();
                       obj.volume = double.Parse(fields[4]);
                       obj.time = double.Parse(fields[5]);
                       obj.hbf_idle = double.Parse(fields[6]);
                       obj.hbf_load = double.Parse(fields[7]);
                       obj.hbf_return = double.Parse(fields[8]);
                       obj.syst = double.Parse(fields[9]);
                       obj.dyast = double.Parse(fields[10]);
                       obj.lift = double.Parse(fields[11]);
                       obj.height = double.Parse(fields[12]);
                       obj.weight = double.Parse(fields[13]);
                       obj.circle = double.Parse(fields[14]);
                       obj.circleFull = double.Parse(fields[15]);
                       obj.flexibility = double.Parse(fields[16]);
                       obj.jump = double.Parse(fields[17]);
                       obj.dynam = double.Parse(fields[18]);
                       Add (obj);
                   }
                }
            }

        }

    }
}
