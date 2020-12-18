using System;

namespace Rsp_NoDB{
    class Player{
        public int NumberOfGame{get; set;}
        private int round;
        public int MyProperty
        {
            get { return round; }
            set { round = value; }
        }
        
    }
}