var params = {
    TableName: "productTable",
    Key:{"id": 10, "type":"book"}
};

docClient.get(params, function(err, data) {
    if (err) ppJson(err); // an error occurred
    else ppJson(data); // successful response
});