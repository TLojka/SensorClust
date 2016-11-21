using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway_Version1.DeviceManager
{
    public class DeviceDataTemplate
    {
        public int ID {get; set;}
        public int ClusterID { get; set; }
        public string DeviceName { get; set; }
        public string DeviceAddress { get; set; }

        public DEVICE_STATE DeviceState {get; set;}
        public double[] DeviceParamValues { get; set; }

        public DeviceDataTemplate obj;

        public System.Windows.Point position;

        public DeviceDataTemplate()
        {

        }
                
        //konštruktor pre device
        /// <summary>
        /// Vytvorenie zariadenia s jeho atributmi
        /// </summary>
        /// <param name="ID">Jeznoznačne ID zariadenie pridavané automaticky, možno nastaviť na 0</param>
        /// <param name="ClusterID">Cislo clustra, ktora sa vypočitava automaticky</param>
        /// <param name="DeviceName">Meno</param>
        /// <param name="DeviceAddress">Adresa zariadenia</param>
        /// <param name="DeviceState"></param>
        /// <param name="DeviceParamValues"></param>
        public DeviceDataTemplate(int ID, int ClusterID, string DeviceName, string DeviceAddress, DEVICE_STATE DeviceState, double[] DeviceParamValues, double xPosition, double yPosition)
        {
            this.ID = ID;
            this.ClusterID = ClusterID;
            this.DeviceName = DeviceName;
            this.DeviceAddress = DeviceAddress;
            this.DeviceState = DeviceState;
            this.DeviceParamValues = DeviceParamValues;
            this.position = new System.Windows.Point(xPosition,yPosition);
        }

    }


    public enum DEVICE_STATE
    { 
       None,
       Good,
       Bad,
       Error
    };

    class DeviceValues
    {
        public string ParameterName;
        public object value;

        public DeviceValues(string ParameterName, object value)
        {
            this.ParameterName = ParameterName;
            this.value = new object();
            this.value = value;
        }
    }

}
