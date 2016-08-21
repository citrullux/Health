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
        private Person _param;
        private MainWindow _base;
        public AddDialog(MainWindow window)
        {
            InitializeComponent();
            inDiag.SelectedIndex = 0;
            _param = new Person();
            _base = window;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void inFio_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calculate()
        {

            _param.name = inFio.Text;

            if (inMan.Checked == true)
            {
                _param.gender = 'м';
            }
            else
            {
                _param.gender = 'ж';
            }

            _param.age = (double)inAge.Value;
            _param.volume = (double)inVolume.Value;
            _param.time = (double)inTime.Value;
            _param.hbf_idle = (double)inhbf_idle.Value;
            _param.hbf_load = (double)inHbfload.Value;
            _param.hbf_return = (double)inHbfreturn.Value;
            _param.syst = (double)inSyst.Value;
            _param.dyast = (double)inDyas.Value;
            _param.lift = (double)inLift.Value;
            _param.height = (double)inHeight.Value;
            _param.weight = (double)inWeight.Value;
            _param.circle = (double)inCirc.Value;
            _param.circleFull = (double)inCircfull.Value;
            _param.dynam = (double)inDyn.Value;
            _param.jump = (double)inJump.Value;
            _param.flexibility = (double)inFlex.Value;
            _param.diag = (string)inDiag.Text;

            outPinj.Text = _param.oPinj.ToString();
            outKerd.Text = _param.oKerd.ToString();
            outRoof.Text = _param.oRoof.ToString();
            outShap.Text = _param.oShap.ToString();
            outSkir.Text = _param.oSkir.ToString();
            outFunc.Text = _param.oFunc.ToString();
            outType.Text = _param.oType.ToString();
            outSTR.Text = _param.oSTR.ToString();
            outEcon.Text = _param.oEcon.ToString();
            outJump.Text = _param.jump.ToString();
            outDynm.Text = _param.dynam.ToString();

            outEcxs.Text = _param.oExcurcion.ToString();
            outHBF.Text = _param.hbf_idle.ToString();
            outFlex.Text = _param.flexibility.ToString();

            outSumm.Text = _param.oSumm.ToString();
            outConc.Text = _param.oConc.ToString();

        }
        
        // Производства рассчёта в форме.
        // Забор переменных из входных значений и рассчёт
        private void btnCalc_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Calculate();
            _base.Add(_param);
            Close();
        }


    }
}
