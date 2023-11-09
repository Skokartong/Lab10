-- Sorting products after product name
SELECT ProductName, UnitPrice, CategoryID 
FROM Products
ORDER BY ProductName;

-- Sorting products after category id
SELECT ProductName, CategoryID 
FROM Products
ORDER BY CategoryID;

-- Viewing customer information and their order quantities in descending order
SELECT Customers.ContactName, COUNT(Orders.OrderID) AS QuantityOfOrders
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.ContactName
ORDER BY QuantityOfOrders DESC;

-- Viewing all employees and their territories
SELECT Employees.FirstName, Employees.LastName, Employees.Title,
EmployeeTerritories.EmployeeID, EmployeeTerritories.TerritoryID
FROM Employees
JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID;