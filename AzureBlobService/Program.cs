using AzureBlobService;

string connectionString = "";

// Azure Blob Service
//BlobServiceHandler blobServiceHandler = new BlobServiceHandler(connectionString);

//await blobServiceHandler.CreateContainerAsync("dotnet-program");
//blobServiceHandler.GetAllContainersName().ForEach(x => Console.WriteLine(x));
//await blobServiceHandler.UploadBlobAsync("dotnet-program", $"2024/01/30/{Guid.NewGuid()}", @"C:\Users\CC378\Downloads\TestLogo2.jpg");
//await blobServiceHandler.DownloadToAsync("dotnet-program", $"2024/01/30/4bdc97cf-eaca-45e8-8bb3-a07922bd80d6", @"C:\Users\CC378\Downloads\TestLogo222.jpg");
//await blobServiceHandler.DeleteIfExistsAsync("dotnet-program", $"2024/01/30/4bdc97cf-eaca-45e8-8bb3-a07922bd80d6");
//string url = await blobServiceHandler.GetBlobUrl("dotnet-program", $"2024/01/30/6ead8bb8-70e2-45e3-b108-c08a54280a9a", TimeSpan.FromSeconds(120)); Console.WriteLine(url);
//blobServiceHandler.GetAllBlobsName("dotnet-program").ForEach(x => Console.WriteLine(x));

//Dictionary<string, string> blobProperties = await blobServiceHandler.GetBlobPropertiesAsync("dotnet-program", $"2024/01/30/0a2895d3-7b67-4eb3-982b-f0750261130a");
//foreach (var property in blobProperties)
//    Console.WriteLine($"{property.Key}: {property.Value}");

//await blobServiceHandler.SetBlobMatadataAsync("dotnet-program", $"2024/01/30/0a2895d3-7b67-4eb3-982b-f0750261130a", new Dictionary<string, string> { { "FirstKey", "FirstValue" }, { "SecondKey", "SecondValue" } });

//await blobServiceHandler.UpdateBlobAsync("dotnet-program", $"2024/01/30/0a2895d3-7b67-4eb3-982b-f0750261130a", @"C:\Users\CC378\Downloads\TestLogo.jpg");

// Azure Table Service
TableServiceHandler<Employee> tableServiceHandler = new TableServiceHandler<Employee>(connectionString);

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

Console.WriteLine("Hello, World!");
