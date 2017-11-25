var params = {
    TableName: 'productTableLSI',
    IndexName: "IdManufacturerIndex",
    Select: 'ALL_ATTRIBUTES',
    ScanIndexForward : true,
    KeyConditionExpression: 'id = :v_id AND mnfr = :v_mnfr', // a string representing a constraint on the attribute
    ExpressionAttributeValues: { // a map of substitutions for all attribute values
      ':v_id': 1,
      ':v_mnfr': 'samsung'
    }
};
docClient.query(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response

});