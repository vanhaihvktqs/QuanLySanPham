SELECT Product.Id
     , Product.CategoryId
     , Product.Name
     , Product.Image
     , Product.Price
     , Product.Quantity
     , Product.CreateTime
     , Product.UpdateTime
  FROM Product
 INNER JOIN Category
    ON Product.CategoryId = Category.Id
 WHERE Product.Name LIKE CONCAT(N'%',@ProductName,'%')
   AND (@CategoryId IS NULL OR @CategoryId = '' OR  Product.CategoryId = @CategoryId)