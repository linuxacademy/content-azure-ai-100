using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxAcademy.Azure.AI.FaceRecognition
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

            var faceClient = new FaceClient(
                new ApiKeyServiceClientCredentials(key))
            {
                Endpoint = endpoint
            };

            var faceAttributes = new []
            { 
                FaceAttributeType.Age, 
                FaceAttributeType.Gender 
            };

            Console.WriteLine("Starting face detection");

            var imageFile = "bubbles.jpg";
            using (var imageStream = File.OpenRead(imageFile))
            {
                var faceList =
                    await faceClient.Face.DetectWithStreamAsync(
                        imageStream, 
                        returnFaceId: true, 
                        returnFaceLandmarks: false, 
                        returnFaceAttributes: faceAttributes);

                foreach (var face in faceList)
                {
                    Console.WriteLine($"Face: {face.FaceId}");
                    Console.WriteLine($"{face.FaceRectangle.Left} {face.FaceRectangle.Top} {face.FaceRectangle.Width} {face.FaceRectangle.Height}");
                    Console.WriteLine($"{face.FaceAttributes.Age} {face.FaceAttributes.Gender}");
                }
            }
        }
    }
}
