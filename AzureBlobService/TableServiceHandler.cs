using Azure;
using Azure.Data.Tables;
using System.Linq.Expressions;

namespace AzureBlobService
{
    public class TableServiceHandler<T> where T : class, ITableEntity
    {
        private TableServiceClient _tableServiceClient;

        public TableServiceHandler(string connectionString)
        {
            _tableServiceClient = new TableServiceClient(connectionString);
        }

        public async Task CreateTableIfNotExistAsync(string tableName)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);
            _ = await tableClient.CreateIfNotExistsAsync();
        }

        public async Task AddEntityAsync(string tableName, T item)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);
            _ = await tableClient.AddEntityAsync(item);
        }

        public async Task AddEntitiesAsync(string tableName, List<T> entities)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);
            List<TableTransactionAction> transactionActions = entities.Select(entity => new TableTransactionAction(TableTransactionActionType.Add, entity)).ToList();
            Azure.Response<IReadOnlyList<Azure.Response>> responses = await tableClient.SubmitTransactionAsync(transactionActions);
        }

        public async Task<T> GetEntityAsync(string tableName, string rowKey, string partitionKey)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);
            T entity = await tableClient.GetEntityAsync<T>(partitionKey, rowKey);
            return entity;
        }

        public async Task<List<T>> GetEntitesAsync(string tableName, Expression<Func<T, bool>> expression)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);
            var entityQuery = tableClient.Query(expression);
            List<T> entities = entityQuery.ToList();
            return entities;
        }

        public async Task DeleteEntityAsync(string tableName, string partitionKey, string rowKey)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);
            _ = await tableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task UpdateEntityAsync(string tableName, T entity, ETag eTag)
        {
            TableClient tableClient = _tableServiceClient.GetTableClient(tableName);
            _ = await tableClient.UpdateEntityAsync(entity, eTag);
        }
    }
}
