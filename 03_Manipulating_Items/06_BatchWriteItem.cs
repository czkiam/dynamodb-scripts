AmazonDynamoDBClient client = new AmazonDynamoDBClient();
string tableName = "productTable";

var request = new BatchWriteItemRequest
 {
   RequestItems = new Dictionary<string, List<WriteRequest>>
    {
      {
        tableName, new List<WriteRequest>
        {
          new WriteRequest
          {
            PutRequest = new PutRequest
            {
               Item = new Dictionary<string,AttributeValue>
               {
                 { "id", new AttributeValue { N = 40 } },
                 { "type", new AttributeValue { S = "book" } },
                 { "title", new AttributeValue { S = "DynamoDB Cookbook" } }
               }
            }
          },
          new WriteRequest
          {
             DeleteRequest = new DeleteRequest
             {
                Key = new Dictionary<string,AttributeValue>()
                {
                 { "id", new AttributeValue { N = 10 } },
                 { "type", new AttributeValue { S = "phone" } }
                }
             }
          }
        }
      } 
    }
 };

 response = client.BatchWriteItem(request);