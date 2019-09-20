using LinuxAcademy.Azure.AI.SentimentAnalysis.support;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxAcademy.Azure.AI.SentimentAnalysis
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

            var result = client.Sentiment("I had the best day of my life.", "en");
            Console.WriteLine($"Sentiment Score: {result.Score:0.00}");

            result = client.Sentiment("I did not like that movie", "en");
            Console.WriteLine($"Sentiment Score: {result.Score:0.00}");
        }
    }
}
