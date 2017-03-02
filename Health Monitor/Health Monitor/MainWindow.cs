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

        public void ControlsEnabled(bool choose)
        {
            if (choose)
            {
                btnDel.Enabled = true;
                btnChange.Enabled = true;
                btnExp.Enabled = true;
            }
            else
            {
                btnDel.Enabled = false;
                btnChange.Enabled = false;
                btnExp.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add_dialog.add = true;
            add_dialog.ShowDialog();
            if (add_dialog.save) {
                // При добавлении первой записи включаем кнопки возможности удаления и изменения
                if (grid.RowCount == 0)
                {
                    ControlsEnabled(true);
                }
                // И добавляем саму запись
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
                    if (p.Age >= minAge && p.Age <= maxAge)
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
            sr.Write(p.Name + "; ");
            sr.Write(p.Gender + "; ");
            sr.Write(p.Age + "; ");
            sr.Write(p.Diag + "; ");
            sr.Write(p.Volume + "; ");
            sr.Write(p.Time + "; ");
            sr.Write(p.Hbf_idle + "; ");
            sr.Write(p.Hbf_load + "; ");
            sr.Write(p.Hbf_return + "; ");
            sr.Write(p.Syst + "; ");
            sr.Write(p.Dyast + "; ");
            sr.Write(p.Lift + "; ");
            sr.Write(p.Height + "; ");
            sr.Write(p.Weight + "; ");
            sr.Write(p.Circle + "; ");
            sr.Write(p.CircleFull + "; ");
            sr.Write(p.Flexibility + "; ");
            sr.Write(p.Jump + "; ");
            sr.Write(p.Dynam + "; ");
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
            else
            {
                return;
            }
            // Раскомментировать для старого поведения...
            //list = new BindingList<Person>();
            grid.DataSource = list;
            using (StreamReader sr = new StreamReader(fname, Encoding.GetEncoding(1251)))
            {
                string line = sr.ReadLine();
                string[] test = line.Split(';');
                {
                    if (test[0]!="ФИО ")
                    {
                        return;
                    }
                }

                while ((line = sr.ReadLine()) != null)
                {
                    Person obj = new Person();
                    string[] fields = line.Split(';');
                    obj.Name = fields[0].Trim();
                    obj.Gender = fields[1].Trim()[0];
                    obj.Age = double.Parse(fields[2]);
                    obj.Diag = fields[3].Trim();
                    obj.Volume = double.Parse(fields[4]);
                    obj.Time = double.Parse(fields[5]);
                    obj.Hbf_idle = double.Parse(fields[6]);
                    obj.Hbf_load = double.Parse(fields[7]);
                    obj.Hbf_return = double.Parse(fields[8]);
                    obj.Syst = double.Parse(fields[9]);
                    obj.Dyast = double.Parse(fields[10]);
                    obj.Lift = double.Parse(fields[11]);
                    obj.Height = double.Parse(fields[12]);
                    obj.Weight = double.Parse(fields[13]);
                    obj.Circle = double.Parse(fields[14]);
                    obj.CircleFull = double.Parse(fields[15]);
                    obj.Flexibility = double.Parse(fields[16]);
                    obj.Jump = double.Parse(fields[17]);
                    obj.Dynam = double.Parse(fields[18]);
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
            // А есть ли что удалять?
            if (grid.RowCount == 0)
            {
                return;
            }
            var ind = grid.CurrentRow.Index;
            list.RemoveAt(ind);
        }

        private string format_line(Func<Person, bool> predicate, int num, out double j) {
            double all = list.Count();
            var l = list.Where(predicate);
            var n = l.Count();
            double all_a = list.Where(p => p.Diag == "Здоров").Count();
            double all_b = all - all_a;
            var na = l.Where(p => p.Diag == "Здоров").Count();
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
            double all_a = list.Where(p => p.Diag == "Здоров").Count();
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

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.Gender, p.Age) == Skir.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.Gender, p.Age) == Skir.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.Gender, p.Age) == Skir.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.Gender, p.Age) == Skir.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ScirbCalc(p.oSkir, p.Gender, p.Age) == Skir.Low, J.Length, out J[4]);
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

                line = format_line(p => Person.HBFCalc(p.Hbf_idle, p.Gender, p.Age) == HBF.Brad, J.Length, out J[0]);
                sr.Write("1; брадикальная; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.HBFCalc(p.Hbf_idle, p.Gender, p.Age) == HBF.Normal, J.Length, out J[0]);
                sr.Write("2; нормальная; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.HBFCalc(p.Hbf_idle, p.Gender, p.Age) == HBF.Tahy, J.Length, out J[0]);
                sr.Write("3; тахикардия; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write(";Показатель двойного произведения");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.Gender, p.Age) == STP.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.Gender, p.Age) == STP.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.Gender, p.Age) == STP.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.Gender, p.Age) == STP.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.STPCalc(p.oSTP, p.Gender, p.Age) == STP.Low, J.Length, out J[4]);
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

                line = format_line(p => Person.FlexCalc(p.Flexibility) == Flex.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.Flexibility) == Flex.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.Flexibility) == Flex.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.Flexibility) == Flex.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.FlexCalc(p.Flexibility) == Flex.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write("; Индекс Шаповаловой");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.Gender, p.Age) == Shap.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.Gender, p.Age) == Shap.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.Gender, p.Age) == Shap.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.Gender, p.Age) == Shap.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.ShapCalc(p.oShap, p.Gender, p.Age) == Shap.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write("; Прыжок в длину");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.Jump, p.Gender, p.Age) == Jump.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.Jump, p.Gender, p.Age) == Jump.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.Jump, p.Gender, p.Age) == Jump.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.Jump, p.Gender, p.Age) == Jump.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.JumpCalc(p.Jump, p.Gender, p.Age) == Jump.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);

                J = new double[5];

                sr.Write("; Индекс Руфье");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.Age) == Roof.High, J.Length, out J[0]);
                sr.Write("1; высокий; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.Age) == Roof.HighMid, J.Length, out J[1]);
                sr.Write("2; выше среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.Age) == Roof.Middle, J.Length, out J[2]);
                sr.Write("3; средний; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.Age) == Roof.LowMid, J.Length, out J[3]);
                sr.Write("4; ниже среднего; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.RoofCalc(p.oRoof, p.Age) == Roof.Low, J.Length, out J[4]);
                sr.Write("5; низкий; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);


                J = new double[5];

                sr.Write("; Кистевая динамометрия");
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.DynamCalc(p.Dynam, p.Gender, p.Age) == Dynam.Satisf, J.Length, out J[0]);
                sr.Write("1; удовлетворительно; " + line);
                sr.Write(Environment.NewLine);

                line = format_line(p => Person.DynamCalc(p.Dynam, p.Gender, p.Age) == Dynam.Frustr, J.Length, out J[1]);
                sr.Write("2; неудовлетворительно; " + line);
                sr.Write(Environment.NewLine);

                sr.Write(summ_line(J.Sum()));
                sr.Write(Environment.NewLine);
            }
            //foreach(Person p in list)
        }
    }
}
