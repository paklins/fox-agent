using System.Linq;
using System;
using System.Collections.Generic;

using FoxAgent.Core;
using FoxAgent.Parse;

namespace FoxAgent.SystemInformation
{
    public class LinuxSystemInformation : ISystemInformation
    {
        private Dictionary<string,string> _info;

        public LinuxSystemInformation()
        {
            string releaseInfo = "cat /etc/*release".Command();
            var releaseInfoKV = new KeyValueSetReader();
            releaseInfoKV.read(releaseInfo, "=");
            
            _info = releaseInfoKV.EntrySet();
        }

        public OSType Type
        {
            get { return OSType.Linux;  }
        }

        public string Platform
        {
            get { return Type.GetDescription(); }
        }

        public string Name
        {
            

            get { return _info.GetValueOrDefault("PRETTY_NAME").Replace("\"", ""); }
        }

        public string ID
        {
            get { return _info.GetValueOrDefault("ID"); }
        }

        public string IDLike { get { return _info.GetValueOrDefault("ID_LIKE"); }}
    }
}