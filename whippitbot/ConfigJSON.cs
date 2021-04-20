using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace whippitbot
{
    public struct ConfigJSON
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string CommandPrefix { get; private set; }
    }
}
