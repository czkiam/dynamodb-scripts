client = new AmazonDynamoDBClient();

QueryRequest queryRequest = new QueryRequest
{
    TableName = "productTableGSI",
    IndexName = "NameManfrIndex",
    KeyConditionExpression = "#nm = :v_name",
    ExpressionAttributeNames = new Dictionary<String, String> {
        {"#nm", "name"}
    },
    ExpressionAttributeValues = new Dictionary< string, AttributeValue> {
        {":v_name", new AttributeValue { S =  "S3" }}
    }
    };

    var result = client.Query(queryRequest);