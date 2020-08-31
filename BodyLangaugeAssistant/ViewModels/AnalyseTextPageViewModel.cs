using System;
using System.Windows.Input;
using MvvmHelpers;

namespace BodyLangaugeAssistant.ViewModels
{
    public class AnalyseTextPageViewModel : BaseViewModel
    {
        private string _textForAnalysis;
        private string _sentimentAnalysisResult;
        private Color _sentimentResultColour;

        public AnalyseTextPageViewModel()
        {
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

    }

    
}
