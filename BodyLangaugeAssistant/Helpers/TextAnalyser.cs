using System;
using System.Globalization;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;
using BodyLanguageAssistant.Helpers;

namespace BodyLangaugeAssistant.Helpers
{
    public class TextAnalyser
    {
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential(AzureKeys.SentimentAPIKey);
        private static readonly Uri endpoint = new Uri(AzureKeys.BaseUrl);
        private readonly TextAnalyticsClient client = new TextAnalyticsClient(endpoint, credentials);

        public TextAnalyser()
        {
        }

        public async Task<string> AnalyseSentiment(string textToAnalyse)
        {
            DocumentSentiment documentSentiment = await client.AnalyzeSentimentAsync(textToAnalyse);

             return documentSentiment.Sentiment.ToString();
        }
    }
}
