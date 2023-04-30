UPDATE Product
   SET Name = @Name
     , Image = @Image
     , Price = @Price
     , Quantity = @Quantity
     , Description = @Description
     , UpdateTime = @UpdateTime
 WHERE Id = @Id
   AND CategoryId = @CategoryId