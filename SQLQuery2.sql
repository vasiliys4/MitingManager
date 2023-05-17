SELECT
Products.Name,
Sellers.Surname,
Sellers.Name,
SUM(Sales.Quantity * Products.Price) / (SELECT SUM(Quantity) FROM Sales WHERE Sales.IDProd = Products.ID AND Sales.Date BETWEEN '2013-09-07' AND '2013-10-07') * 100 AS SalesPercentage
FROM
Sales
INNER JOIN Sellers ON Sales.IDSel = Sellers.ID
INNER JOIN Products ON Sales.IDProd = Products.ID
WHERE
Sales.Date BETWEEN '2013-10-01' AND '2013-10-07'
GROUP BY
Products.Name,
Sellers.Surname,
Sellers.Name
HAVING
SUM(Sales.Quantity) > 0
ORDER BY
Products.Name,
Sellers.Surname,
Sellers.Name;