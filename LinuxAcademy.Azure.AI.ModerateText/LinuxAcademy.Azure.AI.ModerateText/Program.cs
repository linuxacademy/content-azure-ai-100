using Microsoft.Azure.CognitiveServices.ContentModerator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxAcademy.Azure.AI.ModerateText
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpoint = ; // insert your endpoint
            string key = ; // insert your key

            var client = new ContentModeratorClient(
                new ApiKeyServiceClientCredentials(key))
            {
                Endpoint = endpoint
            };

            using (var stream = File.OpenRead("TextFile1.txt"))
            {
                var screenResult = client.TextModeration.ScreenText(
                    "text/plain",
                    stream,
                    "eng",
                    autocorrect: false,
                    pII: false,
                    listId: null,
                    classify: false);

                Console.WriteLine(JsonConvert.SerializeObject(screenResult, Formatting.Indented));
            }
        }
    }
}
