AmazonDynamoDBClient client = new AmazonDynamoDBClient();
var response = client.ListTables();
ListTablesResult result = response.ListTablesResult;

foreach (string name in result.TableNames)
Console.WriteLine(name);