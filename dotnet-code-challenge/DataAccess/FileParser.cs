using dotnet_code_challenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge
{
    /// <summary>
    /// File Parser class
    /// </summary>
    public abstract class FileParser
    {
        /// <summary>
        /// Gets or sets the name of the race.
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        /// Gets the participating horses.
        /// </summary>
        /// <param name="path">The data file path.</param>
        /// <returns>List of horses</returns>
        public abstract ICollection<Horse> GetHorseDetails(string path);

        /// <summary>
        /// Displays the horses.
        /// </summary>
        /// <param name="horses">The horses.</param>
        public void DisplayHorseDetails(IEnumerable<Horse> horses)
        {
            //ToDo: Print output in a better way
            if (horses != null && horses.Any())
            {
                Console.WriteLine("******************************");
                Console.WriteLine("{0} race:", Race);
                Console.WriteLine("******************************");

                horses = horses.OrderBy(a => a.Price);

                foreach (var horse in horses)
                {
                    Console.WriteLine("Name: {0}, Price: {1}", horse.Name, horse.Price);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("This race does not have horse information");
            }
        }
    }
}