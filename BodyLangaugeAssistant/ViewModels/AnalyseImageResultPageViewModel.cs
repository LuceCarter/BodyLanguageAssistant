using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace BodyLangaugeAssistant.ViewModels
{
    public class AnalyseImageResultPageViewModel : BaseViewModel
    {
        StreamImageSource _analysedPhoto;
        string _description;
        public AnalyseImageResultPageViewModel(StreamImageSource photo, IList<DetectedFace> faces)
        {
            AnalysedPhoto = photo;
            var emotions = faces.Select(face => GetEmotion(face));

            Description = "Most likely emotion: " + emotions.FirstOrDefault().Key + " with a score of " + emotions.FirstOrDefault().Value.ToString();

        }

        public StreamImageSource AnalysedPhoto
        {
            get => _analysedPhoto;
            set => SetProperty(ref _analysedPhoto, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private KeyValuePair<string, double> GetEmotion(DetectedFace face)
        {
            var emotions = new Dictionary<string, double>
            {
                {nameof(face.FaceAttributes.Emotion.Anger), face.FaceAttributes.Emotion.Anger},
                {nameof(face.FaceAttributes.Emotion.Contempt), face.FaceAttributes.Emotion.Contempt},
                {nameof(face.FaceAttributes.Emotion.Disgust), face.FaceAttributes.Emotion.Disgust},
                {nameof(face.FaceAttributes.Emotion.Fear), face.FaceAttributes.Emotion.Fear},
                {nameof(face.FaceAttributes.Emotion.Happiness), face.FaceAttributes.Emotion.Happiness},
                {nameof(face.FaceAttributes.Emotion.Neutral), face.FaceAttributes.Emotion.Neutral},
                {nameof(face.FaceAttributes.Emotion.Sadness), face.FaceAttributes.Emotion.Sadness},
                {nameof(face.FaceAttributes.Emotion.Surprise), face.FaceAttributes.Emotion.Surprise},
            };

            return emotions.OrderByDescending(e => e.Value).First();
        }
    }
}
