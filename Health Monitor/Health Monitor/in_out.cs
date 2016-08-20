using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Health_Monitor
{
    public class Person
    {
        // Входные переменные
        [System.ComponentModel.DisplayName("ФИО")]
        public string name { get; set; }
        
        [System.ComponentModel.DisplayName("Пол")]
        public char gender{get;set;}
        
        [System.ComponentModel.DisplayName("Возраст")]
        public double age{get;set;}

        [System.ComponentModel.DisplayName("ЖЁЛ")]
        public double volume{get;set;}
        // ЖЁЛ

        [System.ComponentModel.DisplayName("Время задержки дыхания")]
        public double time{get;set;}
        // Время задержки дыхания
        
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
        public double oSTR { get { return (hbf_idle*syst)/100;} }

        // Рассчёт экономичности кровообращения
        [System.ComponentModel.DisplayName("Рассчёт экономичности кровообращения")]
        public double oEcon { get { return (syst-dyast)*hbf_idle;} }




        // Суммарный диагностический коэффициент
        [System.ComponentModel.DisplayName("Суммарный диагностический коэффициент")]
        public double oSumm 
        { 
            get 
            {
                if (gender == 'м')
                {
                    if (true)
                    {

                    }
                }
                else
                {

                }
                return 0;
            } 
        }

        [System.ComponentModel.DisplayName("Заключение")]
        // Диагноз
        public double oConc
        { 
            get 
            { 
                return 0;
            } 
        }

        // ------------------------------------------------
        // ------------------Функции-----------------------
        // ------------------------------------------------

        // Рассчёт диагностических коэффициэнтов
        // Индекс Пинье
        public static int PinCalc(double pin)
        {

            if (pin <= 10)
                return 2;
            if (pin > 10 && pin <= 20)
                return 5;
            if (pin > 20 && pin <= 25)
                return 6;
            if (pin > 25 && pin <= 36)
                return -2;
            //if (pin > 36)
                return -8;

        }

        // Рассчёт диагностических коэффициэнтов
        // Экскурсия грудной клетки
        public static int ExcCalc(double pin)
        {
            
            if (pin < 5)
                return -4;
            if (pin >= 5 && pin <= 9)
                return 2;
            //if (pin > 9)
                return 3;

        }


        // Рассчёт диагностических коэффициэнтов
        // Индекс Скирбинского
        public static int ScirbCalc(double pin, char ch)
        {
            
            if (ch == 'м')
            {
                if (pin <= 1147)
                    return -4;
                if (pin > 1147 && pin <= 1407)
                    return -2;
                if (pin > 1407 && pin <= 1940)
                    return 3;
                if (pin > 1940 && pin <= 2206)
                    return 8;
                if (pin > 2207)
                    return 9;
            }

            if (pin <= 865)
                return -4;
            if (pin > 865 && pin <= 1010)
                return -2;
            if (pin > 1010 && pin <= 1501)
                return 3;
            if (pin > 1501 && pin <= 1746)
                return 8;
            //if (pin > 1746)
                return 9;

        }

        // Рассчёт диагностических коэффициэнтов
        // Индекс Кердо
        public static int KerdCalc(double pin)
        {
            
            if (pin <= -15)
                return 1;
            if (pin > -15 && pin <= -8)
                return 9;
            if (pin > -8 && pin <= 5)
                return 8;
            if (pin > 5 && pin <= 14)
                return -1;
            // if (pin > 14)
                return -4;
            
        }

        // Рассчёт диагностических коэффициэнтов
        // Экономичность кровообращения
        public static int EconCalc(double pin)
        {
            
            if (pin < 2500)
                return -1;
            if (pin >= 2500 && pin <= 3000)
                return 3;
            // if (pin > 3000)
                return -3;
            
        }


        // Рассчёт диагностических коэффициэнтов
        // ЧСС
        public static int HBFCalc(double pin, char ch)
        {
            
            if (ch == 'м')
            {
                if (pin <= 70)
                    return 1;
                if (pin > 70 && pin <= 80)
                    return 4;
                //if (pin > 80)
                    return -8;
            }

            if (pin <= 55)
                return 1;
            if (pin > 55 && pin <= 102)
                return 4;
            //if (pin > 102)
                return -8;         
            
        }


        // Рассчёт диагностических коэффициэнтов
        // Показатель двойного произведения
        private static int STRCalc(double pin, char gender)
        {

            if (gender == 'м')
            {
                if (pin <= 70)
                    return 7;
                if (pin > 70 && pin <= 78)
                    return 4;
                if (pin > 78 && pin <= 108)
                    return 0;
                if (pin > 108 && pin <= 114)
                    return -10;
                if (pin > 114)
                    return -12;
            }

            if (pin <= 70)
                return 7;
            if (pin > 70 && pin <= 78)
                return 4;
            if (pin > 78 && pin <= 106)
                return 0;
            if (pin > 106 && pin <= 114)
                return -10;
            //if (pin > 114)
                return -12;
        }

        // Рассчёт диагностических коэффициэнтов
        // Тип кровообращения
        public static int TypeCalc(double pin)
        {
            if (pin < 32)
                return -6;
            if (pin >= 32 && pin <= 47)
                return 2;
            //if (pin > 47)
                return -2;
        }

        // Рассчёт диагностических коэффициэнтов
        // Индекс функциональных изменений
        public static int FuncCalc(double pin)
        {
            if (pin < 2.59)
                return 2;
            if (pin >= 2.59 && pin <= 3.09)
                return -12;
            //if (pin > 47)
            return -14;
        }

        // Рассчёт диагностических коэффициэнтов
        // Гибкость
        public static int FlexCalc(double pin)
        {
            if (pin <= -5)
                return -8;
            if (pin > -5 && pin <= -1)
                return 2;
            if (pin > -1 && pin <= 5)
                return 8;
            if (pin > 5 && pin <= 9)
                return 1;
            // if (pin > 9)
            return 0;
        }

        // Рассчёт диагностических коэффициэнтов
        // Индекс Шаповаловой
        private static int ShapCalc(double pin, char gender)
        {

            if (gender == 'м')
            {
                if (pin <= 128)
                    return -6;
                if (pin > 128 && pin <= 157)
                    return -3;
                if (pin > 158 && pin <= 217)
                    return 0;
                if (pin > 217 && pin <= 246)
                    return 8;
                if (pin > 246)
                    return 11;
            }

            if (pin <= 193)
                return -6;
            if (pin > 193 && pin <= 216)
                return -3;
            if (pin > 216 && pin <= 253)
                return 0;
            if (pin > 253 && pin <= 276)
                return 8;
            //if (pin > 276)
            return 11;
        }


        // Рассчёт диагностических коэффициэнтов
        // Прыжок
        private static int JumpCalc(double pin, char gender)
        {

            if (gender == 'м')
            {
                if (pin <= 170)
                    return -2;
                if (pin > 170 && pin <= 187)
                    return -1;
                if (pin > 187 && pin <= 199)
                    return 2;
                if (pin > 199 && pin <= 209)
                    return 3;
                if (pin > 209)
                    return 6;
            }

            if (pin <= 150)
                return -2;
            if (pin > 150 && pin <= 168)
                return -1;
            if (pin > 168 && pin <= 181)
                return 2;
            if (pin > 181 && pin <= 194)
                return 3;
            //if (pin > 194)
            return 6;
        }
        
        // Рассчёт диагностических коэффициэнтов
        // Индекс Руфье
        public static int RoofCalc(double pin)
        {
            if (pin <= 6.5)
                return 3;
            if (pin > 6.5 && pin <= 9.4)
                return 1;
            if (pin > 9.4 && pin <= 11.4)
                return 0;
            if (pin > 11.4 && pin <= 16.4)
                return -1;
            // if (pin > 9)
            return -3;
        }

        // Рассчёт диагностических коэффициэнтов
        // Кистевая Динамометрия
        public static int DynamCalc(double pin, char gender)
        {
            if (gender == 'м')
            {
                if (pin <= 26.5)
                    return -3;
                if (pin > 26.5)
                    return 10;
            }

            if (pin <= 23.5)
                return -3;
            //if (pin > 23.5)
            return 10;
        }



    }
}
