var params = {
    TableName: 'productTable',
    KeySchema: [ // The type of of schema.  Must start with a HASH type, with an optional second RANGE.
        { // Required HASH type attribute
            AttributeName: 'id',
            KeyType: 'HASH',
        },
        { // Optional RANGE key type for HASH + RANGE tables
            AttributeName: 'type', 
            KeyType: 'RANGE', 
        }
    ],
    AttributeDefinitions: [ // The names and types of all primary and index key attributes only
        {
            AttributeName: 'id',
            AttributeType: 'N', // (S | N | B) for string, number, binary
        },
        {
            AttributeName: 'type',
            AttributeType: 'S', // (S | N | B) for string, number, binary
        }
        // ... more attributes ...
    ],
    ProvisionedThroughput: { // required provisioned throughput for the table
        ReadCapacityUnits: 1, 
        WriteCapacityUnits: 1, 
    }
    // ,
    // GlobalSecondaryIndexes: [ // optional (list of GlobalSecondaryIndex)
    //     { 
    //         IndexName: 'index_name_1', 
    //         KeySchema: [
    //             { // Required HASH type attribute
    //                 AttributeName: 'hash_key_attribute_name',
    //                 KeyType: 'HASH',
    //             },
    //             { // Optional RANGE key type for HASH + RANGE secondary indexes
    //                 AttributeName: 'range_key_attribute_name', 
    //                 KeyType: 'RANGE', 
    //             }
    //         ],
    //         Projection: { // attributes to project into the index
    //             ProjectionType: 'ALL', // (ALL | KEYS_ONLY | INCLUDE)
    //             NonKeyAttributes: [ // required / allowed only for INCLUDE
    //                 'attribute_name_1',
    //                 // ... more attribute names ...
    //             ],
    //         },
    //         ProvisionedThroughput: { // throughput to provision to the index
    //             ReadCapacityUnits: 0,
    //             WriteCapacityUnits: 0,
    //         },
    //     },
    //     // ... more global secondary indexes ...
    // ],
    // LocalSecondaryIndexes: [ // optional (list of LocalSecondaryIndex)
    //     { 
    //         IndexName: 'index_name_2',
    //         KeySchema: [ 
    //             { // Required HASH type attribute - must match the table's HASH key attribute name
    //                 AttributeName: 'hash_key_attribute_name',
    //                 KeyType: 'HASH',
    //             },
    //             { // alternate RANGE key attribute for the secondary index
    //                 AttributeName: 'range_key_attribute_name', 
    //                 KeyType: 'RANGE', 
    //             }
    //         ],
    //         Projection: { // required
    //             NonKeyAttributes: [
    //                 'STRING_VALUE',
    //                 // ... more items ...
    //             ],
    //             ProjectionType: 'ALL | KEYS_ONLY | INCLUDE',
    //         },
    //     },
    //     // ... more local secondary indexes ...
    // ],
};
dynamodb.createTable(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response

});