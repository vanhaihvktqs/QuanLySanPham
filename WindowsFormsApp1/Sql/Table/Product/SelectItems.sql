SELECT Id
     , CategoryId
     , Name
     , Image
     , Price
     , Quantity
     , Description
     , CreateTime
     , UpdateTime
  FROM Product
 WHERE Id = @Id
   AND CategoryId = @CategoryId
