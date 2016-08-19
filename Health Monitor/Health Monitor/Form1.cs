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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Магия?
        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void inFio_TextChanged(object sender, EventArgs e)
        {

        }
        
        // Производства рассчёта в форме.
        // Забор переменных из входных значений и рассчёт
        private void btnCalc_Click(object sender, EventArgs e)
        {
            in_out Param = new in_out();
            
            Param.FIO = inFio.Text;
            
            if(inMan.Checked == true)
            {
                Param.Gender = 'м';
            }
            else
            {
                Param.Gender = 'ж';
            }

            Param.Age = (double)inAge.Value;
            Param.Volume = (double)inVolume.Value;
            Param.Time = (double)inTime.Value;
            Param.HBFIdle = (double)inHbfidle.Value;
            Param.HBFLoad = (double)inHbfload.Value;
            Param.HBFReturn = (double)inHbfreturn.Value;
            Param.Syst = (double)inSyst.Value;
            Param.Dyast = (double)inDyas.Value;
            Param.Lift = (double)inLift.Value;
            Param.Height = (double)inHeight.Value;
            Param.Weight = (double)inWeight.Value;
            Param.Circle = (double)inCirc.Value;
            Param.CircleFull = (double)inCircfull.Value;
            Param.Dynam = (double)inDyn.Value;
            Param.Jump = (double)inJump.Value;
            Param.Flexibility = (double)inFlex.Value;

            outPinj.Text = Param.oPinj.ToString();
            outKerd.Text = Param.oKerd.ToString();
            outRoof.Text = Param.oRoof.ToString();
            outShap.Text = Param.oShap.ToString();
            outSkir.Text = Param.oSkir.ToString();
            outFunc.Text = Param.oFunc.ToString();
            outType.Text = Param.oType.ToString();
            outSTR.Text = Param.oSTR.ToString();
            outEcon.Text = Param.oEcon.ToString();
            outJump.Text = Param.Jump.ToString();
            outDynm.Text = Param.Dynam.ToString();

            outEcxs.Text = Param.oExcurcion.ToString();
            outHBF.Text = Param.HBFIdle.ToString();
            outFlex.Text = Param.Flexibility.ToString();
            
            
            outSumm.Text = Param.oSumm.ToString();
            outDiag.Text = Param.oDiag.ToString();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

    }
}
