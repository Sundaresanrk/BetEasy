using System.Collections.Generic;

namespace dotnet_code_challenge.Model
{
    /// <summary>
    /// Class to keep Caulifield Race information
    /// </summary>
    public class Race
    {
        /// <summary>
        /// Gets or sets the Race Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Race Number.
        /// </summary>
        public int RaceNumber { get; set; }

        /// <summary>
        /// Gets or sets the Race Horses.
        /// </summary>
        public IEnumerable<Horse> Horses { get; set; }
    }
}