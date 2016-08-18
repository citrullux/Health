using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Health_Monitor
{
    public class in_out
    {
        // Входные переменные
        public int Sex{get;set;}
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

        public float Height {get;set;} 
        public float Weight {get;set;} 
        public float Excurcion{get;set;}
        // Экскурсия грудной клетки
        public float Flexibility{get;set;} 
        // Гибкость
        public float Jump{get;set;}
        public float Dynam{get;set;}
        // Динамометрия
        
        public float oPinj { get { ;} }
        public float oKerd { get { ;} }
        public float oRoof { get { ;} }
        public float oShap { get { ;} }
        public float oSkir { get { ;} }
        public float oFunc { get { ;} }
        public float oType { get { ;} }
        public int oHBF { get { return HBFIdle; } }
        public float oSTR { get { ;} }
        public float oEcon { get { ;} }
        public float oFlex { get { ;} }
        public float oEcxs { get { ;} }
        public float oJump { get { ;} }
        public float oDynm { get { ;} }
        public float oSumm { get { ;} }
        public float oDiag { get { ;} }

    }
}
