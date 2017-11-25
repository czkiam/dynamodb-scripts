AttributeDefinitions = new List<AttributeDefinition>(){
    new AttributeDefinition{
        AttributeName="id",
        AttributeType="N"
    },
    new AttributeDefinition{
        AttributeName="type",
        AttributeType="S"
    },
    new AttributeDefinition{
        AttributeName="mnfr",
        AttributeType="S"
    }
};
// Table key schema
var tableKeySchema = new List<KeySchemaElement>()
{
    new KeySchemaElement{
        AttributeName="id",
        KeyType="HASH"
    },
    new KeySchemaElement{
        AttributeName="type",
        KeyType="RANGE"
    }
};

List<KeySchemaElement> indexKeySchema = new List<KeySchemaElement>();
indexKeySchema.Add(new KeySchemaElement() { AttributeName = "id", KeyType = "HASH" });
indexKeySchema.Add(new KeySchemaElement() { AttributeName = "mnfr", KeyType = "RANGE" });
Projection projection = new Projection() { ProjectionType = "INCLUDE" };

LocalSecondaryIndex localSecondaryIndex = new LocalSecondaryIndex()
{
    IndexName = "IdManufacturerIndex",
    KeySchema = indexKeySchema,
    Projection = projection
};

List<LocalSecondaryIndex> localSecondaryIndexes = new List<LocalSecondaryIndex>();
localSecondaryIndexes.Add(localSecondaryIndex);

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
LocalSecondaryIndexes = { localSecondaryIndexes }
};

CreateTableResponse response = client.CreateTable(createTableRequest);
