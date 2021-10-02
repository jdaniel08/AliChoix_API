
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AliChoixServer.Model
{
    public partial class OffApiProduct
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("product")]
        public OffMongoDbProduct Product { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("status_verbose")]
        public string StatusVerbose { get; set; }
    }
}
