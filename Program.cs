using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Inensia_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader(@"C:\Users\tote5002\source\repos\Inensia_1\Inensia_1\input.txt"))
            {
                string json = r.ReadToEnd();
                var dateOfBirth = "";
                CultureInfo provider = CultureInfo.InvariantCulture;
                List<MovieStar> movieStars = JsonConvert.DeserializeObject<List<MovieStar>>(json);

                for (int i = 0; i < movieStars.Count; i++)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(movieStars[i].name).Trim(new Char[] { '"', '"' }) + " "+ JsonConvert.SerializeObject(movieStars[i].surname).Trim(new Char[] { '"', '"' }));
                    Console.WriteLine(JsonConvert.SerializeObject(movieStars[i].sex).Trim(new Char[] { '"', '"' }));
                    Console.WriteLine(JsonConvert.SerializeObject(movieStars[i].nationality).Trim(new Char[] { '"', '"' }));
                    dateOfBirth = JsonConvert.SerializeObject(movieStars[i].dateOfBirth);
                    string test = dateOfBirth.Substring(1, 10);
                    Console.WriteLine("{0} years old",(DateTime.Today - DateTime.Parse(test)).Days / 365);
                    Console.WriteLine();
                }
            }

        }
        public class MovieStar
        {
            public DateTime dateOfBirth { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string sex { get; set; }
            public string nationality { get; set; }


        }
    }
}
