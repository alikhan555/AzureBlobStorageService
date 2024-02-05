using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Text;

namespace AzureBlobService.AzureQueue
{
    public class QueueServiceHandler
    {
        private QueueServiceClient _queueServiceClient;

        public QueueServiceHandler(string connectionString)
        {
            _queueServiceClient = new QueueServiceClient(connectionString);
        }

        public async Task CreateIfNotExistsAsync(string queueName)
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            _ = await queueClient.CreateIfNotExistsAsync();
        }

        public async Task SendMessageAsync(string queueName, string messageText, bool convertBase64 =  false)
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);

            if (convertBase64)
                messageText = Convert.ToBase64String(Encoding.UTF8.GetBytes(messageText));

            await queueClient.SendMessageAsync(messageText);
        }

        public async Task<PeekedMessageModel> PeekMessageAsync(string queueName)
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            PeekedMessage message = await queueClient.PeekMessageAsync();

            PeekedMessageModel queueMessage = new()
            {
                Body = message.Body.ToString(),
                MessageId = message.MessageId
            };

            return queueMessage;
        }

        public async Task<PeekedMessageModel[]> PeekMessagesAsync(string queueName, int numberOfMessages)
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            PeekedMessage[] messages = await queueClient.PeekMessagesAsync(numberOfMessages);

            PeekedMessageModel[] queueMessage = messages.Select(x => new PeekedMessageModel()
            {
                Body= x.Body.ToString(),
                MessageId = x.MessageId
            }).ToArray();

            return queueMessage;
        }

        public async Task<QueueMessageModel> ReceiveMessageAsync(string queueName, TimeSpan? visibilityTimeout = null)
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            QueueMessage queueMessage = await queueClient.ReceiveMessageAsync(visibilityTimeout ?? TimeSpan.FromSeconds(30));

            QueueMessageModel message = new()
            {
                Body = queueMessage.Body.ToString()
            };

            return message;
        }

        public async Task<QueueMessageModel[]> ReceiveMessagesAsync(string queueName, int numberOfMessages, TimeSpan? visibilityTimeout = null)
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            QueueMessage[] queueMessages = await queueClient.ReceiveMessagesAsync(numberOfMessages, visibilityTimeout ?? TimeSpan.FromSeconds(30));

            QueueMessageModel[] messages = queueMessages.Select(x => new QueueMessageModel()
            {
                MessageId = x.MessageId,
                PopReceipt = x.PopReceipt.ToString(),
                Body = x.Body.ToString()
            }).ToArray();

            return messages;
        }

        public async Task DeleteMessageAsync(string queueName, string messageId, string popReceipt)
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            await queueClient.DeleteMessageAsync(messageId, popReceipt);
        }

        public async Task UpdateMessageAsync(string queueName, string messageId, string popReceipt, string messageText)
        {
            QueueClient queueClient = _queueServiceClient.GetQueueClient(queueName);
            await queueClient.UpdateMessageAsync(messageId, popReceipt, messageText);
        }
    }
}
