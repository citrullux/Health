using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Health_Monitor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            BindingList<Person> list = new BindingList<Person>();

            //Привязки
            grid.DataSource = list;
        }

    }
}
