﻿using System;
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
    public enum AgeMin {Child = 7, Middle = 11, High = 15}
    public enum AgeMax {Child = 10, Middle = 14, High = 18}

    public class Person
    {
        // Входные переменные
        public Person () {
            Name = "Иванов Иван Иванович";
            Gender = 'м';
            Age = 11;
            Diag = "Здоров";
            Volume = 2500;
            Time = 30;
            Hbf_idle = 60;
            Hbf_load = 95;
            Hbf_return = 65;
            Syst = 120;
            Dyast = 70;
            Lift = 20;
            Height = 160;
            Weight = 50;
            Circle = 82;
            CircleFull = 85;
            Flexibility = 10;
            Jump = 160;
            Dynam = 15;
        }

        public Person Copy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.Name = string.Copy(Name);
            other.Diag = string.Copy(Diag);
            return other;
        }
        [System.ComponentModel.DisplayName("ФИО")]
        public string Name { get; set; }
        
        [System.ComponentModel.DisplayName("Пол")]
        public char Gender{get;set;}
        
        [System.ComponentModel.DisplayName("Возраст")]
        public double Age{get;set;}

        [System.ComponentModel.DisplayName("Диагноз")]
        public string Diag { get; set; }

        [System.ComponentModel.DisplayName("ЖЁЛ")]
        public double Volume{get;set;}

        [System.ComponentModel.DisplayName("Время задержки дыхания")]
        public double Time{get;set;}
        
        // Частота сердечных сокращений
        [System.ComponentModel.DisplayName("ЧСС покоя")]
        public double Hbf_idle{get;set;}

        [System.ComponentModel.DisplayName("ЧСС нагрузки")]
        public double Hbf_load{get;set;}

        [System.ComponentModel.DisplayName("ЧСС Восстановления")]
        public double Hbf_return{get;set;} 
        
        // Систолическое и Дистолическое давление
        [System.ComponentModel.DisplayName("Систолическое давление")]
        public double Syst{get;set;}

        [System.ComponentModel.DisplayName("Диастолическое давление")]
        public double Dyast{get;set;}

        [System.ComponentModel.DisplayName("Подъём туловища в сед")]
        public double Lift{get;set;}
        // Подъёмов тела

        [System.ComponentModel.DisplayName("Рост")]
        public double Height {get;set;}

        [System.ComponentModel.DisplayName("Вес")]
        public double Weight {get;set;} 


        // Окружность грудной клетки
        [System.ComponentModel.DisplayName("Окружность грудной клетки")]
        public double Circle { get; set; }

        [System.ComponentModel.DisplayName("Окружность грудной клетки на вдохе")]
        public double CircleFull { get; set; }

        [System.ComponentModel.DisplayName("Гибкость")]
        public double Flexibility{get;set;} 
        // Гибкость

        [System.ComponentModel.DisplayName("Прыжок с места")]
        public double Jump{get;set;}

        [System.ComponentModel.DisplayName("Кистевая динамометрия")]
        public double Dynam{get;set;}
        // Динамометрия


        [System.ComponentModel.DisplayName("Экскурсия грудной клетки")]
        public double oExcurcion { get {return CircleFull-Circle ;} }


        // Рассчёт индекса Пинье
        [System.ComponentModel.DisplayName("Индекс Пинье")]
        public double oPinj { get { return Height - (Weight + Circle);} }

        // Рассчёт вегетативного индекса Кердо
        [System.ComponentModel.DisplayName("Индекс Кердо")]
        public double oKerd { get { return (1 - Dyast / Hbf_idle) * 100;} }

        // Рассчёт индекса Руфье
        [System.ComponentModel.DisplayName("Индекс Руфье")]
        public double oRoof { get { return (Hbf_idle+Hbf_load+Hbf_return-200)/10;} }
        
        // Рассчёт индекса Шаповаловой
        [System.ComponentModel.DisplayName("Индекс Шаповалова")]
        public double oShap { get { return 1000*Weight/Height*Lift/60;} }
        
        // Рассчёт индекса Скирбинского
        [System.ComponentModel.DisplayName("Индекс Скирбинского")]
        public double oSkir { get { return Volume*Time/Hbf_idle;} }
        
        // Рассчёт индекса функциональных изменений
        [System.ComponentModel.DisplayName("Индекс функциональных изменений")]
        public double oFunc { get { return 0.011 * Hbf_idle 
            + 0.014 * Syst + 0.008 * Dyast 
            + 0.009 * Weight - 0.009 * Height 
            + 0.014 * Age - 0.27;} }
        
        // Тип кровообращения
        [System.ComponentModel.DisplayName("Тип кровообращения")]
        public double oType { get { return (Syst-Dyast)*200/(Syst+Dyast)/(167.2*Weight*Height*0.0001);} }
        
        // Показатель двойного преломления
        [System.ComponentModel.DisplayName("Показатель двойного произведения")]
        public double oSTP { get { return (Hbf_idle*Syst)/100;} }

        // Рассчёт экономичности кровообращения
        [System.ComponentModel.DisplayName("Рассчёт экономичности кровообращения")]
        public double oEcon { get { return (Syst-Dyast)*Hbf_idle;} }




        // Суммарный диагностический коэффициент
        [System.ComponentModel.DisplayName("Суммарный диагностический коэффициент")]
        public int oSumm 
        { 
            get 
            {
                return (int)PinCalc(oPinj) 
                     + (int)ExcCalc(oExcurcion)
                     + (int)ScirbCalc(oSkir, Gender, Age)
                     + (int)KerdCalc(oKerd)
                     + (int)EconCalc(oEcon)
                     + (int)HBFCalc(Hbf_idle, Gender, Age)
                     + (int)STPCalc(oSTP, Gender, Age)
                     + (int)TypeCalc(oType)
                     + (int)FuncCalc(oFunc)
                     + (int)FlexCalc(Flexibility)
                     + (int)ShapCalc(oShap, Gender, Age)
                     + (int)JumpCalc(Jump, Gender, Age)
                     + (int)RoofCalc(oRoof, Age)
                     + (int)DynamCalc(Dynam, Gender, Age);
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
                    if (Diag == "Здоров")
                    {
                        return "Занятия ФК в подготовительной группе";
                    }
                    return "Занятия ФК в специальной медицинской группе";                   
                }
                if (oSumm >= 6 && oSumm < 13)
                {
                    if (Diag == "Здоров")
                    {
                        return "Занятия ФК в основной группе";
                    }
                    return "Занятия ФК в специальной медицинской группе.";
                }
                // if (oSumm >= 13)
                if (Diag == "Здоров")
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
        public static Skir ScirbCalc(double pin, char ch, double age)
        {
            if (age >= 11 && age <= 14)
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
                if (pin > 1746)
                return Skir.High;
            }
           
            if (age >= 15 && age <= 18)
            {
                if (ch == 'м')
                {
                    if (pin <= 1199)
                        return Skir.Low;
                    if (pin > 1199 && pin <= 1515)
                        return Skir.LowMid;
                    if (pin > 1515 && pin <= 2788)
                        return Skir.Middle;
                    if (pin > 2788 && pin <= 3424)
                        return Skir.HighMid;
                    if (pin > 3424)
                        return Skir.High;
                }

                if (pin <= 899)
                    return Skir.Low;
                if (pin > 899 && pin <= 1149)
                    return Skir.LowMid;
                if (pin > 1149 && pin <= 1700)
                    return Skir.Middle;
                if (pin > 1700 && pin <= 2000)
                    return Skir.HighMid;
                if (pin > 2000)
                    return Skir.High;
            }

            if (age >= 7 && age <= 11)
            {
                if (ch == 'м')
                {
                    if (pin <= 361)
                        return Skir.Low;
                    if (pin > 361 && pin <= 453)
                        return Skir.LowMid;
                    if (pin > 453 && pin <= 638)
                        return Skir.Middle;
                    if (pin > 638 && pin <= 730)
                        return Skir.HighMid;
                    if (pin > 730)
                        return Skir.High;
                }

                if (pin <= 241)
                    return Skir.Low;
                if (pin > 241 && pin <= 344)
                    return Skir.LowMid;
                if (pin > 344 && pin <= 551)
                    return Skir.Middle;
                if (pin > 551 && pin <= 654)
                    return Skir.HighMid;
                //if (pin > 654)
                  //  return Skir.High;
            }
            return Skir.High; // Вывод по умолчанию
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
        public static HBF HBFCalc(double pin, char ch, double age)
        {
            if (age >= 11 && age <= 14)
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
            if (age >= 15 && age <= 18)
            {
                if (ch == 'м')
                {
                    if (pin <= 55)
                        return HBF.Brad;
                    if (pin > 55 && pin <= 80)
                        return HBF.Normal;
                    //if (pin > 80)
                    return HBF.Tahy;
                }

                if (pin <= 60)
                    return HBF.Brad;
                if (pin > 60 && pin <= 90)
                    return HBF.Normal;
                //if (pin > 90)
                return HBF.Tahy;
            }
            if (age >= 7 && age <= 10)
            {
                if (ch == 'м')
                {
                    if (pin <= 55)
                        return HBF.Brad;
                    if (pin > 55 && pin <= 107)
                        return HBF.Normal;
                    //if (pin > 107)
                    return HBF.Tahy;
                }

                if (pin <= 55)
                    return HBF.Brad;
                if (pin > 55 && pin <= 107)
                    return HBF.Normal;
                //if (pin > 107)
                //return HBF.Tahy;
            }
            return HBF.Tahy;
        }


        // Рассчёт диагностических коэффициэнтов
        // Показатель двойного произведения
        public static STP STPCalc(double pin, char gender, double age)
        {
            if (age >= 11 && age <= 14)
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

            if (age >= 15 && age <= 18)
            {
                if (gender == 'м')
                {
                    if (pin <= 70)
                        return STP.High;
                    if (pin > 70 && pin <= 80)
                        return STP.HighMid;
                    if (pin > 80 && pin <= 107)
                        return STP.Middle;
                    if (pin > 107 && pin <= 115)
                        return STP.LowMid;
                    if (pin > 115)
                        return STP.Low;
                }

                if (pin <= 70)
                    return STP.High;
                if (pin > 70 && pin <= 85)
                    return STP.HighMid;
                if (pin > 85 && pin <= 100)
                    return STP.Middle;
                if (pin > 100 && pin <= 110)
                    return STP.LowMid;
                //if (pin > 110)
                return STP.Low;
            }

            if (age >= 7 && age <= 10)
            {
                if (gender == 'м')
                {
                    if (pin <= 70)
                        return STP.High;
                    if (pin > 70 && pin <= 79)
                        return STP.HighMid;
                    if (pin > 79 && pin <= 108)
                        return STP.Middle;
                    if (pin > 108 && pin <= 116)
                        return STP.LowMid;
                    if (pin > 116)
                        return STP.Low;
                }

                if (pin <= 70)
                    return STP.High;
                if (pin > 70 && pin <= 83)
                    return STP.HighMid;
                if (pin > 83 && pin <= 105)
                    return STP.Middle;
                if (pin > 105 && pin <= 110)
                    return STP.LowMid;
                //if (pin > 110)
                //return STP.Low;
            }
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
        public static Shap ShapCalc(double pin, char gender, double age)
        {
            if (age >= 11 && age <= 14)
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

            if (age >= 15 && age <= 18)
            {
                if (gender == 'м')
                {
                    if (pin <= 194)
                        return Shap.Low;
                    if (pin > 194 && pin <= 219)
                        return Shap.LowMid;
                    if (pin > 219 && pin <= 270)
                        return Shap.Middle;
                    if (pin > 270 && pin <= 295)
                        return Shap.HighMid;
                    if (pin > 295)
                        return Shap.High;
                }

                if (pin <= 212)
                    return Shap.Low;
                if (pin > 212 && pin <= 245)
                    return Shap.LowMid;
                if (pin > 245 && pin <= 312)
                    return Shap.Middle;
                if (pin > 312 && pin <= 345)
                    return Shap.HighMid;
                //if (pin > 345)
                return Shap.High;
            }

            if (age >= 7 && age <= 10)
            {
                if (gender == 'м')
                {
                    if (pin <= 63)
                        return Shap.Low;
                    if (pin > 63 && pin <= 88)
                        return Shap.LowMid;
                    if (pin > 88 && pin <= 99)
                        return Shap.Middle;
                    if (pin > 99 && pin <= 110)
                        return Shap.HighMid;
                    if (pin > 110)
                        return Shap.High;
                }

                if (pin <= 62)
                    return Shap.Low;
                if (pin > 62 && pin <= 76)
                    return Shap.LowMid;
                if (pin > 76 && pin <= 105)
                    return Shap.Middle;
                if (pin > 105 && pin <= 119)
                    return Shap.HighMid;
                //if (pin > 119)
                //return Shap.High;
            }
            return Shap.High;
        }


        // Рассчёт диагностических коэффициэнтов
        // Прыжок
        public static Jump JumpCalc(double pin, char gender, double age)
        {
            if (age >= 11 && age <= 14)
            {
                if (gender == 'м')
                {
                    if (pin <= 170)
                        return Health_Monitor.Jump.Low;
                    if (pin > 170 && pin <= 187)
                        return Health_Monitor.Jump.LowMid;
                    if (pin > 187 && pin <= 199)
                        return Health_Monitor.Jump.Middle;
                    if (pin > 199 && pin <= 209)
                        return Health_Monitor.Jump.HighMid;
                    if (pin > 209)
                        return Health_Monitor.Jump.High;
                }

                if (pin <= 150)
                    return Health_Monitor.Jump.Low;
                if (pin > 150 && pin <= 168)
                    return Health_Monitor.Jump.LowMid;
                if (pin > 168 && pin <= 181)
                    return Health_Monitor.Jump.Middle;
                if (pin > 181 && pin <= 194)
                    return Health_Monitor.Jump.HighMid;
                //if (pin > 194)
                return Health_Monitor.Jump.High;
            }

            if (age >= 15 && age <= 18)
            {
                if (gender == 'м')
                {
                    if (pin <= 180)
                        return Health_Monitor.Jump.Low;
                    if (pin > 180 && pin <= 194)
                        return Health_Monitor.Jump.LowMid;
                    if (pin > 194 && pin <= 210)
                        return Health_Monitor.Jump.Middle;
                    if (pin > 210 && pin <= 229)
                        return Health_Monitor.Jump.HighMid;
                    if (pin > 229)
                        return Health_Monitor.Jump.High;
                }

                if (pin <= 160)
                    return Health_Monitor.Jump.Low;
                if (pin > 160 && pin <= 169)
                    return Health_Monitor.Jump.LowMid;
                if (pin > 169 && pin <= 190)
                    return Health_Monitor.Jump.Middle;
                if (pin > 190 && pin <= 209)
                    return Health_Monitor.Jump.HighMid;
                //if (pin > 209)
                return Health_Monitor.Jump.High;
            }

            if (age >= 7 && age <= 10)
            {
                if (gender == 'м')
                {
                    if (pin <= 110)
                        return Health_Monitor.Jump.Low;
                    if (pin > 110 && pin <= 124)
                        return Health_Monitor.Jump.LowMid;
                    if (pin > 124 && pin <= 145)
                        return Health_Monitor.Jump.Middle;
                    if (pin > 145 && pin <= 164)
                        return Health_Monitor.Jump.HighMid;
                    if (pin > 164)
                        return Health_Monitor.Jump.High;
                }

                if (pin <= 100)
                    return Health_Monitor.Jump.Low;
                if (pin > 100 && pin <= 124)
                    return Health_Monitor.Jump.LowMid;
                if (pin > 124 && pin <= 140)
                    return Health_Monitor.Jump.Middle;
                if (pin > 140 && pin <= 154)
                    return Health_Monitor.Jump.HighMid;
                //if (pin > 154)
                //return Jump.High;
            }
            return Health_Monitor.Jump.High;
        }
        
        // Рассчёт диагностических коэффициэнтов
        // Индекс Руфье
        public static Roof RoofCalc(double pin, double age)
        {
            if (age >= 11 && age <= 14)
            {
                if (pin <= 6.5)
                    return Roof.High;
                if (pin > 6.5 && pin <= 9.4)
                    return Roof.HighMid;
                if (pin > 9.4 && pin <= 11.4)
                    return Roof.Middle;
                if (pin > 11.4 && pin <= 16.4)
                    return Roof.LowMid;
                // if (pin > 16.4)
                return Roof.Low;
            }
            if (age >= 15 && age <= 18)
            {
                if (pin <= 5.0)
                    return Roof.High;
                if (pin > 5.0 && pin <= 7.9)
                    return Roof.HighMid;
                if (pin > 7.9 && pin <= 9.9)
                    return Roof.Middle;
                if (pin > 9.9 && pin <= 14.9)
                    return Roof.LowMid;
                // if (pin > 14.9)
                return Roof.Low;
            }
            if (age >= 7 && age <= 10)
            {
                if (pin <= 10.0)
                    return Roof.High;
                if (pin > 10.0 && pin <= 13.2)
                    return Roof.HighMid;
                if (pin > 13.2 && pin <= 15.2)
                    return Roof.Middle;
                if (pin > 15.2 && pin <= 20.0)
                    return Roof.LowMid;
                // if (pin > 20.0)
                //return Roof.Low;
            }
            return Roof.Low;
        }

        // Рассчёт диагностических коэффициэнтов
        // Кистевая Динамометрия
        public static Dynam DynamCalc(double pin, char gender, double age)
        {
            if (age >= 11 && age <= 14)
            {
                if (gender == 'м')
                {
                    if (pin <= 26.5)
                        return Health_Monitor.Dynam.Frustr;
                    if (pin > 26.5)
                        return Health_Monitor.Dynam.Satisf;
                }

                if (pin <= 23.5)
                    return Health_Monitor.Dynam.Frustr;
                //if (pin > 23.5)
                return Health_Monitor.Dynam.Satisf;
            }
            if (age >= 15 && age <= 18)
            {
                if (gender == 'м')
                {
                    if (pin <= 39.4)
                        return Health_Monitor.Dynam.Frustr;
                    if (pin > 39.4)
                        return Health_Monitor.Dynam.Satisf;
                }

                if (pin <= 28.7)
                    return Health_Monitor.Dynam.Frustr;
                //if (pin > 28.7)
                return Health_Monitor.Dynam.Satisf;
            }
            if (age >= 7 && age <= 10)
            {
                if (gender == 'м')
                {
                    if (pin <= 10.7)
                        return Health_Monitor.Dynam.Frustr;
                    if (pin > 10.7)
                        return Health_Monitor.Dynam.Satisf;
                }

                if (pin <= 9.9)
                    return Health_Monitor.Dynam.Frustr;
                //if (pin > 9.9)
                //return Dynam.Satisf;
            }
            return Health_Monitor.Dynam.Satisf;
        }

    }
}
