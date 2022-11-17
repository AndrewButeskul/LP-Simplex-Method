using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex
{
    public class Basis
    {
        double c;
        int index;

        public Basis() {}

        public Basis(double c, int index)
        {
            this.c = c;
            this.index = index;
        }

       /* public double C { get; set; }
        public double Index { get; set; }*/

        //public double C => c;

        public double C { 
            set { c = value; } 
            get { return c; }
        }

        public int Index
        {
            set { index = value; }
            get { return index; }   
        }
       // public double Index => index;



    }
}
