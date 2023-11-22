using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;

namespace WebApi.Api.Utilities
{
    public static class JsonHelpers
    {
        public static async Task<ActionResult> SerializeToJsonResponseAsync<T>(Task<T> dataTask)
        {
            try
            {
                var data = await dataTask;

                if (data is null || (data is IEnumerable && !((IEnumerable)data).Cast<object>().Any()))
                    return new NoContentResult();

                var serializerSettings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ",
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                var json = JsonConvert.SerializeObject(data, serializerSettings);

                return new OkObjectResult(json);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
