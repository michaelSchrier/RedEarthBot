using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;

namespace RedEarthBot.Models
{
    public class MoveData
    {
        [JsonProperty("move")]
        [DefaultValue(" ")]
        public string MoveName { get; private set; }

        [JsonProperty("damage")]
        [DefaultValue(" ")]
        public string Damage { get; private set; }

        [JsonProperty("startup")]
        [DefaultValue(" ")]
        public string StartUp { get; private set; }

        [JsonProperty("active")]
        [DefaultValue(" ")]
        public string Active { get; private set; }

        [JsonProperty("recovery")]
        [DefaultValue(" ")]
        public string Recovery { get; private set; }

        [JsonProperty("hitadv.")]
        [DefaultValue(" ")]
        public string HitAdvantage { get; private set; }

        [JsonProperty("blockadv.")]
        [DefaultValue(" ")]
        public string BlockAdvantage { get; private set; }

        [JsonProperty("properties")]
        [DefaultValue(" ")]
        public string Properties { get; private set; }

        [JsonProperty("notes")]
        [DefaultValue(" ")]
        public string Notes { get; private set; }

        [JsonProperty("image")]
        [DefaultValue(" ")]
        public string ImageUrl { get; private set; }

        public MoveType moveType = MoveType.Misc;
    }

    public enum MoveType
    {
        Normals,
        Specials,
        Supers,
        Misc
    }
}
