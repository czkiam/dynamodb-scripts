
// SET is upsert
var params = {
    TableName: 'productTable',
    Key: {

        "id": 20,
        "type": "book"
    },
    UpdateExpression: 'SET stock = :value, title = :titlevalue', 
    ExpressionAttributeValues: { 
        ':value': 97,
        ':titlevalue' : "book 1",
        ':num' : 98
    },
    ConditionExpression: "stock >= :num",
    ReturnValues:"ALL_NEW"
};
docClient.update(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response
});