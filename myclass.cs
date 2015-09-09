using System;
using System.Collections.Generic;


namespace reostat
{
   public class myclass
    {
        #region Constructor / Deconstructor
        public myclass()
        {
        }
        ~myclass()
        {
        }
        #endregion

        private int _current = 0; //A
        private int _voltage = 0;
        private int _power = 0;
        private int _pozReostat = 0;
        private int _pozDGU = 0;
        private double _pressOil = 0;
        private double _pressGas = 0;
        private int _rpmDGU = 0;
        private int _voltageBort;
        private int _currentExciter;
        private double _tempBort = 0;
        private double _tempWater = 0;
        private double _tempOil = 0;
        private double _tempCil1 = 0;
        private double _tempCil2 = 0;
        private double _tempCil3 = 0;
        private double _tempCil4 = 0;
        private double _tempCil5 = 0;
        private double _tempCil6 = 0;
        private double _tempCil7 = 0;
        private double _tempCil8 = 0;
        private double _tempCil9 = 0;
        private double _tempCil10 = 0;
        private double _tempCil11 = 0;
        private double _tempCil12 = 0;
        private string _typeLoc = "";
        private string _numberLoc = "";
        private bool _flagWork = false;
        private bool _stateVSH1 = false;
        private bool _stateVSH2 = false;
        private bool _stateObduv = false;
        private bool _flagValid = false;
        private int _time = 0;
        private int _powerDGU = 0;        
        private ExtData _extData=new ExtData();
        private SwitchRele _switchRele = new SwitchRele();

        

        public ExtData ExtDataPoint
        {
            get { return _extData; }
            set { _extData = value; }
        }

        public SwitchRele SwitchRelePoint
        {
            get { return _switchRele; }
            set { _switchRele = value; }
        }

       
        public double PressOil
        {
            get { return _pressOil; }
            set { _pressOil = value; }
        }

        public double PressGas
        {
            get { return _pressGas; }
            set { _pressGas = value; }
        }

        public int RpmDGU
        {
            get { return _rpmDGU; }
            set { _rpmDGU = value; }
        }

        public int PowerDGU
        {
            get { return _powerDGU; }
            set { _powerDGU = value; }
        }

        public int CurrentExciter
        {
            get { return _currentExciter; }
            set { _currentExciter = value; }
        }

        public int VoltageBort
        {
            get { return _voltageBort; }
            set { _voltageBort = value; }
        }

        public bool StateVSH1
        {
            get { return _stateVSH1; }
            set { _stateVSH1 = value; }
        }

        public bool FlagValid
        {
            get { return _flagValid; }
            set { _flagValid = value; }
        }

        public bool StateVSH2
        {
            get { return _stateVSH2; }
            set { _stateVSH2 = value; }
        }

        public bool StateObduv
        {
            get { return _stateObduv; }
            set { _stateObduv = value; }
        } 
       
       public bool FlagWork
        {
            get { return _flagWork; }
            set { _flagWork = value; }
        }

       public int Time
       {
           get { return _time; }
           set { _time = value; }
       }

        public int Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public int Voltage
        {
            get { return _voltage; }
            set { _voltage = value; }
        }

        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public int PozReostat
        {
            get { return _pozReostat; }
            set { _pozReostat = value; }
        }

       public int PozDGU
        {
            get { return _pozDGU; }
            set { _pozDGU = value; }
        }

       public double TempBort
       {
           get { return _tempBort; }
           set { _tempBort = value; }
       }

       public double TempWater
       {
           get { return _tempWater; }
           set { _tempWater = value; }
       }

       public double TempOil
       {
           get { return _tempOil; }
           set { _tempOil = value; }
       }

       public double TempCil1
       {
           get { return _tempCil1; }
           set { _tempCil1 = value; }
       }

       public double TempCil2
       {
           get { return _tempCil2; }
           set { _tempCil2 = value; }
       }

       public double TempCil3
       {
           get { return _tempCil3; }
           set { _tempCil3 = value; }
       }

       public double TempCil4
       {
           get { return _tempCil4; }
           set { _tempCil4 = value; }
       }

       public double TempCil5
       {
           get { return _tempCil5; }
           set { _tempCil5 = value; }
       }

       public double TempCil6
       {
           get { return _tempCil6; }
           set { _tempCil6 = value; }
       }

       public double TempCil7
       {
           get { return _tempCil7; }
           set { _tempCil7 = value; }
       }

       public double TempCil8
       {
           get { return _tempCil8; }
           set { _tempCil8 = value; }
       }


       public double TempCil9
       {
           get { return _tempCil9; }
           set { _tempCil9 = value; }
       }

       public double TempCil10
       {
           get { return _tempCil10; }
           set { _tempCil10 = value; }
       }

       public double TempCil11
       {
           get { return _tempCil11; }
           set { _tempCil11 = value; }
       }


       public double TempCil12
       {
           get { return _tempCil12; }
           set { _tempCil12 = value; }
       }

        public string TypeLoc
        {
            get { return _typeLoc; }
            set { _typeLoc = value; }
        }

        public string NumberLoc
        {
            get { return _numberLoc; }
            set { _numberLoc = value; }
        }
    }
}