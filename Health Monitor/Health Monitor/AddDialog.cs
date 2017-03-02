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
    public partial class AddDialog : Form
    {
        public bool add = true;
        public bool save { get; private set; }
        public Person Person;
        public AddDialog()
        {
            InitializeComponent();
            inDiag.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (add) { Person = new Person(); }
            save = false;
            inFio.Text = Person.Name;
            if (Person.Gender == 'м')
            {
                inMan.Checked = true;
                inWoman.Checked = false;
            }
            else
            {
                inMan.Checked = false;
                inWoman.Checked = true;
            }
            inAge.Value = (Decimal)Person.Age;
            inVolume.Value = (Decimal)Person.Volume;
            inTime.Value = (Decimal)Person.Time;
            inhbf_idle.Value = (Decimal)Person.Hbf_idle;
            inHbfload.Value = (Decimal)Person.Hbf_load;
            inHbfreturn.Value = (Decimal)Person.Hbf_return;
            inSyst.Value = (Decimal)Person.Syst;
            inDyas.Value = (Decimal)Person.Dyast;
            inLift.Value = (Decimal)Person.Lift;
            inHeight.Value = (Decimal)Person.Height;
            inWeight.Value = (Decimal)Person.Weight;
            inCirc.Value = (Decimal)Person.Circle;
            inCircfull.Value = (Decimal)Person.CircleFull;
            inDyn.Value = (Decimal)Person.Dynam;
            inJump.Value = (Decimal)Person.Jump;
            inFlex.Value = (Decimal) Person.Flexibility;
            inDiag.Text = Person.Diag;

            outPinj.Text = Person.oPinj.ToString();
            outKerd.Text = Person.oKerd.ToString();
            outRoof.Text = Person.oRoof.ToString();
            outShap.Text = Person.oShap.ToString();
            outSkir.Text = Person.oSkir.ToString();
            outFunc.Text = Person.oFunc.ToString();
            outType.Text = Person.oType.ToString();
            outSTR.Text = Person.oSTP.ToString();
            outEcon.Text = Person.oEcon.ToString();
            outJump.Text = Person.Jump.ToString();
            outDynm.Text = Person.Dynam.ToString();

            outEcxs.Text = Person.oExcurcion.ToString();
            outHBF.Text = Person.Hbf_idle.ToString();
            outFlex.Text = Person.Flexibility.ToString();

            outSumm.Text = Person.oSumm.ToString();
            outConc.Text = Person.oConc.ToString();
        }

        private void inFio_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calculate()
        {
            Person.Name = inFio.Text;

            if (inMan.Checked == true)
            {
                Person.Gender = 'м';
            }
            else
            {
                Person.Gender = 'ж';
            }

            Person.Age = (double)inAge.Value;
            Person.Volume = (double)inVolume.Value;
            Person.Time = (double)inTime.Value;
            Person.Hbf_idle = (double)inhbf_idle.Value;
            Person.Hbf_load = (double)inHbfload.Value;
            Person.Hbf_return = (double)inHbfreturn.Value;
            Person.Syst = (double)inSyst.Value;
            Person.Dyast = (double)inDyas.Value;
            Person.Lift = (double)inLift.Value;
            Person.Height = (double)inHeight.Value;
            Person.Weight = (double)inWeight.Value;
            Person.Circle = (double)inCirc.Value;
            Person.CircleFull = (double)inCircfull.Value;
            Person.Dynam = (double)inDyn.Value;
            Person.Jump = (double)inJump.Value;
            Person.Flexibility = (double)inFlex.Value;
            Person.Diag = (string)inDiag.Text;

            outPinj.Text = Person.oPinj.ToString();
            outKerd.Text = Person.oKerd.ToString();
            outRoof.Text = Person.oRoof.ToString();
            outShap.Text = Person.oShap.ToString();
            outSkir.Text = Person.oSkir.ToString();
            outFunc.Text = Person.oFunc.ToString();
            outType.Text = Person.oType.ToString();
            outSTR.Text = Person.oSTP.ToString();
            outEcon.Text = Person.oEcon.ToString();
            outJump.Text = Person.Jump.ToString();
            outDynm.Text = Person.Dynam.ToString();

            outEcxs.Text = Person.oExcurcion.ToString();
            outHBF.Text = Person.Hbf_idle.ToString();
            outFlex.Text = Person.Flexibility.ToString();

            outSumm.Text = Person.oSumm.ToString();
            outConc.Text = Person.oConc.ToString();

        }
        
        // Производства рассчёта в форме.
        // Забор переменных из входных значений и рассчёт
        private void btnCalc_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save = true;
            Calculate();
            Close();
        }


    }
}
