using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoConsultarClimaC_
{
    internal class ApiResponse
    {
        [JsonProperty("main")]
        public TempData Main { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }    

    }
}
