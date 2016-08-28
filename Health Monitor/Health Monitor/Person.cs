using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Health_Monitor
{
    // Много Enum для if-ов и выгрузки в таблицы
    public enum Pinie { Strong = 2, Good = 5, Middle = 6, Weak = -2, Bad = -8 };
    public enum Excurcion { High = 3, Middle = 2, Low = -4 };
    public enum Skir { High = 9, HighMid = 8, Middle = 3, LowMid = -2, Low = -4 };
    public enum Kerd { HVT = 1, VT = 9, Eit = 8, ST = -1, HST = -4 };
    public enum Econ { Normal = 3, Low = -1, Stress = -3 };
    public enum HBF { Brad = 1, Normal = 4, Tahy = -8 };
    public enum STP { High = 7, HighMid = 4, Middle = 0, LowMid = -10, Low = -12 };
    public enum Type { Hyper = -2, Eu = 2, Hypo = -6 };
    public enum Func { Satisf = 2, Stress = -12, Frustr = -14 };
    public enum Flex { High = 0, HighMid = 1, Middle = 8, LowMid = 2, Low = -8 };
    public enum Shap { High = 11, HighMid = 8, Middle = 0, LowMid = -3, Low = -6 };
    public enum Jump { High = 6, HighMid = 3, Middle = 2, LowMid = -1, Low = -2 };
    public enum Roof { High = 3, HighMid = 1, Middle = 0, LowMid = -1, Low = -3 };
    public enum Dynam { Satisf = 10, Frustr = -3 };

    public class Person
    {
        // Входные переменные
        public Person () {
            name = "Иванов Иван Иванович";
            gender = 'м';
            age = 16;
            diag = "Здоров";
            volume = 2500;
            time = 30;
            hbf_idle = 60;
            hbf_load = 95;
            hbf_return = 65;
            syst = 120;
            dyast = 70;
            lift = 20;
            height = 160;
            weight = 50;
            circle = 82;
            circleFull = 85;
            flexibility = 10;
            jump = 160;
            dynam = 15;
        }

        public Person Copy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.name = string.Copy(name);
            other.diag = string.Copy(diag);
            return other;
        }
        [System.ComponentModel.DisplayName("ФИО")]
        public string name { get; set; }
        
        [System.ComponentModel.DisplayName("Пол")]
        public char gender{get;set;}
        
        [System.ComponentModel.DisplayName("Возраст")]
        public double age{get;set;}

        [System.ComponentModel.DisplayName("Диагноз")]
        public string diag { get; set; }

        [System.ComponentModel.DisplayName("ЖЁЛ")]
        public double volume{get;set;}

        [System.ComponentModel.DisplayName("Время задержки дыхания")]
        public double time{get;set;}
        
        // Частота сердечных сокращений
        [System.ComponentModel.DisplayName("ЧСС покоя")]
        public double hbf_idle{get;set;}

        [System.ComponentModel.DisplayName("ЧСС нагрузки")]
        public double hbf_load{get;set;}

        [System.ComponentModel.DisplayName("ЧСС Восстановления")]
        public double hbf_return{get;set;} 
        
        // Систолическое и Дистолическое давление
        [System.ComponentModel.DisplayName("Систолическое давление")]
        public double syst{get;set;}

        [System.ComponentModel.DisplayName("Диастолическое давление")]
        public double dyast{get;set;}

        [System.ComponentModel.DisplayName("Подъём туловища в сед")]
        public double lift{get;set;}
        // Подъёмов тела

        [System.ComponentModel.DisplayName("Рост")]
        public double height {get;set;}

        [System.ComponentModel.DisplayName("Вес")]
        public double weight {get;set;} 


        // Окружность грудной клетки
        [System.ComponentModel.DisplayName("Окружность грудной клетки")]
        public double circle { get; set; }

        [System.ComponentModel.DisplayName("Окружность грудной клетки на вдохе")]
        public double circleFull { get; set; }

        [System.ComponentModel.DisplayName("Гибкость")]
        public double flexibility{get;set;} 
        // Гибкость

        [System.ComponentModel.DisplayName("Прыжок с места")]
        public double jump{get;set;}

        [System.ComponentModel.DisplayName("Кистевая динамометрия")]
        public double dynam{get;set;}
        // Динамометрия


        [System.ComponentModel.DisplayName("Экскурсия грудной клетки")]
        public double oExcurcion { get {return circleFull-circle ;} }


        // Рассчёт индекса Пинье
        [System.ComponentModel.DisplayName("Индекс Пинье")]
        public double oPinj { get { return height - (weight + circle);} }

        // Рассчёт вегетативного индекса Кердо
        [System.ComponentModel.DisplayName("Индекс Кердо")]
        public double oKerd { get { return (1 - dyast / hbf_idle) * 100;} }

        // Рассчёт индекса Руфье
        [System.ComponentModel.DisplayName("Индекс Руфье")]
        public double oRoof { get { return (hbf_idle+hbf_load+hbf_return-200)/10;} }
        
        // Рассчёт индекса Шаповаловой
        [System.ComponentModel.DisplayName("Индекс Шаповалова")]
        public double oShap { get { return weight/height*lift/60;} }
        
        // Рассчёт индекса Скирбинского
        [System.ComponentModel.DisplayName("Индекс Скирбинского")]
        public double oSkir { get { return volume*time/hbf_idle;} }
        
        // Рассчёт индекса функциональных изменений
        [System.ComponentModel.DisplayName("Индекс функциональных изменений")]
        public double oFunc { get { return 0.011 * hbf_idle 
            + 0.014 * syst + 0.008 * dyast 
            + 0.009 * weight - 0.009 * height 
            + 0.0014 * age - 0.27;} }
        
        // Тип кровообращения
        [System.ComponentModel.DisplayName("Тип кровообращения")]
        public double oType { get { return (syst-dyast)*200/(syst-dyast)/(167.2*weight*height*0.0001);} }
        
        // Показатель двойного преломления
        [System.ComponentModel.DisplayName("Показатель двойного произведения")]
        public double oSTP { get { return (hbf_idle*syst)/100;} }

        // Рассчёт экономичности кровообращения
        [System.ComponentModel.DisplayName("Рассчёт экономичности кровообращения")]
        public double oEcon { get { return (syst-dyast)*hbf_idle;} }




        // Суммарный диагностический коэффициент
        [System.ComponentModel.DisplayName("Суммарный диагностический коэффициент")]
        public int oSumm 
        { 
            get 
            {
                return (int)PinCalc(oPinj) 
                     + (int)ExcCalc(oExcurcion)
                     + (int)ScirbCalc(oSkir, gender)
                     + (int)KerdCalc(oKerd)
                     + (int)EconCalc(oEcon)
                     + (int)HBFCalc(hbf_idle, gender)
                     + (int)STPCalc(oSTP, gender)
                     + (int)TypeCalc(oType)
                     + (int)FuncCalc(oFunc)
                     + (int)FlexCalc(flexibility)
                     + (int)ShapCalc(oShap, gender)
                     + (int)JumpCalc(jump, gender)
                     + (int)RoofCalc(oRoof)
                     + (int)DynamCalc(dynam, gender);
            } 
        }

        [System.ComponentModel.DisplayName("Заключение")]
        // Диагноз
        public string oConc
        { 
            get 
            { 
                if (oSumm < -13)
                {
                    return "Занятия ФК в специальной медицинской группе";
                }
                if (oSumm >= -13 && oSumm < 6)
                {
                    if (diag == "Здоров")
                    {
                        return "Занятия ФК в подготовительной группе";
                    }
                    return "Занятия ФК в специальной медицинской группе";                   
                }
                if (oSumm >= 6 && oSumm < 13)
                {
                    if (diag == "Здоров")
                    {
                        return "Занятия ФК в основной группе";
                    }
                    return "В спецификации ваш случай не рассмотрен. ПОЗДРАВЛЯЮ, ВЫ - дивергент. Занятия ФК в специальной медицинской группе.";
                }
                // if (oSumm >= 13)
                if (diag == "Здоров")
                {
                    return "Занятия ФК в основной группе";
                }
                return "Занятия ФК в подготовительной группе";

            } 
        }

        // ------------------------------------------------
        // ------------------Функции-----------------------
        // ------------------------------------------------

        // Рассчёт диагностических коэффициэнтов
        // Индекс Пинье
        public static Pinie PinCalc(double pin)
        {

            if (pin <= 10)
                return Pinie.Strong;
            if (pin > 10 && pin <= 20)
                return Pinie.Good;
            if (pin > 20 && pin <= 25)
                return Pinie.Middle;
            if (pin > 25 && pin <= 36)
                return Pinie.Weak;
            //if (pin > 36)
                return Pinie.Bad;

        }

        // Рассчёт диагностических коэффициэнтов
        // Экскурсия грудной клетки
        public static Excurcion ExcCalc(double pin)
        {
            
            if (pin < 5)
                return Excurcion.Low;
            if (pin >= 5 && pin <= 9)
                return Excurcion.Middle;
            //if (pin > 9)
                return Excurcion.High;

        }


        // Рассчёт диагностических коэффициэнтов
        // Индекс Скирбинского
        public static Skir ScirbCalc(double pin, char ch)
        {
            
            if (ch == 'м')
            {
                if (pin <= 1147)
                    return Skir.Low;
                if (pin > 1147 && pin <= 1407)
                    return Skir.LowMid;
                if (pin > 1407 && pin <= 1940)
                    return Skir.Middle;
                if (pin > 1940 && pin <= 2206)
                    return Skir.HighMid;
                if (pin > 2207)
                    return Skir.High;
            }

            if (pin <= 865)
                return Skir.Low;
            if (pin > 865 && pin <= 1010)
                return Skir.LowMid;
            if (pin > 1010 && pin <= 1501)
                return Skir.Middle;
            if (pin > 1501 && pin <= 1746)
                return Skir.HighMid;
            //if (pin > 1746)
                return Skir.High;

        }

        // Рассчёт диагностических коэффициэнтов
        // Индекс Кердо
        public static Kerd KerdCalc(double pin)
        {
            if (pin <= -15)
                return Kerd.HVT;
            if (pin > -15 && pin <= -8)
                return Kerd.VT;
            if (pin > -8 && pin <= 5)
                return Kerd.Eit;
            if (pin > 5 && pin <= 14)
                return Kerd.ST;
            // if (pin > 14)
                return Kerd.HST;   
        }

        // Рассчёт диагностических коэффициэнтов
        // Экономичность кровообращения
        public static Econ EconCalc(double pin)
        {
            if (pin < 2500)
                return Econ.Low;
            if (pin >= 2500 && pin <= 3000)
                return Econ.Normal;
            // if (pin > 3000)
                return Econ.Stress;
        }


        // Рассчёт диагностических коэффициэнтов
        // ЧСС
        public static HBF HBFCalc(double pin, char ch)
        {
            if (ch == 'м')
            {
                if (pin <= 70)
                    return HBF.Brad;
                if (pin > 70 && pin <= 80)
                    return HBF.Normal;
                //if (pin > 80)
                    return HBF.Tahy;
            }

            if (pin <= 55)
                return HBF.Brad;
            if (pin > 55 && pin <= 102)
                return HBF.Normal;
            //if (pin > 102)
                return HBF.Tahy;         
        }


        // Рассчёт диагностических коэффициэнтов
        // Показатель двойного произведения
        private static STP STPCalc(double pin, char gender)
        {
            if (gender == 'м')
            {
                if (pin <= 70)
                    return STP.High;
                if (pin > 70 && pin <= 78)
                    return STP.HighMid;
                if (pin > 78 && pin <= 108)
                    return STP.Middle;
                if (pin > 108 && pin <= 114)
                    return STP.LowMid;
                if (pin > 114)
                    return STP.Low;
            }

            if (pin <= 70)
                return STP.High;
            if (pin > 70 && pin <= 78)
                return STP.HighMid;
            if (pin > 78 && pin <= 106)
                return STP.Middle;
            if (pin > 106 && pin <= 114)
                return STP.LowMid;
            //if (pin > 114)
                return STP.Low;
        }

        // Рассчёт диагностических коэффициэнтов
        // Тип кровообращения
        public static Type TypeCalc(double pin)
        {
            if (pin < 32)
                return Type.Hypo;
            if (pin >= 32 && pin <= 47)
                return Type.Eu;
            //if (pin > 47)
                return Type.Hyper;
        }

        // Рассчёт диагностических коэффициэнтов
        // Индекс функциональных изменений
        public static Func FuncCalc(double pin)
        {
            if (pin < 2.59)
                return Func.Satisf;
            if (pin >= 2.59 && pin <= 3.09)
                return Func.Stress;
            //if (pin > 3.09)
            return Func.Frustr;
        }

        // Рассчёт диагностических коэффициэнтов
        // Гибкость
        public static Flex FlexCalc(double pin)
        {
            if (pin <= -5)
                return Flex.Low;
            if (pin > -5 && pin <= -1)
                return Flex.LowMid;
            if (pin > -1 && pin <= 5)
                return Flex.Middle;
            if (pin > 5 && pin <= 9)
                return Flex.HighMid;
            // if (pin > 9)
            return Flex.High;
        }

        // Рассчёт диагностических коэффициэнтов
        // Индекс Шаповаловой
        private static Shap ShapCalc(double pin, char gender)
        {

            if (gender == 'м')
            {
                if (pin <= 128)
                    return Shap.Low;
                if (pin > 128 && pin <= 157)
                    return Shap.LowMid;
                if (pin > 158 && pin <= 217)
                    return Shap.Middle;
                if (pin > 217 && pin <= 246)
                    return Shap.HighMid;
                if (pin > 246)
                    return Shap.High;
            }

            if (pin <= 193)
                return Shap.Low;
            if (pin > 193 && pin <= 216)
                return Shap.LowMid;
            if (pin > 216 && pin <= 253)
                return Shap.Middle;
            if (pin > 253 && pin <= 276)
                return Shap.HighMid;
            //if (pin > 276)
            return Shap.High;
        }


        // Рассчёт диагностических коэффициэнтов
        // Прыжок
        private static Jump JumpCalc(double pin, char gender)
        {

            if (gender == 'м')
            {
                if (pin <= 170)
                    return Jump.Low;
                if (pin > 170 && pin <= 187)
                    return Jump.LowMid;
                if (pin > 187 && pin <= 199)
                    return Jump.Middle;
                if (pin > 199 && pin <= 209)
                    return Jump.HighMid;
                if (pin > 209)
                    return Jump.High;
            }

            if (pin <= 150)
                return Jump.Low;
            if (pin > 150 && pin <= 168)
                return Jump.LowMid;
            if (pin > 168 && pin <= 181)
                return Jump.Middle;
            if (pin > 181 && pin <= 194)
                return Jump.HighMid;
            //if (pin > 194)
            return Jump.High;
        }
        
        // Рассчёт диагностических коэффициэнтов
        // Индекс Руфье
        public static Roof RoofCalc(double pin)
        {
            if (pin <= 6.5)
                return Roof.High;
            if (pin > 6.5 && pin <= 9.4)
                return Roof.HighMid;
            if (pin > 9.4 && pin <= 11.4)
                return Roof.Middle;
            if (pin > 11.4 && pin <= 16.4)
                return Roof.LowMid;
            // if (pin > 9)
            return Roof.Low;
        }

        // Рассчёт диагностических коэффициэнтов
        // Кистевая Динамометрия
        public static Dynam DynamCalc(double pin, char gender)
        {
            if (gender == 'м')
            {
                if (pin <= 26.5)
                    return Dynam.Frustr;
                if (pin > 26.5)
                    return Dynam.Satisf;
            }

            if (pin <= 23.5)
                return Dynam.Frustr;
            //if (pin > 23.5)
            return Dynam.Satisf;
        }



    }
}
