SELECT MAX(Id) AS Id
  FROM Product
 WHERE CategoryId = @CategoryId
