using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Operation
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Time { get; set; }

        public Operation(string code, string name, double time)
        {
            this.Code = code;
            this.Name = name;
            this.Time = time;
        }

        public override string ToString()
        {
            return "Operation: code -> " + this.Code + ", name -> " + this.Name + ", time -> " + this.Time;
        }
    }
}
