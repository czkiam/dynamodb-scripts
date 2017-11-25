AmazonDynamoDBClient client = new AmazonDynamoDBClient();
string tableName = "productTable";

var request = new DeleteItemRequest
{
    TableName = tableName,
    Key = new Dictionary<string,AttributeValue>() 
{ 
{ "id", new AttributeValue { N = "20" } },
   { "type", new AttributeValue { S = "phone" }}
}
};

var response = client.DeleteItem(request);