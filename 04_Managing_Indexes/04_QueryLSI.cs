client = new AmazonDynamoDBClient();

QueryRequest queryRequest = new QueryRequest
{
    TableName = "product",
    IndexName = "IdManufacturerIndex",
    Select = "ALL_ATTRIBUTES",
    ScanIndexForward = true,
    KeyConditionExpression = "id = :v_id AND mnfr = :v_mnfr",
    ExpressionAttributeValues = new Dictionary<string,
    AttributeValue>()
   {
        {":v_id",new AttributeValue {N = "1"}},
        {":v_mnfr",new AttributeValue {S = "samsung"}}
    },
};

var result = client.Query(queryRequest);
