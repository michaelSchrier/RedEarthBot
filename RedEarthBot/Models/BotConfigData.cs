using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RedEarthBot.Models
{
    public struct BotConfigData
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}
