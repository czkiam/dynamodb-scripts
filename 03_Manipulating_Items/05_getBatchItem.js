var params = {
    RequestItems: { // map of TableName to list of Key to get from each table
        productTable: {
            Keys: [ // a list of primary key value maps
                {
                    "id": 31,
                    "type": "book"
                },
                {
                    "id": 30,
                    "type": "book"
                },
                {
                    "id": 10,
                    "type": "book"
                },
                // ... more keys to get from this table ...
            ],
            AttributesToGet: [ 
                "id",
                "type",
                "stock",
                "price"
            ],
            ConsistentRead: false, // optional (true | false)
        },
        // ... more tables and keys ...
    },
    ReturnConsumedCapacity: 'TOTAL', // optional (NONE | TOTAL | INDEXES)
};
docClient.batchGet(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response

});