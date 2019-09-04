using dotnet_code_challenge.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace dotnet_code_challenge
{
    /// <summary>
    /// JSON file parser class
    /// </summary>
    public class JsonFileParser : FileParser
    {
        /// <summary>
        /// Gets the horse details.
        /// </summary>
        /// <param name="path">The JSON file path.</param>
        /// <returns>List of horses</returns>
        public override ICollection<Horse> GetHorseDetails(string path)
        {
            List<Horse> horses = new List<Horse>();
            if (string.IsNullOrEmpty(path))
            {
                return horses;
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    //Read the JSON data from the file and deserialize it
                    var json = wc.DownloadString(path);

                    //TODO: Deserialize JSON to strong type and capture all the properties
                    dynamic raceData = JsonConvert.DeserializeObject<dynamic>(json);
                    if (raceData != null)
                    {
                        dynamic raceRawData = raceData.RawData;
                        if (raceRawData != null)
                        {
                            IEnumerable<dynamic> markets = raceRawData.Markets;

                            //Get all the horses

                            //TODO: Mode the below to seperate methods to return various set of info from JSON
                            //To make this scalable and maintainable.
                            if (raceData != null && raceRawData != null)
                            {
                                Race = raceRawData.FixtureName;
                                foreach (var participants in raceRawData.Participants)
                                {
                                    var horse = new Horse()
                                    {
                                        Id = participants.Id,
                                        Name = participants.Name
                                    };

                                    horses.Add(horse);
                                }
                                //Get price of the horses.
                                if (markets != null)
                                {
                                    foreach (var market in markets)
                                    {
                                        foreach (var selection in market.Selections)
                                        {
                                            var horse = horses.Find(h => h.Id == selection.Tags.participant.ToString());
                                            horse.Price = selection.Price;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
            catch (InvalidDataException)
            {
                throw new InvalidDataException();
            }

            return horses;
        }
    }
}