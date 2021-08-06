using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Enigma.Logistics
{
    class ConfigurationHolder
    {
        private static ConfigurationHolder instance;
        private Dictionary<String, String> data;

        private ConfigurationHolder()
        {
            data = new Dictionary<string, string>();
            foreach (var entry in File.ReadAllLines(@"..\..\config.ini"))
            {
                data.Add(entry.Split('=')[0], entry.Split('=')[1]);
            }
        }

        public static ConfigurationHolder GetInstance()
        {
            if (instance == null) instance = new ConfigurationHolder();

            return instance;
        }

        public Dictionary<String, String> Settings
        {
            get
            {
                return data;
            }
        }
    }
}

