namespace AzureBlobService.AzureQueue
{
    public class QueueMessageModel
    {
        public string MessageId { get; set; }
        public string PopReceipt { get; set; }
        public string Body { get; set; }
    }
}
