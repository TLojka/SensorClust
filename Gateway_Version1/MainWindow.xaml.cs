using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gateway_Version1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Gateway : Window
    {
        public DeviceManager.BL_DeviceManagment _deviceManager;
        public Gateway()
        {
           // InitializeComponent();
            Inicialization();

        }
        public void Inicialization()
        {
            //DeviceManager.DeviceCLusterring clustering = new DeviceManager.DeviceCLusterring();

            _deviceManager = new DeviceManager.BL_DeviceManagment();

            
            /*object a = new object();
            a = 1;
            DeviceManager.DeviceValues asas = new DeviceManager.DeviceValues("Device",a);
            List<DeviceManager.DeviceValues> dasd = new List<DeviceManager.DeviceValues>();
            dasd.Add(asas);*/
           
            //_kmean.Clustering(3,rawData);

           // _deviceManager.RemoveDevice(de);
        }

        public void RunTesting()
        {        
        _deviceManager.TestingMethod();
        }
    }
}
