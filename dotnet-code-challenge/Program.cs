using System;
using System.IO;

namespace dotnet_code_challenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Horse Catalogue, ordered by price");
            Console.WriteLine();

            FileParseHandler fileParseHelper = new FileParseHandler();

            try
            {
                //Read all the data feed file paths
                var dataFilePaths = Directory.GetFiles(Constants.DATA_FEED_BASE_PATH);

                foreach (var path in dataFilePaths)
                {
                    //Parse and read the horse details based on the file extention
                    FileParser fileParser = fileParseHelper.GetFileParserInstance(path);

                    if (fileParser != null)
                    {
                        var horses = fileParser.GetHorseDetails(path);
                        fileParser.DisplayHorseDetails(horses);
                    }
                    else
                    {
                        Console.WriteLine("Something wrong with the data feed. " +
                            "Either there are no files or the type of the file is not expected.");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Data file is missing.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("An error occured while reading the data file.");
            }

            Console.Read();
        }
    }
}