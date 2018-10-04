using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppsCore.Ancestry.Api.Config
{
    public class AppConfiguration : IAppConfiguration
    {
        public string DataFile { get; set; }
    }
}
