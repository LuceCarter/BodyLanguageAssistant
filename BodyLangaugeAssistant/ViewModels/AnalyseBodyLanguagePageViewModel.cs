﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using BodyLanguageAssistant.Helpers;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using BodyLangaugeAssistant.Views;

namespace BodyLangaugeAssistant.ViewModels
{
    public class AnalyseBodyLanguagePageViewModel : BaseViewModel
    {
        

        private StreamImageSource _imageForAnalysis;
        private MediaFile photo;
        private bool _isBusy = false;
        private FaceClient faceClient;

        public AnalyseBodyLanguagePageViewModel()
        {
            TakePhotoCommand = new Command(async () => await TakePhotoAsync());
            faceClient = new FaceClient(new ApiKeyServiceClientCredentials(AzureKeys.FaceApiKey))
            {
                Endpoint = AzureKeys.BaseUrl
            };
        }

        public StreamImageSource ImageForAnalysis
        {
            get => _imageForAnalysis;
            set => SetProperty(ref _imageForAnalysis, value);
        }

        public ICommand TakePhotoCommand { get; }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private async Task TakePhotoAsync()
        {
            try
            {
                IsBusy = true;
                photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Small
                });

                ImageForAnalysis = (StreamImageSource)ImageSource.FromStream(() => photo.GetStream());

                using (var stream = photo.GetStreamWithImageRotatedForExternalStorage())
                {
                    IList<DetectedFace> faces;

                    faces = await faceClient.Face.DetectWithStreamAsync(stream,true, true, new List<FaceAttributeType?> { FaceAttributeType.Emotion });

                    if(faces.Count > 0)
                    {
                        var photoForDisplay = (StreamImageSource)ImageSource.FromStream(() => photo.GetStream());
                        await Application.Current.MainPage.Navigation.PushAsync(new AnalyseImageResultPage { BindingContext = new AnalyseImageResultPageViewModel(photoForDisplay, faces) });

                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", $"Error Taking Photo: " + ex.Message, "OK");
            }
        }
    }
}
