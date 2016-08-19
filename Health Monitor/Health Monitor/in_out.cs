using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Health_Monitor
{
    public class in_out
    {
        // Входные переменные
        [System.ComponentModel.DisplayName("Пол")]
        public char Gender{get;set;}
        
        [System.ComponentModel.DisplayName("ФИО")]
        public string FIO {get;set;}
        
        [System.ComponentModel.DisplayName("Возраст")]
        public double Age{get;set;}

        [System.ComponentModel.DisplayName("ЖЁЛ")]
        public double Volume{get;set;}
        // ЖЁЛ

        [System.ComponentModel.DisplayName("Время задержки дыхания")]
        public double Time{get;set;}
        // Время задержки дыхания
        
        // 3 далее - Частота сердечных сокращений
        // в покое, нагрузке, через 30 секунд
        [System.ComponentModel.DisplayName("ЧСС покоя")]
        public double HBFIdle{get;set;}

        [System.ComponentModel.DisplayName("ЧСС нагрузки")]
        public double HBFLoad{get;set;}

        [System.ComponentModel.DisplayName("ЧСС Восстановления")]
        public double HBFReturn{get;set;} 
        
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
        public double oKerd { get { return (1 - Dyast / HBFIdle) * 100;} }

        // Рассчёт индекса Руфье
        [System.ComponentModel.DisplayName("Индекс Руфье")]
        public double oRoof { get { return (HBFIdle+HBFLoad+HBFReturn-200)/10;} }
        
        // Рассчёт индекса Шаповаловой
        [System.ComponentModel.DisplayName("Индекс Шаповалова")]
        public double oShap { get { return Weight/Height*Lift/60;} }
        
        // Рассчёт индекса Скирбинского
        [System.ComponentModel.DisplayName("Индекс Скирбинского")]
        public double oSkir { get { return Volume*Time/HBFIdle;} }
        
        // Рассчёт индекса функциональных изменений
        [System.ComponentModel.DisplayName("Индекс функциональных изменений")]
        public double oFunc { get { return 0.011 * HBFIdle 
            + 0.014 * Syst + 0.008 * Dyast 
            + 0.009 * Weight - 0.009 * Height 
            + 0.0014 * Age - 0.27;} }
        
        // Тип кровообращения
        [System.ComponentModel.DisplayName("Тип кровообращения")]
        public double oType { get { return (Syst-Dyast)*200/(Syst-Dyast)/(167.2*Weight*Height*0.0001);} }
        
        // Показатель двойного преломления
        [System.ComponentModel.DisplayName("Показатель двойного преломления")]
        public double oSTR { get { return (HBFIdle*Syst)/100;} }

        // Рассчёт экономичности кровообращения
        [System.ComponentModel.DisplayName("Коэффициент двойного преломления")]
        public double oEcon { get { return (Syst-Dyast)*HBFIdle;} }
        
        // Суммарный диагностический коэффициент
        [System.ComponentModel.DisplayName("Суммарный диагностический коэффициент")]
        public double oSumm 
        { 
            get 
            { 
                return 0;
            } 
        }

        [System.ComponentModel.DisplayName("Диагноз")]
        // Диагноз
        public double oDiag 
        { 
            get 
            { 
                return 0;
            } 
        }

    }
}
