using System;

namespace Rsp_NoDB{
    public class Game{
       public Guid playerID { get; set; }
        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
    }
}