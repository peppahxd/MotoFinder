using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotoFinder.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Type = MotoFinder.Models.Type;

namespace MotoFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Bike> bikes { get; set; }
        public List<Question> questions { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            bikes = new List<Bike>();
            questions = new List<Question>();

            #region Bikes

            var content = System.IO.File.ReadAllLines("bikes.txt");
            for (int i = 1; i < content.Length; i++)
            {
                var bike = content[i].Split(',');

                Type type = Type.ADVENTURE;
                for (int j = 0; j < type.GetType().GetEnumNames().Length; j++)
                {
                    if (type.GetType().GetEnumNames()[j].Equals(bike[7].Trim()))
                        type = (Type)j;
                }

                License license = License.A1;
                for (int j = 0; j < license.GetType().GetEnumNames().Length; j++)
                {
                    if (license.GetType().GetEnumNames()[j].Equals(bike[8].Trim()))
                        license = (License)j;
                }

                Brand brand = Brand.HONDA;
                for (int j = 0; j < brand.GetType().GetEnumNames().Length; j++)
                {
                    if (brand.GetType().GetEnumNames()[j].Equals(bike[9].Trim()))
                        brand = (Brand)j;
                }

                bikes.Add(new Bike(bike[0], bike[1], bike[2], bike[3], bike[4], bike[5], bike[6], type, license, brand));
            }



            #endregion


            #region questions
            questions.Add(new Question(0, "Type of license", Enum.GetNames(typeof(License)).ToList()));
            questions[0].Answer = new Answer(questions[0], new Action(() =>
            {
                
                var answer = questions[0].Answer;
                this.bikes = this.bikes.Where(x => x.license.ToString().Equals(answer.option))
                                       .ToList();

                this.bikes.ForEach(x => Console.WriteLine(x.name.ToString()));
            }));

            questions.Add(new Question(1, "Type of motorcycle", Enum.GetNames(typeof(Type)).ToList()));
            questions[1].Answer = new Answer(questions[1], new Action(() =>
            {
                this.bikes = this.bikes.Where(x => x.type.ToString().Equals(questions[1].Answer.option))
                                       .ToList();
            }));
            #endregion


        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewQuestion(int questionId, string option)
        {
            var question = questions.FirstOrDefault(x => x.id == questionId);

            if (option != "")
            {
                if (questionId > 0)
                {
                    Console.WriteLine(question.title + " " + option);
                    var answer = questions.FirstOrDefault(x => x.id == questionId - 1).Answer;
                    answer.option = option;
                    answer.actionCallback();
                }
            }

            return Json(question);
        }
    }
}
