using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway_Version1.DeviceManager
{
    class Devices
    {
       public List<DeviceDataTemplate> DeviceList;
       public static int _sequencer {get;set;} //sekvencer umoží lešiu identifikáciu zariadeni a pracu v databáze

        public Devices()
        {
            DeviceList = new List<DeviceDataTemplate>();
        }
        
        /// <summary>
        /// Metoda pre pridanie nového zariadenia
        /// </summary>
        public void ADDdevice(DeviceDataTemplate device)
        {
            DeviceList.Add(device);
            _sequencer = findID();
        }

        /// <summary>
        /// Metoda pre odstranenie zariadenia
        /// </summary>
        public void RemoveDevice(DeviceDataTemplate device)
        {
            device= DeviceList.Find(x => x.DeviceAddress == device.DeviceAddress); //podla adresy doplni nepovynny parameter ID zariadenia;
            DeviceList.Remove(device);
        }

        public void RemoveAllDevices()
        {
            DeviceList.Clear();     //ODSTRANI VSETKY ZARIADENIA
        }

        public List<DeviceDataTemplate> GetListOfDevice()
        {
            return DeviceList;
        }

        public void ChangePosition(DeviceDataTemplate device, double xPosition, double yPosition)
        {
            device.position = new System.Windows.Point(xPosition, yPosition);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Najde voľný index pre zariadenie
        /// </summary>
        private int findID()
        {
            int ID_test=0;
            bool loop= true;

            while (loop)
            {
                if (DeviceList.Exists(x => x.ID == ID_test))
                    ID_test++;
                else
                    loop = false;
            }
            
            _sequencer = ID_test;
           return ID_test;
        }
    }
}
