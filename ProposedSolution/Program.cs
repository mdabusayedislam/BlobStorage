using Azure;
using Azure.AI.TextAnalytics;
using Azure.Storage.Blobs;
using System;
using System.IO;

namespace ProposedSolution
{
    class Program
    {
        //Azure Cognitive services
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("Put Value from Azure Portal");
        private static readonly Uri endpoint = new Uri("Put Value from Azure Portal");
        private static readonly TextAnalyticsClient client = new TextAnalyticsClient(endpoint, credentials);

        static void Main(string[] args)
        {
            bool flag = false;
            //Azure Storage account
            string connectionString = "Put Value from Azure Portal";
            string filepath = @"E:\Azure\sample.txt";
            string reportData = File.ReadAllText(filepath);
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, "proposed-solutions");
            var DetectedLanguage = DetectLanguage(client, reportData);
            if (DetectedLanguage == "English")
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient($"English/report-{Guid.NewGuid().ToString()}.txt");
                flag = uploadFile(blobClient, filepath);
            }

            else if (DetectedLanguage == "Hindi")
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient($"Hindi/report-{Guid.NewGuid().ToString()}.txt");
                flag = uploadFile(blobClient, filepath);
            }

            else if (DetectedLanguage == "Oriya")
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient($"Oriya/report-{Guid.NewGuid().ToString()}.txt");
                flag = uploadFile(blobClient, filepath);
            }

            else 
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient($"Others/report-{Guid.NewGuid().ToString()}.txt");
                flag = uploadFile(blobClient, filepath);
            }

            if (flag == true)
            {
                Console.WriteLine("File uploaded successfully");
            }
            else
            {
                Console.WriteLine("Failed to upload File");
            }

           
        }

        static string DetectLanguage(TextAnalyticsClient client, String InputText)
        {
            DetectedLanguage detectedLanguage = client.DetectLanguage(InputText);
            return detectedLanguage.Name.ToString();
        }
        static bool uploadFile(BlobClient blob, string filePath)
        {
            bool flag = false;
            try
            {
                using (FileStream file = File.OpenRead(@"E:\Azure\sample.txt"))
                {
                    blob.Upload(filePath);
                }
                flag = true;
            }
            catch(Exception ex)
            {
                flag = false;
            }
            return flag;

        }
    }
}
