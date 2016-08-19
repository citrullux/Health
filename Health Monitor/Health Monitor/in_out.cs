using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Health_Monitor
{
    public class in_out
    {
        // Входные переменные
        public int Gender{get;set;}
        public string FIO {get;set;}
        public int Age{get;set;}
        public int Volume{get;set;}
        // ЖЁЛ
        public int Time{get;set;}
        // Время задержки дыхания
        
        // 3 далее - Частота сердечных сокращений
        // в покое, нагрузке, через 30 секунд
        public int HBFIdle{get;set;} 
        public int HBFLoad{get;set;} 
        public int HBFReturn{get;set;} 
        
        // Систолическое и Дистолическое давление
        public int Syst{get;set;} 
        public int Dyast{get;set;}

        public int Lift{get;set;}
        // Подъёмов тела

        public double Height {get;set;} 
        public double Weight {get;set;} 


        // Окружность грудной клетки
        public double Circle { get; set; }
        public double CircleFull { get; set; }

        public double Flexibility{get;set;} 
        // Гибкость
        public double Jump{get;set;}
        public double Dynam{get;set;}
        // Динамометрия


        public double Excurcion { get {return CircleFull-Circle ;} }
        // Рассчёт индекса Пинье
        public double oPinj { get { return Height - (Weight + Circle);} }

        // Рассчёт вегетативного индекса Кердо
        public double oKerd { get { return (1 - Dyast / HBFIdle) * 100;} }

        // Рассчёт индекса Руфье
        public double oRoof { get { return (HBFIdle+HBFLoad+HBFReturn-200)/10;} }
        
        // Рассчёт индекса Шаповаловой
        public double oShap { get { return Weight/Height*Lift/60;} }
        
        // Рассчёт индекса Скирбинского
        public double oSkir { get { return Volume*Time/HBFIdle;} }
        
        // Рассчёт индекса функциональных изменений
        public double oFunc { get { return 0.011 * HBFIdle + 0.014 * Syst + 0.008 * Dyast + 0.009 * Weight - 0.009 * Height + 0.0014 * Age - 0.27;} }
        
        // Тип кровообращения
        public double oType { get { return (Syst-Dyast)*200/(Syst-Dyast)/(167.2*Weight*Height*0.0001);} }
        
        // ЧСС
        public int oHBF { get { return HBFIdle; } }
        
        // Показатель двайного преломления
        public double oSTR { get { return (HBFIdle*Syst)/100;} }

        // Рассчёт экономичности кровообращения
        public double oEcon { get { return (Syst-Dyast)*HBFIdle;} }
        
        // Суммарный диагностический коэффициент
        public double oSumm 
        { 
            get 
            { 
                return 0;
            } 
        }
        
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
