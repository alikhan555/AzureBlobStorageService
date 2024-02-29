using AzureBlobService;
using System.Diagnostics;

//string connectionString = "";

string tenantId = "";
string clientId = "";
string clientSecret = "";
string blobUrl = "";

// Azure Blob Service
//BlobServiceHandler blobServiceHandler = new BlobServiceHandler(connectionString);
BlobServiceHandler blobServiceHandler = new BlobServiceHandler(blobUrl, tenantId, clientId, clientSecret);

//await blobServiceHandler.CreateContainerAsync("dotnet-program");
//blobServiceHandler.GetAllContainersName().ForEach(x => Console.WriteLine(x));
//await blobServiceHandler.UploadBlobAsync("dotnet-program", $"testlogo00002.jpg", @"C:\Users\CC378\Downloads\TestLogo0001.jpg");
//await blobServiceHandler.DownloadToAsync("dotnet-program", $"TestLogo2.jpg", @"C:\Users\CC378\Downloads\TestLogo0001.jpg");
//await blobServiceHandler.DeleteIfExistsAsync("dotnet-program", $"2024/01/30/4bdc97cf-eaca-45e8-8bb3-a07922bd80d6");
//string url = await blobServiceHandler.GetBlobUrl("dotnet-program", $"2024/01/30/6ead8bb8-70e2-45e3-b108-c08a54280a9a", TimeSpan.FromSeconds(120)); Console.WriteLine(url);
//blobServiceHandler.GetAllBlobsName("dotnet-program").ForEach(x => Console.WriteLine(x));

//Dictionary<string, string> blobProperties = await blobServiceHandler.GetBlobPropertiesAsync("dotnet-program", $"2024/01/30/0a2895d3-7b67-4eb3-982b-f0750261130a");
//foreach (var property in blobProperties)
//    Console.WriteLine($"{property.Key}: {property.Value}");

//await blobServiceHandler.SetBlobMatadataAsync("dotnet-program", $"2024/01/30/0a2895d3-7b67-4eb3-982b-f0750261130a", new Dictionary<string, string> { { "FirstKey", "FirstValue" }, { "SecondKey", "SecondValue" } });

//await blobServiceHandler.UpdateBlobAsync("dotnet-program", $"2024/01/30/0a2895d3-7b67-4eb3-982b-f0750261130a", @"C:\Users\CC378\Downloads\TestLogo.jpg");

//List<string> urls = blobServiceHandler.GetAllBlobsName("ContainerName").Select(x => $"SourceURL").ToList();

//Stopwatch stopwatch = Stopwatch.StartNew();
//stopwatch.Start();
//List<Task> tasks = urls.Select(x => blobServiceHandler.CopyBlobAsync("ContainerName", Guid.NewGuid().ToString(), x)).ToList();
//await Task.WhenAll(tasks);
//stopwatch.Stop();

//Console.WriteLine(stopwatch.ElapsedMilliseconds);



// Azure Table Service
//TableServiceHandler<Employee> tableServiceHandler = new TableServiceHandler<Employee>(connectionString);

//await tableServiceHandler.CreateTableIfNotExistAsync("Employees");

//Employee employee = new() { RowKey = "1004", PartitionKey = "Software Engineer I", Name = "Daniyal Ahmed", Age = 25, Experience = 7, Salary = (float)35000.5 };
//await tableServiceHandler.AddEntityAsync("Employees", employee);

//List<Employee> employees =
//[
//    new Employee { RowKey = "1007", PartitionKey = "Software Engineer IV", Name = "Elon Musk", Age = 60, Experience = 10, Salary = (float)40001.5 },
//    new Employee { RowKey = "1008", PartitionKey = "Software Engineer IV", Name = "Bill Gates", Age = 45, Experience = 7, Salary = (float)100002.5 },
//    new Employee { RowKey = "1009", PartitionKey = "Software Engineer IV", Name = "Tom Cruise", Age = 35, Experience = 7, Salary = (float)100003.5 },
//];
//await tableServiceHandler.AddEntitiesAsync("Employees", employees);

//Employee employee = await tableServiceHandler.GetEntityAsync("Employees", "1001", "Software Engineer I");
//Console.WriteLine($"Employees: {employee.RowKey} \n {employee.Name} \n {employee.PartitionKey} \n {employee.Age} \n {employee.Salary}");

//List<Employee> employees = await tableServiceHandler.GetEntitesAsync("Employees", x => x.Age >= 30);
//employees.ForEach(employee => Console.WriteLine($"Employees: {employee.RowKey} \n {employee.Name} \n {employee.PartitionKey} \n {employee.Age} \n {employee.Salary}"));

//Employee employee = await tableServiceHandler.GetEntityAsync("Employees", "1002", "Software Engineer I");
//employee.Name = "Asif Jabbar UPDATED";
//employee.Experience = (decimal)1.5;
//await tableServiceHandler.UpdateEntityAsync("Employees", employee, employee.ETag);

//await tableServiceHandler.DeleteEntityAsync("Employees", "Software Engineer IV", "1009");

// Azure Queue Service

//QueueServiceHandler queueServiceHandler = new QueueServiceHandler(connectionString);

//await queueServiceHandler.CreateIfNotExistsAsync("dotnet-queue");

//await queueServiceHandler.SendMessageAsync("dotnet-queue", "MessageMessageMessageMessageMessage2", false);

//PeekedMessageModel peekedMessageModel = await queueServiceHandler.PeekMessageAsync("dotnet-queue");
//Console.WriteLine($"MessageID: {peekedMessageModel.MessageId}, MessageBody: {peekedMessageModel.Body}");

//PeekedMessageModel[] peekedMessageModel = await queueServiceHandler.PeekMessagesAsync("dotnet-queue", 3);
//int i = 0;
//peekedMessageModel.ToList().ForEach(x => Console.WriteLine($"Index:{i++}, MessageID: {x.MessageId}, MessageBody: {x.Body}"));

//QueueMessageModel[] queueMessageModel = await queueServiceHandler.ReceiveMessagesAsync("dotnet-queue", 2, TimeSpan.FromSeconds(10));
//int i = 0;
//queueMessageModel.ToList().ForEach(x => Console.WriteLine($"Index:{i++}, MessageID: {x.MessageId}, MessageBody: {x.Body}"));
//queueMessageModel.ToList().ForEach(async x => await queueServiceHandler.DeleteMessageAsync("dotnet-queue", x.MessageId, x.PopReceipt));

//QueueMessageModel[] queueMessageModel = await queueServiceHandler.ReceiveMessagesAsync("dotnet-queue", 2, TimeSpan.FromSeconds(10));
//int i = 0;
//queueMessageModel.ToList().ForEach(x => Console.WriteLine($"Index:{i++}, MessageID: {x.MessageId}, MessageBody: {x.Body}"));
//await Parallel.ForEachAsync(queueMessageModel, async (x, y) =>
//{
//    await queueServiceHandler.UpdateMessageAsync("dotnet-queue", x.MessageId, x.PopReceipt, x.Body + " UPDATED");
//});


Console.WriteLine("Hello, World!");
