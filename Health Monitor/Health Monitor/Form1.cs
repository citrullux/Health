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
            Person Param = new Person();
            
            Param.name = inFio.Text;
            
            if(inMan.Checked == true)
            {
                Param.gender = 'м';
            }
            else
            {
                Param.gender = 'ж';
            }

            Param.age = (double)inAge.Value;
            Param.volume = (double)inVolume.Value;
            Param.time = (double)inTime.Value;
            Param.hbf_idle = (double)inhbf_idle.Value;
            Param.hbf_load = (double)inHbfload.Value;
            Param.hbf_return = (double)inHbfreturn.Value;
            Param.syst = (double)inSyst.Value;
            Param.dyast = (double)inDyas.Value;
            Param.lift = (double)inLift.Value;
            Param.height = (double)inHeight.Value;
            Param.weight = (double)inWeight.Value;
            Param.circle = (double)inCirc.Value;
            Param.circleFull = (double)inCircfull.Value;
            Param.dynam = (double)inDyn.Value;
            Param.jump = (double)inJump.Value;
            Param.flexibility = (double)inFlex.Value;

            outPinj.Text = Param.oPinj.ToString();
            outKerd.Text = Param.oKerd.ToString();
            outRoof.Text = Param.oRoof.ToString();
            outShap.Text = Param.oShap.ToString();
            outSkir.Text = Param.oSkir.ToString();
            outFunc.Text = Param.oFunc.ToString();
            outType.Text = Param.oType.ToString();
            outSTR.Text = Param.oSTR.ToString();
            outEcon.Text = Param.oEcon.ToString();
            outJump.Text = Param.jump.ToString();
            outDynm.Text = Param.dynam.ToString();

            outEcxs.Text = Param.oExcurcion.ToString();
            outHBF.Text = Param.hbf_idle.ToString();
            outFlex.Text = Param.flexibility.ToString();
            
            
            outSumm.Text = Param.oSumm.ToString();
            outConc.Text = Param.oConc.ToString();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

    }
}
