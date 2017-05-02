using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Model
{
    public class JobStatus
    {
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DatasetStatusType Status { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Error { get; set; }
    }

    public enum DatasetStatusType
    {
        Initialized,
        Running,
        Done
    }
    
}
