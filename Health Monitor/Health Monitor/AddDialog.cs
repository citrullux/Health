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
            inFio.Text = Person.name;
            if (Person.gender == 'м')
            {
                inMan.Checked = true;
                inWoman.Checked = false;
            }
            else
            {
                inMan.Checked = false;
                inWoman.Checked = true;
            }
            inAge.Value = (Decimal)Person.age;
            inVolume.Value = (Decimal)Person.volume;
            inTime.Value = (Decimal)Person.time;
            inhbf_idle.Value = (Decimal)Person.hbf_idle;
            inHbfload.Value = (Decimal)Person.hbf_load;
            inHbfreturn.Value = (Decimal)Person.hbf_return;
            inSyst.Value = (Decimal)Person.syst;
            inDyas.Value = (Decimal)Person.dyast;
            inLift.Value = (Decimal)Person.lift;
            inHeight.Value = (Decimal)Person.height;
            inWeight.Value = (Decimal)Person.weight;
            inCirc.Value = (Decimal)Person.circle;
            inCircfull.Value = (Decimal)Person.circleFull;
            inDyn.Value = (Decimal)Person.dynam;
            inJump.Value = (Decimal)Person.jump;
            inFlex.Value = (Decimal) Person.flexibility;
            inDiag.Text = Person.diag;

            outPinj.Text = Person.oPinj.ToString();
            outKerd.Text = Person.oKerd.ToString();
            outRoof.Text = Person.oRoof.ToString();
            outShap.Text = Person.oShap.ToString();
            outSkir.Text = Person.oSkir.ToString();
            outFunc.Text = Person.oFunc.ToString();
            outType.Text = Person.oType.ToString();
            outSTR.Text = Person.oSTR.ToString();
            outEcon.Text = Person.oEcon.ToString();
            outJump.Text = Person.jump.ToString();
            outDynm.Text = Person.dynam.ToString();

            outEcxs.Text = Person.oExcurcion.ToString();
            outHBF.Text = Person.hbf_idle.ToString();
            outFlex.Text = Person.flexibility.ToString();

            outSumm.Text = Person.oSumm.ToString();
            outConc.Text = Person.oConc.ToString();
        }

        private void inFio_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calculate()
        {
            Person.name = inFio.Text;

            if (inMan.Checked == true)
            {
                Person.gender = 'м';
            }
            else
            {
                Person.gender = 'ж';
            }

            Person.age = (double)inAge.Value;
            Person.volume = (double)inVolume.Value;
            Person.time = (double)inTime.Value;
            Person.hbf_idle = (double)inhbf_idle.Value;
            Person.hbf_load = (double)inHbfload.Value;
            Person.hbf_return = (double)inHbfreturn.Value;
            Person.syst = (double)inSyst.Value;
            Person.dyast = (double)inDyas.Value;
            Person.lift = (double)inLift.Value;
            Person.height = (double)inHeight.Value;
            Person.weight = (double)inWeight.Value;
            Person.circle = (double)inCirc.Value;
            Person.circleFull = (double)inCircfull.Value;
            Person.dynam = (double)inDyn.Value;
            Person.jump = (double)inJump.Value;
            Person.flexibility = (double)inFlex.Value;
            Person.diag = (string)inDiag.Text;

            outPinj.Text = Person.oPinj.ToString();
            outKerd.Text = Person.oKerd.ToString();
            outRoof.Text = Person.oRoof.ToString();
            outShap.Text = Person.oShap.ToString();
            outSkir.Text = Person.oSkir.ToString();
            outFunc.Text = Person.oFunc.ToString();
            outType.Text = Person.oType.ToString();
            outSTR.Text = Person.oSTR.ToString();
            outEcon.Text = Person.oEcon.ToString();
            outJump.Text = Person.jump.ToString();
            outDynm.Text = Person.dynam.ToString();

            outEcxs.Text = Person.oExcurcion.ToString();
            outHBF.Text = Person.hbf_idle.ToString();
            outFlex.Text = Person.flexibility.ToString();

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
