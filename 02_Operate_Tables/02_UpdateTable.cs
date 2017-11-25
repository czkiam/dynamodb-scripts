AmazonDynamoDBClient client = new AmazonDynamoDBClient();
string tableName = "productTableNet";
var request=new UpdateTableRequest(){
  TableName=tableName,
  ProvisionedThroughput = new ProvisionedThroughput(){
    ReadCapacityUnits=2,
      WriteCapacityUnits=2
  }
};

var response = client.UpdateTable(request);