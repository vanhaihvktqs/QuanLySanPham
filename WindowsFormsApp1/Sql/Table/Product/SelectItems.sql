SELECT Id
     , CategoryId
     , Name
     , Image
     , Price
     , Quantity
     , CreateTime
     , UpdateTime
  FROM Product
 WHERE Id = @Id
   AND CategoryId = @CategoryId
