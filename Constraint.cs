using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex
{
    public class Constraint
    {
        public double[] vars;
        public double b;
        public string sign;
        public double[] S;
        public Constraint(double[] vars, double b, string sign)
        {
            if (sign == "=")
            {
                this.vars = vars;
                this.b = b;
                this.sign = sign;
            }
            else
                MessageBox.Show(new ArgumentException("Wrong value").ToString());
            
        }
    }
}
