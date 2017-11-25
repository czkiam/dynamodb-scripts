string tableName = "productTableNet";
var request = new DeleteTableRequest
            {
                TableName = tableName
            };

var response = client.DeleteTable(request);