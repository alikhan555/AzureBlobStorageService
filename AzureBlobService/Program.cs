using AzureBlobService;

string connectionString = "";
BlobServiceHandler blobServiceHandler = new BlobServiceHandler(connectionString);

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



Console.WriteLine("Hello, World!");
