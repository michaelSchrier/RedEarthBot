using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;

namespace RedEarthBot.Models
{
    public class CodeData
    {
        [JsonProperty("character")]
        [DefaultValue(" ")]
        public string Character { get; private set; }

        [JsonProperty("password")]
        [DefaultValue(" ")]
        public string Password { get; private set; }

        [JsonProperty("notes")]
        [DefaultValue(" ")]
        public string Notes { get; private set; }
    }
}
