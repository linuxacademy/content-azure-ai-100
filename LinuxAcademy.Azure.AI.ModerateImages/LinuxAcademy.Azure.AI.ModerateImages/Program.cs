using Microsoft.Azure.CognitiveServices.ContentModerator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxAcademy.Azure.AI.ModerateImages
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            string endpoint = ; // insert your endpoint
            string key = ; // insert your key

            var client = new ContentModeratorClient(
                new ApiKeyServiceClientCredentials(key))
            {
                Endpoint = endpoint
            };

            var files = Directory.GetFiles("images").OrderBy(f => f);
            foreach (var file in files)
            {
                Console.WriteLine($"Evaluating: {file}");
                using (var stream = File.OpenRead(file))
                {
                    var moderation = client.ImageModeration.EvaluateFileInput(stream);
                    Console.WriteLine(JsonConvert.SerializeObject(moderation, Formatting.Indented)); 
                }
            }
        }
    }
}
