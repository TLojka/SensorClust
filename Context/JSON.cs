using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace Context
{
    class JSON
    {
        public List<Rules> getData()
        {

            List<Rules> items=new List<Rules>();
            using (StreamReader r = new StreamReader("file.json"))
            {

               while (!r.EndOfStream)
                { 
                    string json = r.ReadLine();
                   items.Add(JsonConvert.DeserializeObject<Rules>(json));
                }
            }

            return items;
        }

        public bool Write(Rules input)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(@"file.json",true))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteStartObject();
                writer.WriteStartArray();
                serializer.Serialize(writer, input);
                serializer.Serialize(writer, input);
                writer.WriteEndArray();
                writer.WriteEndObject();

              
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }
            return true;

        }
    }


    [DataContract]
 public  class Rules
    {
        [DataMember (Name="id", IsRequired=true)]
        public int Id;

        [DataMember]
        public String Name;

        [DataMember]
        public string Description;

        [DataMember]
        public String[] Conditions;

        [DataMember]
        public String[] TrueActivities;

        [DataMember]
        public String[] FalseActivities;      
    }
}
