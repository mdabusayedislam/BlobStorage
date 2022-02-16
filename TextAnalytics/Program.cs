using Azure;
using Azure.AI.TextAnalytics;
using System;

namespace TextAnalytics
{
    class Program
    {
        //Azure Cognitive services
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("Put Key 1 Value");
        private static readonly Uri endpoint = new Uri("Put End Point Value");
        private static readonly TextAnalyticsClient client =new TextAnalyticsClient(endpoint, credentials);
        static void Main(string[] args)
        {
           
            Console.WriteLine("Please enter your text");
            string InputText = Console.ReadLine();
            var sentiment = GetSentiment(client, InputText);
            Console.WriteLine($"Sentiment is {sentiment}");

            var detectedLanguage = DetectLanguage(client, InputText);
            Console.WriteLine($"Detected Language is {detectedLanguage}");
        }
        static string GetSentiment(TextAnalyticsClient client,String InputText)
        {
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(InputText);
            return documentSentiment.Sentiment.ToString();
        }

        static string DetectLanguage(TextAnalyticsClient client, String InputText)
        {
            DetectedLanguage detectedLanguage = client.DetectLanguage(InputText);
            return detectedLanguage.Name.ToString();
        }
    }
}
