using System;
using System.Linq;
using FaceRecognitionDotNet;

namespace FaceDetectionCuda
{
    class Program
    {
        private static FaceRecognition _faceRecognition;

        static void Main(string[] args)
        {
            var modelDirectory = @"D:\dev\dlib-model";
            _faceRecognition = FaceRecognition.Create(modelDirectory);

            var src = @"input.jpg";
            using (var imageSrc = FaceRecognition.LoadImageFile(src))
            {
                var faceLocations = _faceRecognition.FaceLocations(imageSrc, 0, Model.Cnn).ToArray();
                var faceEncodings = _faceRecognition.FaceEncodings(imageSrc, faceLocations).ToArray();
                Console.WriteLine($"Face count: {faceEncodings.Length}");
            }
        }
    }
}