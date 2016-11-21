using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway_Version1.DeviceManager
{
    

    public class BL_DeviceManagment
    {
        private Devices devices;
        private DeviceCLusterring clustering;

        public delegate void DeviceHandler(DeviceDataTemplate device);
        public delegate void DeviceHandlerPosition(DeviceDataTemplate device, double xPosition, double yPosition);
        public event DeviceHandler DeviceFoundEvent;
        public event DeviceHandler RemoveDeviceEvent;
        public event DeviceHandler ClusterIDChange;
        public event DeviceHandlerPosition DevicePositionChanged;


        public BL_DeviceManagment()
        {
            devices = new Devices();
            //clustering = new DeviceCLusterring();
            DeviceFoundEvent += new DeviceHandler(devices.ADDdevice);
            RemoveDeviceEvent += new DeviceHandler(devices.RemoveDevice);
            DevicePositionChanged += new DeviceHandlerPosition(devices.ChangePosition);               
            InitialDeviceClustering();

            //testing 
            //TestingMethod();
        }

        //iniclaizacia zariadeni, na debagovacie uvčely, nasledne by sa to malo diať automaticky
        private void InitialDeviceClustering()
        {
            
        }

        public void ADDNewDevice(DeviceDataTemplate dev)
        {
            DeviceFoundEvent(dev); //udalost pre pridanie zariadenia
        }

        public void RemoveDevice(DeviceDataTemplate dev)
        {
            RemoveDeviceEvent(dev); //udalost pre odstranenie zariadenia
        }

        public void DeviceChangePosition(DeviceDataTemplate dev, double xPosition, double yPosition)
        {
            DeviceChangePosition(dev, xPosition, yPosition);
        }

        public List<DeviceDataTemplate> GetdeviceList()
        {
            return devices.GetListOfDevice();
        }

        /// <summary>
        /// Iba na testovanie metoda
        /// </summary>

        public void TestingMethod()
        {
            // simulovaný vstup 
            double[][] rawData = new double[20][];
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
            rawData[10] = new double[] { 17.0, 190.0 };
            rawData[11] = new double[] { 25.0, 210.0 };
            rawData[12] = new double[] { 14.0, 170.0 };
            rawData[13] = new double[] { 20.0, 210.0 };
            rawData[14] = new double[] { 11.0, 110.0 };
            rawData[15] = new double[] { 28.0, 260.0 };
            rawData[16] = new double[] { 16.0, 170.0 };
            rawData[17] = new double[] { 29.0, 260.0 };
            rawData[18] = new double[] { 18.0, 210.0 };
            rawData[19] = new double[] { 21.0, 210.0 };

            Random rn = new Random();
            //Manually creted deviced for clustering
            for (int i = 0; i < 20; i++)
            {
                DeviceManager.DeviceDataTemplate de = new DeviceManager.DeviceDataTemplate(i, 0, "TrainDevice"+i, "virtual", DeviceManager.DEVICE_STATE.Good, rawData[i], rn.Next(-100, 200), rn.Next(-100, 200));
                this.ADDNewDevice(de);
            }

            MaunlKmenatStart();
        }

        ///Manualne spustenie triedenia
        public void MaunlKmenatStart()
        {
            K_Mean.Main _kmean = new K_Mean.Main();

            double[][] raw = new double[devices.DeviceList.Count][];
            for (int i = 0; i < devices.DeviceList.Count; i++)
            {
                raw[i] = devices.DeviceList[i].DeviceParamValues;
            }

            int[] vystupVektor = _kmean.Clustering(3, raw);
            PriradVektor(vystupVektor);    
        }
        
        /// <summary>
        /// Pridari zariadnie do clustra prostredníctvom vstupného vektora fukncie, hodnota clustra je v atribute ClusterID, každého zariadenia.
        /// </summary>
        /// <param name="Vektor">Vektor hodnot v poradi v akom su zariadenia zozname.</param>
        private void PriradVektor(int[] Vektor)
        {
            int i = 0;
            foreach (DeviceDataTemplate device in devices.DeviceList)
            {
                if (device.ClusterID != Vektor[i])
                {
                    device.ClusterID = Vektor[i];
                    ClusterIDChange(device);
                }

                i++;
            }

        }

    }
}
