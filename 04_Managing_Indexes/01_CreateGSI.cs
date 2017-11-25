AttributeDefinitions = new List<AttributeDefinition>(){
    new AttributeDefinition{
        AttributeName="id", AttributeType="N"
    },
    new AttributeDefinition{
        AttributeName="type", AttributeType="S"
    },
    new AttributeDefinition{
        AttributeName="name", AttributeType="S"
    },
    new AttributeDefinition{
        AttributeName="mnfr", AttributeType="S"
    }
    };
    // Table key schema
    var tableKeySchema = new List<KeySchemaElement>()
    {
        new KeySchemaElement{AttributeName="id", KeyType="HASH"
    },
    new KeySchemaElement{ AttributeName="type", KeyType="RANGE"
    }
};

var nameMnfrIndex = new GlobalSecondaryIndex
{
    IndexName = "NameManfrIndex",
    ProvisionedThroughput = new ProvisionedThroughput
    {
        ReadCapacityUnits = (long)5,
        WriteCapacityUnits = (long)5
    },
    Projection = new Projection { ProjectionType = "ALL" }
};

var indexKeySchema = new List<KeySchemaElement> {
    {new KeySchemaElement { AttributeName = "name", 
        KeyType = "HASH"}},
    {new KeySchemaElement{AttributeName = "mnfr",KeyType = "RANGE"}}
};
nameMnfrIndex.KeySchema = indexKeySchema;

string tableName = "productTable";
CreateTableRequest createTableRequest = new CreateTableRequest
{
    TableName = tableName,
    ProvisionedThroughput = new ProvisionedThroughput
    {
        ReadCapacityUnits = (long)5,
        WriteCapacityUnits = (long)5
    },
    AttributeDefinitions = attributeDefinitions,
    KeySchema = tableKeySchema,
    GlobalSecondaryIndexes = { nameMnfrIndex }
};

CreateTableResponse response = client.CreateTable(createTableRequest);