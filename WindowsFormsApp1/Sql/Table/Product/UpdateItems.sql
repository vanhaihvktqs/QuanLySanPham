UPDATE Product
   SET Name = @Name
     , Image = @Image
     , Price = @Price
     , Quantity = @Quantity
     , UpdateTime = @UpdateTime
 WHERE Id = @Id
   AND CategoryId = @CategoryId