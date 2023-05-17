SELECT
Sellers.Surname,
Sellers.Name,
SUM(Sales.Quantity * Products.Price) AS SalesVolume
FROM
Sales
INNER JOIN Sellers ON Sales.IDSel = Sellers.ID
INNER JOIN Products ON Sales.IDProd = Products.ID
WHERE
Sales.Date BETWEEN '2013-10-01' AND '2013-10-07'
GROUP BY
Sellers.Surname,
Sellers.Name
ORDER BY
Sellers.Surname,
Sellers.Name;