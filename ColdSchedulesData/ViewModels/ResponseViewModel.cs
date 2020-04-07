using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColdSchedulesData.ViewModels
{
    public class ResponseViewModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
