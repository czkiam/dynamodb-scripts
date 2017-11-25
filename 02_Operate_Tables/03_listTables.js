dynamodb.listTables().eachPage(function(err, data) {
    if (err) {
        ppJson(err); // an error occurred
    } else if (data) {
        ppJson(data);
    }
});