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
        private AddDialog add_dialog;
        public MainWindow()
        {
            InitializeComponent();
            add_dialog = new AddDialog();
            list = new BindingList<Person>();
            //Привязки
            grid.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add_dialog.add = true;
            add_dialog.ShowDialog();
            if (add_dialog.save) {
                list.Add(add_dialog.Person);
            }
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            string fname = "data.csv";
            string fnameOth = " ";
            dialog.DefaultExt = "csv";
            dialog.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fname = dialog.FileName;
            }
            export(fname);
            
            fname = fname.Replace(".csv", " ");
            
            fnameOth = fname  + "(" + (int)AgeMin.Child + " - " + (int)AgeMax.Child + " лет).csv";
            export(fnameOth, (int)AgeMin.Child, (int)AgeMax.Child);

            fnameOth = fname + "(" + (int)AgeMin.Middle + " - " + (int)AgeMax.Middle + " лет).csv";
            export(fnameOth, (int)AgeMin.Middle, (int)AgeMax.Middle);

            fnameOth = fname + "(" + (int)AgeMin.High + " - " + (int)AgeMax.High + " лет).csv";
            export(fnameOth, (int)AgeMin.High, (int)AgeMax.High);
        }

        public void export(string fname)
        {
            using (StreamWriter sr = new StreamWriter(fname, false, Encoding.GetEncoding(1251)))
            {
                exportFirst(sr);
                foreach (Person p in list)
                {
                    exportOther(sr, p);
                }
            }
        }

        public void export(string fname, int minAge, int maxAge)
        {
            using (StreamWriter sr = new StreamWriter(fname, false, Encoding.GetEncoding(1251)))
            {
                exportFirst(sr);
                foreach (Person p in list)
                {
                    if (p.age >= minAge && p.age <= maxAge)
                    {
                        exportOther(sr, p);
                    }
                }
            }
        }

        public void exportFirst(StreamWriter sr)
        {
            sr.Write("ФИО ; ");
            sr.Write("Пол ; ");
            sr.Write("Возраст ; ");
            sr.Write("Диагноз ; ");
            sr.Write("ЖЁЛ ; ");
            sr.Write("Время задержки дыхания ; ");
            sr.Write("ЧСС покоя ; ");
            sr.Write("ЧСС нагрузки ; ");
            sr.Write("ЧСС восстановления ; ");
            sr.Write("Систолическое давление ; ");
            sr.Write("Диастолическое давление ; ");
            sr.Write("Число подъёмов тела в сед.; ");
            sr.Write("Рост ; ");
            sr.Write("Вес ; ");
            sr.Write("Окружность грудной клетки ; ");
            sr.Write("Окружность грудной клетки на вдохе ; ");
            sr.Write("Гибкость ; ");
            sr.Write("Прыжок с места ; ");
            sr.Write("Динамометрия ; ");
            sr.Write("Экскурсия грудной клетки ; ");
            sr.Write("Индекс Пинье ; ");
            sr.Write("Индекс Кердо ; ");
            sr.Write("Индекс Руфье ; ");
            sr.Write("Индекс Шаповаловой ; ");
            sr.Write("Индекс Скирбинского ; ");
            sr.Write("Индекс Функциональных изменений ; ");
            sr.Write("Тип кровообращения ; ");
            sr.Write("Показатель двойного произведения ; ");
            sr.Write("Экономичность кровообращения ; ");
            sr.Write("Суммарный диагностический коэффициэнт; ");
            sr.Write("Заключение ; ");
            sr.Write(Environment.NewLine);
        }

        public void exportOther(StreamWriter sr, Person p)
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
            sr.Write(p.oSTP + "; ");
            sr.Write(p.oEcon + "; ");
            sr.Write(p.oSumm + "; ");
            sr.Write(p.oConc + "; ");
            sr.Write(Environment.NewLine);
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
            list = new BindingList<Person>();
            grid.DataSource = list;
            using (StreamReader sr = new StreamReader(fname, Encoding.GetEncoding(1251)))
            {
                string line = sr.ReadLine();
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
                    list.Add(obj);
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var ind = grid.CurrentRow.Index;
            add_dialog.add = false;
            add_dialog.Person = list[ind].Copy();
            add_dialog.ShowDialog();
            if (add_dialog.save) {
                list[ind] = add_dialog.Person;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var ind = grid.CurrentRow.Index;
            list.RemoveAt(ind);
        }

        private string format_line(Func<Person, bool> predicate, int num, out double j) {
            double all = list.Count();
            var l = list.Where(predicate);
            var n = l.Count();
            double all_a = list.Where(p => p.diag == "Здоров").Count();
            double all_b = all - all_a;
            var na = l.Where(p => p.diag == "Здоров").Count();
            var nb = n - na;
            var pa = (na+1) / (all_a + num);
            var pb = (nb+1) / (all_b + num);
            var dk = 10 * Math.Log10(pa / pb);
            j = dk * (pa - pb) / 2;
            return na + "; " + nb + "; " + (100*pa) + "; " + (100*pb) + "; " + (pa-pb) + "; " + (pa/pb) + "; " + dk + "; " + j + "; ";
        }

        private string summ_line(double j)
        {
            double all = list.Count();
            double all_a = list.Where(p => p.diag == "Здоров").Count();
            var all_b = all - all_a;
            return "; сумма; " + all_a + "; " + all_b + "; " + "100" + "; " + "100" + "; ; ; ; " + j + "; "; ;
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            var fname = "data.csv";
            dialog.DefaultExt = "csv";
            dialog.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fname = dialog.FileName;
            }

            if (list.Count == 0) { return; }

            double[] J;
            string line;
            
            using (StreamWriter sr = new StreamWriter(fname, false, Encoding.GetEncoding(1251)))
            {
                sr.Write("№; Признаки и градации; N(xi/A); N(xi/B); P(xi/A); P(xi/B); Разности частностей; Отношения частностей; ДК; Информативность");
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write(";Телосложение (Индекс Пинье)");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.PinCalc(p.oPinj) == Pinie.Strong, J.Length, out J[0]);
                sr.Write("1; крепкое; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.PinCalc(p.oPinj) == Pinie.Good, J.Length, out J[1]);
                sr.Write("2; хорошее; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.PinCalc(p.oPinj) == Pinie.Middle, J.Length, out J[2]);
                sr.Write("3; среднее; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.PinCalc(p.oPinj) == Pinie.Weak, J.Length, out J[3]);
                sr.Write("4; слабое; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.PinCalc(p.oPinj) == Pinie.Bad, J.Length, out J[4]);
                sr.Write("5; очень слабое; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[3];

                sr.Write(";Экскурсия грудной клетки");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ExcCalc(p.oExcurcion) == Excurcion.High, J.Length, out J[0]);
                sr.Write("1; высокая; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ExcCalc(p.oExcurcion) == Excurcion.Middle, J.Length, out J[1]);
                sr.Write("2; средняя; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ExcCalc(p.oExcurcion) == Excurcion.Low, J.Length, out J[2]);
                sr.Write("3; низкая; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write(";Индекс Скибинского");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.gender, p.age) == Skir.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.gender, p.age) == Skir.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.gender, p.age) == Skir.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.gender, p.age) == Skir.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.gender, p.age) == Skir.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write(";Вегетативный индекс Кердо");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.KerdCalc(p.oKerd) == Kerd.HVT, J.Length, out J[0]);
                sr.Write("1; выраженная ВТ; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.KerdCalc(p.oKerd) == Kerd.VT, J.Length, out J[1]);
                sr.Write("2; умеренная ВТ; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.KerdCalc(p.oKerd) == Kerd.Eit, J.Length, out J[2]);
                sr.Write("3; эйтония; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.KerdCalc(p.oKerd) == Kerd.ST, J.Length, out J[3]);
                sr.Write("4; умеренная СТ; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.KerdCalc(p.oKerd) == Kerd.HST, J.Length, out J[4]);
                sr.Write("5; выраженная СТ; " + line);
                
                sr.Write(Environment.NewLine);
                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[3];

                sr.Write(";Экономичность кровообращения (коэффициент)");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.EconCalc(p.oEcon) == Econ.Normal, J.Length, out J[0]);
                sr.Write("1; нормальная; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.EconCalc(p.oEcon) == Econ.Low, J.Length, out J[1]);
                sr.Write("2; снижение; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.EconCalc(p.oEcon) == Econ.Stress, J.Length, out J[2]);
                sr.Write("3; напряжение; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[3];

                sr.Write(";Частота сердечных сокращений");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.HBFCalc(p.hbf_idle, p.gender, p.age) == HBF.Brad, J.Length, out J[0]);
                sr.Write("1; брадикальная; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.HBFCalc(p.hbf_idle, p.gender, p.age) == HBF.Normal, J.Length, out J[0]);
                sr.Write("2; нормальная; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.HBFCalc(p.hbf_idle, p.gender, p.age) == HBF.Tahy, J.Length, out J[0]);
                sr.Write("3; тахикардия; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write(";Показатель двойного произведения");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.gender, p.age) == STP.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.gender, p.age) == STP.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.gender, p.age) == STP.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.gender, p.age) == STP.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.gender, p.age) == STP.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[3];

                sr.Write(";Типы кровообращения");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.TypeCalc(p.oType) == Type.Hyper, J.Length, out J[0]);
                sr.Write("1; гиперкинетический; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.TypeCalc(p.oType) == Type.Eu, J.Length, out J[1]);
                sr.Write("2; эукинетический; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.TypeCalc(p.oType) == Type.Hypo, J.Length, out J[2]);
                sr.Write("3; гипокинетический; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[3];

                sr.Write(";Индекс функциональных изменений");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FuncCalc(p.oFunc) == Func.Satisf, J.Length, out J[0]);
                sr.Write("1; удовлетв. адапт.; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FuncCalc(p.oFunc) == Func.Stress, J.Length, out J[1]);
                sr.Write("2; напряжение; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FuncCalc(p.oFunc) == Func.Frustr, J.Length, out J[2]);
                sr.Write("3; неудовлетворит.; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write("; Гибкость");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.flexibility) == Flex.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.flexibility) == Flex.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.flexibility) == Flex.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.flexibility) == Flex.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.flexibility) == Flex.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write("; Индекс Шаповаловой");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.gender, p.age) == Shap.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.gender, p.age) == Shap.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.gender, p.age) == Shap.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.gender, p.age) == Shap.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.gender, p.age) == Shap.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write("; Прыжок в длину");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.jump, p.gender, p.age) == Jump.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.jump, p.gender, p.age) == Jump.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.jump, p.gender, p.age) == Jump.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.jump, p.gender, p.age) == Jump.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.jump, p.gender, p.age) == Jump.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write("; Индекс Руфье");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.age) == Roof.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.age) == Roof.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.age) == Roof.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.age) == Roof.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.age) == Roof.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);


                J = new double[5];

                sr.Write("; Кистевая динамометрия");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.DynamCalc(p.dynam, p.gender, p.age) == Dynam.Satisf, J.Length, out J[0]);
                sr.Write("1; удовлетворительно; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.DynamCalc(p.dynam, p.gender, p.age) == Dynam.Frustr, J.Length, out J[1]);
                sr.Write("2; неудовлетворительно; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);
            }
            //foreach(Person p in list)
        }
    }
}
