var params = {
    TableName: 'productTableGSI',
    IndexName: "NameManfrIndex",
    KeyConditionExpression: '#nm = :value', // a string representing a constraint on the attribute
    ExpressionAttributeNames: { // a map of substitutions for attribute names with special characters
        '#nm': 'name'
    },
    ExpressionAttributeValues: { // a map of substitutions for all attribute values
      ':value': 'S3'
    }
};
docClient.query(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response

});