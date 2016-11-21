using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMemory;
using NMemory.Tables;

namespace Gateway_Version1.DataContains.InMemoryDB
{    
    /// <summary>
    /// Trieda pre vytvorenie databázy pre zariadenia definovaých podľa DeviceManager.DeviceDataTemplate
    /// </summary>
    class DeviceDBClass : Database
    {
        public ITable<tableSchema> Devicetable { get; private set; }

        public DeviceDBClass()
        {
            Devicetable = base.Tables.Create<tableSchema, int>(x => x.ID, new IdentitySpecification<tableSchema>(p => p.ID, 1, 1));
        }
        
    }

    class tableSchema : DeviceManager.DeviceDataTemplate
    {
   
    }
    
}
