using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlobStorage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            string connectionString = "Get Value from Access keys --Show keys-- Connection string";
            Console.WriteLine("Blob Storage Demo");
            ////Create
            //BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            //BlobContainerClient blobContainerClient = await blobServiceClient.CreateBlobContainerAsync($"testcontainer");
            //Console.WriteLine("Container Created");

            ////Delete
            //BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, "testcontainer");
            //blobContainerClient.DeleteIfExists();

            //Console.WriteLine("Container Deleted");

            ////File Uploaded
            //BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, "testcontainer");
            //BlobClient blob = blobContainerClient.GetBlobClient(@"english/testazure.txt");
            //using (FileStream file = File.OpenRead(@"E:\testlocal.txt"))
            //{
            //    await blob.UploadAsync(file);
            //}

            //Console.WriteLine("File Uploaded");

            //File Name and Size Read
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, "testcontainer");
            await foreach (BlobItem blobItem in blobContainerClient.GetBlobsAsync())
            {
                Console.WriteLine($"File Name {blobItem.Name} Size {blobItem.Properties.ContentLength}");
            }
        }
    }
}
