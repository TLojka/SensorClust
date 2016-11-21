using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
   public class eventType
    {
        public double value;
        public string message = "Message";
        public string type;
    }

    class FaultDetector
    {   
        private double H1;
        private double H2;
        private int n { set; get; }
        private double Sum { set; get; }
        private double constant;
        private double[] poleHodnot;
        public static double Likehout;
        private double a;
        private double b;

        public delegate double NewValues (double x); 
        public delegate void NewEvent(eventType eventtype);
        public event NewValues AddValue;  //externe volany event pre pridanie novej hodnoty do pola hodnot 
        public static event NewEvent NewEventDetected;

        
        /// <summary>
        /// konstruktor pre Sequential probability ratio test (SPRT)
        /// </summary>
        /// <param name="H1">Hypoteza1 Down, H1<1</param>
        /// <param name="H2">Hypoteza2 UP,H1<1</param>
        /// <param name="n">SizeOfWindow</param>
        public FaultDetector (double H1, double H2, int n)
        {
            this.H1 = H1;
            this.H2 = H2;
            this.n = n;

            double A = -10; double B = 10; //0,01,5   1 800
            a = Math.Log10(A) / (H2 - H1);
            b = Math.Log10(B) / (H2 - H1);


            constant = Math.Log10(H2 / H1);
//            ErrorI = H1 / (1 - H2);
//            ErrorII = (1 - H1) / H2;

            poleHodnot = new double[n];
            
            NewEventDetected += new FaultDetector.NewEvent(Program.faultDetector_NewEventDetected);               
            this.AddValue += FaultDetector_AddValue;
        }

        public double FaultDetector_AddValue(double x)
        {
            //x = x / 10;
            //rotation of vector due a new value in row
            for (int i = 0; i < n; i++)
            {
                if (i < n - 1)
                    poleHodnot[i] = poleHodnot[i + 1];
                else
                    poleHodnot[i] = x;
            }
            CalcSum();

            LogLikeHoodRatio();
            //Likehout += ((H2 - H1) / H2 * H1) * x ;
         //   evaluateDetection();

           return Likehout;
        }

        /// <summary>
        /// Vyhodnoti ci dané zmena vedie proces do dobreho smeru
        /// </summary>
        private void evaluateDetection()
        { 
            eventType eventArgument = new eventType();
           
            if (Likehout > b )  //chybaII 
            {
                eventArgument.value = Likehout;
                eventArgument.type = "HI";
                NewEventDetected(eventArgument);
            }
            if (Likehout < a)  //chybaI
            {
                eventArgument.value = Likehout;
                eventArgument.type = "Nizka";  
                NewEventDetected(eventArgument);
            }
            
        }

        /// <summary>
        /// The cumulative sum of the LLFs (log-likelihood function) for all x 
        /// </summary>
        private double LogLikeHoodRatio ()
        {
            return Likehout = ((H2 - H1) / H2 * H1) * Sum - n;//* constant;
        }

        private double LogLikeHoodRatio2()
        {
            Likehout = Math.Exp((H2-H1)*Sum - n/2*(H2*H2 - H1*H1));
            
            if (a > Likehout)
            {
                System.Console.WriteLine("Event LO");
                evaluateDetection();
            }
            if (b < Likehout)
            {
                System.Console.WriteLine("Event HI");
                evaluateDetection();
            }
            return Likehout;
        }

        private double CalcSum ()
        {
            Sum = poleHodnot.Sum();
            return Sum;
        }

    }
}
