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
            string endpoint = ; // insert your endpoint
            string key = ; // insert your key

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
