using dotnet_code_challenge.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace dotnet_code_challenge
{
    /// <summary>
    /// XML file parser class
    /// </summary>
    public class XmlFileParser : FileParser
    {
        /// <summary>
        /// Gets the horse details.
        /// </summary>
        /// <param name="path">The XML file path.</param>
        /// <returns>List of horses</returns>
        public override ICollection<Horse> GetHorseDetails(string path)
        {
            List<Horse> horses = new List<Horse>();

            if (string.IsNullOrEmpty(path))
            {
                return new List<Horse>();
            }

            string fileContent = File.ReadAllText(path);

            if (!string.IsNullOrEmpty(fileContent))
            {
                //Read the JSON data from the file and deserialize it
                var doc = XDocument.Parse(fileContent);

                //Get meeting details from the file
                Meeting meeting = new Meeting()
                {
                    MeetingId = doc.Descendants("Meetingid").Single().Value,
                    Track = doc.Descendants("track").Select(track => new Track
                    {
                        Name = track.Attribute("name").Value
                    }).SingleOrDefault(),
                    Races = doc.Descendants("race").Select(GetRace)
                };
                //Get all the horses
                if (meeting != null)
                {
                    if (meeting.Track != null)
                    {
                        Race = meeting.Track.Name;
                    }

                    if (meeting.Races != null)
                    {
                        foreach (var race in meeting.Races)
                        {
                            foreach (var h in race.Horses)
                            {
                                horses.Add(h);
                            }
                        }
                    }
                }
            }

            return horses;
        }

        /// <summary>
        /// Gets the Race details.
        /// </summary>
        /// <param name="race">The XElement Race.</param>
        /// <returns>Race details</returns>
        private Race GetRace(XElement race)
        {
            var prices = race.Elements("prices").Single().Descendants("horse");

            return new Race
            {
                Name = race.Attribute("name").Value,
                RaceNumber = int.Parse(race.Attribute("number").Value),
                Horses = race.Elements("horses").Single().Elements("horse").Select(horse => GetHorse(horse, prices))
            };
        }

        /// <summary>
        /// Gets the horses with their prices.
        /// </summary>
        /// <param name="horse">The XElement horse.</param>
        /// <param name="prices">The List horse prices.</param>
        /// <returns>horses with their price</returns>
        private Horse GetHorse(XElement horse, IEnumerable<XElement> prices)
        {
            return new Horse
            {
                Name = horse.Attribute("name").Value,
                Price = double.Parse(prices.First(p => p.Attribute("number").Value == horse.Elements("number").Single().Value).Attribute("Price").Value)
            };
        }
    }
}