using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace API2
{

    public partial class ListaPais
    {
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public long? Success { get; set; }

        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public List<Pais>Paises { get; set; }
    }

    public partial class Pais
    {
        [JsonProperty("country_key", NullValueHandling = NullValueHandling.Ignore)]
        public long? CountryKey { get; set; }

        [JsonProperty("country_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? CountryName { get; set; }

        [JsonProperty("country_iso2")]
        public string? CountryIso2 { get; set; }

        [JsonProperty("country_logo")]
        public Uri? CountryLogo { get; set; }
    }
}

