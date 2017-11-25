var params = {
    TableName: 'productTable',
    Key: { 
        "id": 20,
        "type":"book"
    },
    ReturnValues: 'ALL_OLD', // optional (NONE | ALL_OLD)
    ReturnConsumedCapacity: 'TOTAL', // optional (NONE | TOTAL | INDEXES)
    ReturnItemCollectionMetrics: 'SIZE', // optional (NONE | SIZE)
};
docClient.delete(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response
});