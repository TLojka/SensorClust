using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Program
    {
       static FaultDetector faultDetector;
       public static List<KeyValuePair<int, double>> LISTEvents;
       public static List<KeyValuePair<int, double>> LISTFlow;
       public static List<KeyValuePair<int, double>> LISTLikeHutFlow;
        static void Main(string[] args)
        {
//            NeuralNetwork netw = new NeuralNetwork();

            faultDetector = new FaultDetector(0.01,0.9,10);
            LoadPatterns();
        
            FaultDetector.NewEventDetected += new FaultDetector.NewEvent(faultDetector_NewEventDetected);
        }
        /// <summary>
        /// Detekcia prekrocenia limitov
        /// </summary>
        /// <param name="H1">Hypoteza1</param>
        /// <param name="H2">Hypoteza2</param>
        /// <param name="n">velkost window</param>
        /// <returns></returns>
        public List<KeyValuePair<int, double>> DetectFault(double H1, double H2, int n)
        {
            LISTEvents = new List<KeyValuePair<int, double>>();
            LISTFlow = new List<KeyValuePair<int, double>>();
            LISTLikeHutFlow = new List<KeyValuePair<int, double>>();

            faultDetector = new FaultDetector(H1, H2, n);
            LoadPatterns();

            return LISTEvents;
        }

        static int i = 0;
        private static void LoadPatterns()
        {
            StreamReader file = File.OpenText("Patterns.csv");
            char [] split  = new char[]{' ','\t'};

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            
            i = 0;
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                string[] value = line.Split(split);
                faultDetector_AddValue(System.Convert.ToDouble(value[0]));
               LISTFlow.Add(new KeyValuePair<int,double>(i, System.Convert.ToDouble(value[0])));
               //LISTEvents.Add(new KeyValuePair<int,double>(i, x));
               LISTLikeHutFlow.Add(new KeyValuePair<int,double>(i,FaultDetector.Likehout));
               i++;
            }
            file.Close();
        }


        static void faultDetector_AddValue(double x)
        {
            faultDetector.FaultDetector_AddValue(x);
            //throw new NotImplementedException();
        }

        public static double x;
        public static void faultDetector_NewEventDetected(eventType eventtype)
        {
            x = eventtype.value;
            LISTEvents.Add(new KeyValuePair<int, double>(i, x));
            //LIST.Add(new KeyValuePair<int,double>(LIST[LIST.Count-1].Key+1, eventtype.value));
            Console.WriteLine("New event " + eventtype.value);    
            //throw new NotImplementedException();
        }
    }
}
