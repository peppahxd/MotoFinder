using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoFinder.Models
{
    public class Answer
    {
        public Answer(Question question, Action actionCallback)
        {
            this.id = question.id;
            this.options = question.options;
            this.actionCallback = actionCallback;

        }

        public void Handle(string option)
        {
            this.option = option;
            this.actionCallback();
        }

        public int id { get; set; }

        public List<string> options { get; set; }

        public string option { get; set; }

        public Action actionCallback { get; set; }
    }
}
