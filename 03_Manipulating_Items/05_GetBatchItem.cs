AmazonDynamoDBClient client = new AmazonDynamoDBClient();
string tableName = "productTable";

var request = new BatchGetItemRequest
{
  RequestItems = new Dictionary<string, KeysAndAttributes>()
  {
    {
      tableName,
      new KeysAndAttributes
      {
        Keys = new List<Dictionary<string, AttributeValue>>()
        {
          new Dictionary<string, AttributeValue>()
          {
            { "id", new AttributeValue { N = 10 } },
            { "type", new AttributeValue { S = "phone" } }
          },
          new Dictionary<string, AttributeValue>()
          {
            { "id", new AttributeValue { N = 20 } },
            { "type", new AttributeValue { S = "phone" } }
          }
        }
      }
    }
  }
};

var response = client.BatchGetItem(request);