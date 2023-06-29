using Newtonsoft.Json;
using System.Collections.Generic;
//using System.Text.Json;

namespace SGL.Resource.Util
{
    public class DefaultResult
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public Dictionary<string, string[]> Errors { get; private set; }

        public DefaultResult()
        {

        }

        [JsonConstructor]
        public DefaultResult(object result, string message, bool success, Dictionary<string, string[]> errors)
        {
            Result = result;
            Message = message;
            Errors = errors;
            Success = success;
        }

        public DefaultResult(string message, bool success, Dictionary<string, string[]> errors)
        {
            Message = message;
            Errors = errors;
            Success = success;
        }
        public DefaultResult(object result, string message, bool success = true)
        {
            Result = result;
            Message = message;
            Success = success;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
