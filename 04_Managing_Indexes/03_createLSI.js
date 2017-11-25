var params = {
    TableName: 'productTableLSI',
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
        },
        {
            AttributeName: 'mnfr',
            AttributeType: 'S', // (S | N | B) for string, number, binary
        }
        // ... more attributes ...
    ],
    ProvisionedThroughput: { // required provisioned throughput for the table
        ReadCapacityUnits: 1, 
        WriteCapacityUnits: 1, 
    }
    ,
    LocalSecondaryIndexes: [ // optional (list of LocalSecondaryIndex)
        { 
            IndexName: 'IdManufacturerIndex',
            KeySchema: [ 
                { // Required HASH type attribute - must match the table's HASH key attribute name
                    AttributeName: 'id',
                    KeyType: 'HASH',
                },
                { // alternate RANGE key attribute for the secondary index
                    AttributeName: 'mnfr', 
                    KeyType: 'RANGE', 
                }
            ],
            Projection: { // required
                ProjectionType: 'ALL',
            },
        },
        // ... more local secondary indexes ...
    ],
  };
  dynamodb.createTable(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response
  
  });