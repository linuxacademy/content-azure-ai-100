using KeyPhraseExtraction.support;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPhraseExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpoint = "https://southcentralus.api.cognitive.microsoft.com/"; // insert your endpoint
            string key = "99068cd60b1d4963b1a365ce5d81d87d"; // insert your key

            var credentials = new ApiKeyServiceClientCredentials(key);
            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = endpoint
            };

            var result = client.KeyPhrases("My cat might need to see a veterinarian.");

            // Printing key phrases
            Console.WriteLine("Key phrases:");

            foreach (string keyphrase in result.KeyPhrases)
            {
                Console.WriteLine($"\t{keyphrase}");
            }
        }
    }
}
