using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Context
{
    class Context
    {
        static void Main(string[] args)
        {
            Context1();
        }

        public static void Context1()
        {
            JSON js = new JSON();

            js.Write(new Rules() { Id = 1, Name = "Prve pravidlo", Description = "skusobne pravidlo", Conditions = new string[] { "value>1", "value <2" }, TrueActivities = new string[] { "true", "true" }, FalseActivities = new string[] { "false", "false" }, });
            List <Rules> a = js.getData();
        }
    }
}
