using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text;

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
            using (var sr = new StreamWriter("data.csv"))
            {               
                foreach (Person p in list)
                {
                    sr.Write(p.name); sr.Write("; ");
                    sr.Write(p.gender); sr.Write("; ");
                    sr.Write(p.age); sr.Write("; ");
                    sr.Write(p.diag); sr.Write("; ");
                    sr.Write(p.volume); sr.Write("; ");
                    sr.Write(p.time); sr.Write("; ");
                    sr.Write(p.hbf_idle); sr.Write("; ");
                    sr.Write(p.hbf_load); sr.Write("; ");
                    sr.Write(p.hbf_return); sr.Write("; ");
                    sr.Write(p.syst); sr.Write("; ");
                    sr.Write(p.dyast); sr.Write("; ");
                    sr.Write(p.lift); sr.Write("; ");
                    sr.Write(p.height); sr.Write("; ");
                    sr.Write(p.weight); sr.Write("; ");
                    sr.Write(p.circle); sr.Write("; ");
                    sr.Write(p.circleFull); sr.Write("; ");
                    sr.Write(p.flexibility); sr.Write("; ");
                    sr.Write(p.jump); sr.Write("; ");
                    sr.Write(p.dynam); sr.Write("; ");
                    sr.Write(p.oExcurcion); sr.Write("; ");
                    sr.Write(p.oPinj); sr.Write("; ");
                    sr.Write(p.oKerd); sr.Write("; ");
                    sr.Write(p.oRoof); sr.Write("; ");
                    sr.Write(p.oShap); sr.Write("; ");
                    sr.Write(p.oSkir); sr.Write("; ");
                    sr.Write(p.oFunc); sr.Write("; ");
                    sr.Write(p.oType); sr.Write("; ");
                    sr.Write(p.oSTR); sr.Write("; ");
                    sr.Write(p.oEcon); sr.Write("; ");
                    sr.Write(p.oSumm); sr.Write("; ");
                    sr.Write(p.oConc); sr.Write("; ");

                }
            }
        }
    }
}
