AmazonDynamoDBClient client = new AmazonDynamoDBClient();
string tableName = "productTable";

var request = new UpdateItemRequest
{
    TableName = tableName,
    Key = new Dictionary<string,AttributeValue>() { { "id", new AttributeValue { N = "20" } },
    { "type", new AttributeValue { S = "phone" }},
    ExpressionAttributeNames = new Dictionary<string,string>()
    {
        {"#R", "rating"},
        {"#S", "stock"},
        {"#M", "mnfr"}
    },
    ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
    {
        {":val1",new AttributeValue { N = "5"}},
        {":val2",new AttributeValue {N = "2"}}
    },
    UpdateExpression = "ADD #R :val1 SET #S = #S - :val2 REMOVE #M"
};

var response = client.UpdateItem(request);

//conditional update example
var request = new UpdateItemRequest
{
    Key = new Dictionary<string,AttributeValue>() { { "id", new AttributeValue { N = "10" } }, { "type", new AttributeValue { S = "phone" } }    }, ExpressionAttributeNames = new Dictionary<string,string>()
    {
        {"#S", "stock"}
    },
    ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
    {
        {":newprice",new AttributeValue {N = "50"}},// Update stock to 50 only if
        {":currprice",new AttributeValue {N = "20"}} // Current value is 20
    },
    UpdateExpression = "SET #S = :newprice",
    ConditionExpression = "#S = :currprice",
    TableName = tableName,
    ReturnValues = "ALL_NEW" 
};