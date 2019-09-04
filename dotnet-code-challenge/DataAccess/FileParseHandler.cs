using System.IO;

namespace dotnet_code_challenge
{
    /// <summary>
    /// Gets the file pareser based on file extension.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>File Parser object</returns>
    public class FileParseHandler
    {
        public FileParser GetFileParserInstance(string filePath)
        {
            var fileExtn = Path.GetExtension(filePath);

            FileParser fileParser = null;

            switch (fileExtn)
            {
                case ".xml":
                    fileParser = new XmlFileParser();
                    break;

                case ".json":
                    fileParser = new JsonFileParser();
                    break;
            }

            return fileParser;
        }
    }
}