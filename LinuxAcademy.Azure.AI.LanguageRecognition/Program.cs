using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxAcademy.Azure.AI.LanguageRecognition
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

            var result = client.DetectLanguage("This is a document written in English.");
            Console.WriteLine($"Language: {result.DetectedLanguages[0].Name}");

            result = client.DetectLanguage("Parlez Vous Francais?");
            Console.WriteLine($"Language: {result.DetectedLanguages[0].Name}");
        }
    }
}
