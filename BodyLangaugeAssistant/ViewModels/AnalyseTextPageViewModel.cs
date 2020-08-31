using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BodyLangaugeAssistant.Helpers;
using MvvmHelpers;
using Xamarin.Forms;

namespace BodyLangaugeAssistant.ViewModels
{
    public class AnalyseTextPageViewModel : BaseViewModel
    {
        private string _textForAnalysis;
        private string _sentimentAnalysisResult;
        private Color _sentimentResultColour;

        public AnalyseTextPageViewModel()
        {
            AnalyseTextCommand = new Command(async () => await AnalyseText(TextForAnalysis));
            SentimentResultColour = Color.Black;
        }

        
        public string TextForAnalysis
        {
            get => _textForAnalysis;
            set => SetProperty(ref _textForAnalysis, value);
        }

        public ICommand AnalyseTextCommand { get; }

        public string SentimentAnalysisResult
        {
            get => _sentimentAnalysisResult;
            set => SetProperty(ref _sentimentAnalysisResult, value);
        }

        public Color SentimentResultColour
        {
            get => _sentimentResultColour;
            set => SetProperty(ref _sentimentResultColour, value);
        }

        async Task AnalyseText(string textForAnalysis)
        {
            TextForAnalysis = "";
            var textAnalyser = new TextAnalyser();
            switch (await textAnalyser.AnalyseSentiment(textForAnalysis))
            {
                case "Unknown":
                    SentimentResultColour = Color.Blue;
                    SentimentAnalysisResult = "Hmmm I can't seem to tell how you are feeling!";
                    break;
                case "Normal":
                    SentimentAnalysisResult = "You seem normal to me!";
                    break;
                case "Positive":
                    SentimentResultColour = Color.Green;
                    SentimentAnalysisResult = "Zip-a-dee-doo-dah, zip-a-dee-ay My, oh, my, what a wonderful day ";
                    break;
                case "Negative":
                    SentimentResultColour = Color.Red;
                    SentimentAnalysisResult = "Sucks to be you!";
                    break;
            }
        }

    }

    
}
