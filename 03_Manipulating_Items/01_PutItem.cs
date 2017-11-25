AmazonDynamoDBClient client = new AmazonDynamoDBClient();
string tableName = "productTable";

var request = new PutItemRequest
{
   TableName = tableName,
   Item = new Dictionary<string, AttributeValue>()
      {
          { "id", new AttributeValue { N = "20" }},
          { "type", new AttributeValue { S = "book" }},
          { "stock", new AttributeValue { N = "110" }},
          { "price", new AttributeValue { N = "55" }},
          { "title", new AttributeValue { S = "Mastering DynamoDB" }},
          
      }
};

client.PutItem(request);