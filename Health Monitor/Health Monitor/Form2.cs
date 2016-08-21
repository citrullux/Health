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
                    sr.Write(p.diag);

                }
            }

        }
    }
}
