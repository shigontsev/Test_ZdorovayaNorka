using Newtonsoft.Json;

namespace ZdorovayaNorka.Common.Helpers
{
    public static class JsonHelper
    {
        public static string Serialize(this object obj) {
            var a = JsonConvert.SerializeObject(obj,
                    Formatting.Indented,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            //new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            //    PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //});

            return a.ToString();
        }
    }
}
