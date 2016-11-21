using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Mean
{
    public class Main
    {
        int[] clustersVector;
        /// <summary>
        /// metoda pre testovanie KMEAN použitím simulovaných dát
        /// </summary>
        /// <param name="numberOfClusters">Počet klástrov</param>
        public void Main_auto(int numberOfClusters, double[][] rawData)
        {
            // potom main doplnit o argumetny rawData a počet klastrov, koli lepsiej modularnosti pri implementácii

            Console.WriteLine("\n Start of k-means clustering\n");

            // simulovaný vstup 
            rawData = new double[20][];
            rawData[0] = new double[] { 25.0, 220.0 };
            rawData[1] = new double[] { 13.0, 160.0 };
            rawData[2] = new double[] { 28.0, 270.0 };
            rawData[3] = new double[] { 15.0, 120.0 };
            rawData[4] = new double[] { 15.0, 150.0 };
            rawData[5] = new double[] { 27.0, 240.0 };
            rawData[6] = new double[] { 18.0, 230.0 };
            rawData[7] = new double[] { 20.0, 220.0 };
            rawData[8] = new double[] { 12.0, 130.0 };
            rawData[9] = new double[] { 26.0, 280.0 };
            rawData[10] = new double[] { 17.0, 180.0 };
            rawData[11] = new double[] { 25.0, 210.0 };
            rawData[12] = new double[] { 14.0, 170.0 };
            rawData[13] = new double[] { 20.0, 210.0 };
            rawData[14] = new double[] { 11.0, 110.0 };
            rawData[15] = new double[] { 28.0, 260.0 };
            rawData[16] = new double[] { 16.0, 170.0 };
            rawData[17] = new double[] { 29.0, 260.0 };
            rawData[18] = new double[] { 18.0, 210.0 };
            rawData[19] = new double[] { 21.0, 210.0 };

            Console.WriteLine("Raw unclustered data:\n");
            Console.WriteLine("    Height Weight");
            Console.WriteLine("-------------------");
            //ShowData(rawData, 1, true, true);

            int numClusters = numberOfClusters; //System.Convert.ToInt32(args[0]);

            Console.WriteLine("\n Počet klastrov nastavený na " + numClusters);
            int [] a;
            KMeans klastrovac = new KMeans(rawData, numClusters,out a);

            //sekvencia pre klastrovanie hodnôt 
        
        }

        /// <summary>
        /// Metoda na vypocet KMeans pouzitim dát z SQL databázy
        /// </summary>
        /// <param name="numberOfClusters">počet klástrov</param>
        public void Main_autoSQL(int numberOfClusters)
        {
            // NOT IMPLEMENTED YEAT
        }

        /// <summary>
        /// Metoda na vypocet KMeans pouzitim dát z objetu device managment vo forme double[][]
        /// </summary>
        /// <param name="numberOfClusters"></param>
        public int[] Clustering(int numberOfClusters, double[][] rawData)
        {
            int [] vystup;
           KMeans klastrovac = new KMeans(rawData, numberOfClusters, out vystup);
           return vystup;
            //return System.Convert.ToInt32(a);
            
        }

    }
}
