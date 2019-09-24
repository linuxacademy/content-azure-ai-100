using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using NamedEntityDetection.support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedEntityDetection
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

            var result = client.Entities("Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC interpreters for the Altair 8800.");
            Console.WriteLine("Entities:");
            foreach (var entity in result.Entities)
            {
                Console.WriteLine($"\tName: {entity.Name},\tType: {entity.Type ?? "N/A"},\tSub-Type: {entity.SubType ?? "N/A"}");
                foreach (var match in entity.Matches)
                {
                    Console.WriteLine($"\t\tOffset: {match.Offset},\tLength: {match.Length},\tScore: {match.EntityTypeScore:F3}");
                }
            }

        }
    }
}
