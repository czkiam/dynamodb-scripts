AmazonDynamoDBClient client = new AmazonDynamoDBClient();

// Params
string tableName = "productTableNet";
var request=new CreateTableRequest{
  AttributeDefinitions=newList<AttributeDefinition>(){
    newAttributeDefinition{
      AttributeName="id", AttributeType="N"
    },
    newAttributeDefinition{
      AttributeName="type", AttributeType="S"
    }
  },
  KeySchema=newList<KeySchemaElement>{
    newKeySchemaElement{
      AttributeName="id", KeyType="HASH"
    },
    newKeySchemaElement{
      AttributeName="type", KeyType="RANGE"
    }
  },
  ProvisionedThroughput=newProvisionedThroughput{
    ReadCapacityUnits=1, WriteCapacityUnits=1
  },
  TableName=tableName
};

//run DynamoBDClient to create table
var response = client.CreateTable(request);