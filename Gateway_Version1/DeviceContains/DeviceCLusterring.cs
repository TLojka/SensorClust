using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Mean;

namespace Gateway_Version1.DeviceManager
{
    /// <summary>
    /// trieda pre zatriedovanie zariadení pridaných do siete
    /// </summary>
    class DeviceCLusterring
    {
        public DeviceCLusterring()
        {
            K_Mean.Main kMeanObject = new Main();
            kMeanObject.Main_auto(3, new double[20][]); //automatické klástrovanie s pouzitim simulovaných 20 vstupov, vstupy su definovane vo vnutri funkcie
        }
    }
}
