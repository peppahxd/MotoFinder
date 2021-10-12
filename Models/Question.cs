using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotoFinder.Models
{
    public class Question
    {
        public Question(int id, string title, List<string> options)
        {
            this.id = id;
            this.title = title;
            this.options = options;
            this.options.Add("Unsure");
        }

        public int id { get; set; }
        public string title { get; set; }
        public List<string> options { get; set; }

        [JsonIgnore]
        public Answer Answer { get; set; }
    }
}
