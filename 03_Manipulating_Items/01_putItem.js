
//with docementClient
var params = {
    TableName: 'productTable',
    Item: { // a map of attribute name to AttributeValue
        
        id: 51,
        type:"book",
        stock: 110,
        price:20,
        title: "test book"
    },
    ReturnConsumedCapacity: "TOTAL",
    ReturnValues: "ALL_OLD"
};
docClient.put(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response
});