    Projection projection = new Projection()
    .withProjectionType(ProjectionType.INCLUDE);
    ArrayList<String> nonKeyAttributes = new ArrayList<String>();
    nonKeyAttributes.add("stock");
    nonKeyAttributes.add("price");
    projection.setNonKeyAttributes(nonKeyAttributes);
    GlobalSecondaryIndex nameIndex = new GlobalSecondaryIndex()
        .withIndexName("Name")
        .withProvisionedThroughput(new ProvisionedThroughput().withReadCapacityUnits((long) 10).withWriteCapacityUnits((long) 1))
                    .withProjection(projection);
    ArrayList<KeySchemaElement> indexKeySchema = new ArrayList<KeySchemaElement>();
    indexKeySchema.add(new KeySchemaElement().withAttributeName("name")
        .withKeyType(KeyType.HASH));
    nameIndex.setKeySchema(indexKeySchema);