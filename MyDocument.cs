using Newtonsoft.Json;
using System;

namespace ArifElastic
{
    public class MyDocument
    {
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Aciklama { get; set; }
        public string Header { get; set; }
        public DateTimeOffset Kayitzamani { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
