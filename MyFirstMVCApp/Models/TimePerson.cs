using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVCApp.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// This method takes in two integers and returns all people from that time period
        /// </summary>
        /// <param name="begYear">Beginning year</param>
        /// <param name="endYear">Ending yar</param>
        /// <returns>Returns a list of people</returns>
        public static List<TimePerson> GetPersons(int begYear, int endYear)
        {
            // Creates a generic list of type TimePerson
            List<TimePerson> people = new List<TimePerson>();
            // Sets the current directory to a variable
            string path = Environment.CurrentDirectory;
            // Combines the path of the current directory with the location of the PersonOfTheYear.csv file
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // Reads the csv file and stores it into a sting array
            string[] myFile = File.ReadAllLines(newPath);

            // Iterates through the string array
            for (int i = 1; i < myFile.Length; i++)
            {
                // Splits each element in the array with a comma
                string[] fields = myFile[i].Split(',');
                // Adds a new person to the list
                people.Add(new TimePerson
                {
                    // Year converted to integer
                    Year = Convert.ToInt32(fields[0]),
                    // Taken directly from file
                    Honor = fields[1],
                    // Taken directly from file
                    Name = fields[2],
                    // Taken directly from file
                    Country = fields[3],
                    // Converts the birth year into an integer if it exists else makes it a zero
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    // Converts the death year into an integer if it exists else makes it a zero
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    // Taken directly from file
                    Title = fields[6],
                    // Taken directly from file
                    Category = fields[7],
                    // Taken directly from file
                    Context = fields[8],
                });
            }
            // Creates a new list filtered by the user input years
            List<TimePerson> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            // Returns the new list
            return listofPeople;
        }
    }
}
