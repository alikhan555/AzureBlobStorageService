using Azure;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;

namespace AzureBlobService
{
    public class BlobServiceHandler
    {
        private BlobServiceClient _blobServiceClient;

        public BlobServiceHandler(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public BlobServiceHandler(string uri, string tenantId, string clientId, string clientSecret)
        {
            Uri _uri = new Uri(uri);
            ClientSecretCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            _blobServiceClient = new BlobServiceClient(_uri, credential);
        }

        public async Task CreateContainerAsync(string containerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync();
        }

        public List<string> GetAllContainersName()
        {
            Pageable<BlobContainerItem> blobContainerClient = _blobServiceClient.GetBlobContainers();
            List<string> containersName = new List<string>();

            foreach (BlobContainerItem item in blobContainerClient)
            {
                containersName.Add(item.Name);
            }

            return containersName;
        }

        public async Task UploadBlobAsync(string containerName, string blobName, string sourcePath)
        {
            await CreateContainerAsync(containerName);
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(sourcePath);
        }

        public List<string> GetAllBlobsName(string containerName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            List<string> blobsName = new List<string>();
            
            foreach(BlobItem item in blobContainerClient.GetBlobs())
            {
                blobsName.Add(item.Name);
            }

            return blobsName;
        }

        public async Task DownloadToAsync(string containerName, string blobName, string destinationPath)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            await blobClient.DownloadToAsync(destinationPath);
        }

        public async Task DeleteIfExistsAsync(string containerName, string blobName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> GetBlobUrl(string containerName, string blobName, TimeSpan? sasExpiresOn)
        {
            string url = string.Empty;

            if(sasExpiresOn is null)
            {
                url = @$"{_blobServiceClient.Uri}{containerName}/{blobName}";
            }
            else
            {
                BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

                BlobSasBuilder builder = new BlobSasBuilder()
                {
                    BlobContainerName = containerName,
                    BlobName = blobName,
                    Resource = "b",
                    ExpiresOn = DateTime.UtcNow.AddSeconds(sasExpiresOn.Value.TotalSeconds),
                };

                builder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);

                Uri blobURI = blobClient.GenerateSasUri(builder);

                url = blobURI.AbsoluteUri;
            }

            return url;
        }

        public async Task<Dictionary<string, string>> GetBlobPropertiesAsync(string containerName, string blobName)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            BlobProperties blobProperties = await blobClient.GetPropertiesAsync();
            
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                { "AccessTier", blobProperties.AccessTier.ToString() },
                { "ContentLength", blobProperties.ContentLength.ToString() },
                { "ContentType", blobProperties.ContentType.ToString() },
                { "LastAccessed", blobProperties.LastAccessed.ToString() },
                { "LastModified", blobProperties.LastModified.ToString() },
                { "LeaseDuration", blobProperties.LeaseDuration.ToString() }
            };

            foreach(KeyValuePair<string, string> metadata in blobProperties.Metadata)
            {
                properties.Add(metadata.Key, metadata.Value);
            }

            return properties;
        }

        public async Task SetBlobMatadataAsync(string containerName, string blobName, Dictionary<string, string> metadata)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            BlobProperties blobProperties = await blobClient.GetPropertiesAsync();

            foreach (KeyValuePair<string, string> metadataItem in metadata)
            {
                blobProperties.Metadata.TryAdd(metadataItem.Key, metadataItem.Value);
            }

            await blobClient.SetMetadataAsync(blobProperties.Metadata);
        }

        public async Task UpdateBlobAsync(string containerName, string blobName, string sourcePath)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

            BlobLeaseClient blobLeaseClient = blobClient.GetBlobLeaseClient();
            BlobLease blobLease = await blobLeaseClient.AcquireAsync(TimeSpan.FromSeconds(60));

            BlobUploadOptions blobUploadOptions = new()
            {
                Conditions = new()
                {
                    LeaseId = blobLease.LeaseId,
                }
            };

            await blobClient.UploadAsync(sourcePath, blobUploadOptions);
            await blobLeaseClient.ReleaseAsync();
        }

        public async Task CopyBlobAsync(string containerName, string blobName, string sourcePath)
        {
            await CreateContainerAsync(containerName);
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            var sourceUri = new Uri(sourcePath);
            await blobClient.SyncCopyFromUriAsync(sourceUri);
        }
    }
}
