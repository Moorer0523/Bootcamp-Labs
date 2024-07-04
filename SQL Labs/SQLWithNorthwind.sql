-- Write SQL queries to do the following:

-- 1. Select all the rows from the "Customers" table. 
SELECT *
FROM Customers

-- 2. Get distinct countries from the Customers table. (Hint: research the DISTINCT keyword.)
SELECT DISTINCT(Country)
FROM Customers

-- 3. Get all the rows from the table Customers where the Customer’s ID starts with “BL”.
SELECT *
FROM Customers
WHERE CustomerID LIKE 'BL%'

-- 4. Get the first 100 records of the orders table. (Hint: research the TOP keyword.) DISCUSS: Why would you do this? What else would you likely need to include in this query?
SELECT TOP(100) *
FROM Orders

-- 5. Get all customers that live in the postal codes 1010, 3012, 12209, and 05023. (Hint: research the IN keyword.)
SELECT *
FROM Customers
WHERE PostalCode IN ('1010','3012','12209','05023')

-- 6. Get all orders where the ShipRegion is not equal to NULL.
SELECT *
FROM Orders
WHERE ShipRegion IS NOT NULL

-- 7. Get all customers ordered by the country, then by the city.
SELECT *
FROM Customers
ORDER BY Country, City

-- 8. Add a new customer to the customers table. You can use whatever values.
INSERT INTO Customers
VALUES ('HUBSU', 'Hub SuperMarket', 'Rob Moore', 'Owner', '123 Lake Street', 'Houghton Lake', NULL, '48629', 'USA', '(867)530-9999',NULL)

-- 9. Update all ShipRegion to the value ‘EuroZone’ in the Orders table, where the ShipCountry is equal to France.  
UPDATE Orders
SET ShipRegion = 'EuroZone'
WHERE ShipCountry = 'France'

-- 10. Delete all orders from OrderDetails that have quantity of 1. 
DELETE [Order Details]
WHERE Quantity = 1

-- 11. Find the CustomerID that placed order 10290 (orders table).
SELECT CustomerID
FROM Orders
WHERE OrderID = '10290'

-- 12. Join the orders table to the customers table.
SELECT *
FROM Customers
INNER JOIN Orders
ON Customers.CustomerID = Orders.CustomerID 

-- 13. Get employees’ firstname for all employees who report to no one.
SELECT FirstName
FROM Employees
WHERE ReportsTo IS NULL

-- 14. Get employees’ firstname for all employees who report to Andrew.
SELECT FirstName
FROM Employees
WHERE ReportsTo = 2

-- 15. Write an SQL command to create an index on the CustomerID column in the Customers table.
CREATE INDEX idx_customerid
ON Customers (CustomerID)

-- Extra Challenges:
-- Optional additional query practice (extended challenge):
-- 1. Calculate the average, max, and min of the quantity at the orderdetails table, grouped by the orderid. 
SELECT AVG(Quantity) Avg_Quant, MAX(Quantity) Max_Quant, MIN(Quantity) Min_Quant, OrderID
FROM [Order Details]
GROUP BY OrderID

-- 2. Calculate the average, max, and min of the quantity at the orderdetails table.
SELECT AVG(Quantity) Avg_Quant, MAX(Quantity) Max_Quant, MIN(Quantity) Min_Quant
FROM [Order Details]

-- 3. Find all customers living in London or Paris
SELECT *
FROM Customers
WHERE City IN ('London', 'Paris')

-- 4. Do an inner join, left join, right join on orders and customers tables. 
SELECT *
FROM Orders
INNER JOIN Customers
ON Orders.CustomerID = Customers.CustomerID

SELECT *
FROM Orders
LEFT JOIN Customers
ON Orders.CustomerID = Customers.CustomerID

SELECT *
FROM Orders
RIGHT JOIN Customers
ON Orders.CustomerID = Customers.CustomerID

-- 5. Make a list of cities where customers are coming from. The list should not have any duplicates or nulls.

SELECT DISTINCT(City)
FROM Customers
WHERE City IS NOT NULL

-- 6. Show a sorted list of employees’ first names. 
SELECT FirstName
FROM Employees
ORDER BY FirstName

-- 7. Find total for each order
SELECT SUM(Freight) Freight, OrderID
FROM Orders
GROUP BY OrderID

-- 8. Get a list of all employees who got hired between 1/1/1994 and today
SELECT *
FROM Employees
WHERE HireDate BETWEEN '1994-01-01' AND GETDATE()

-- 9. Find how long employees have been working for Northwind (in years!)
SELECT SUM(YEAR(GETDATE())-YEAR(HireDate)), FirstName
FROM Employees
GROUP BY FirstName

-- 10. Get a list of all products sorted by quantity (ascending and descending order)
SELECT *
FROM Products
ORDER BY UnitsInStock --DESC

-- 11. Find all products that are low on stock (quantity less than 6)
SELECT *
FROM Products
WHERE UnitsInStock < 6
ORDER BY UnitsInStock --DESC

-- 12. Find a list of all discontinued products. 
SELECT *
FROM Products
WHERE Discontinued = 1

-- 13. Find a list of all products that have Tofu in the product name.
SELECT *
FROM Products
WHERE ProductName LIKE '%Tofu%'

-- 14. Find the product that has the highest unit price. 
SELECT TOP 1 *
FROM Products
ORDER BY UnitPrice

-- 15. Get a list of all employees who got hired after 1/1/1993
SELECT *
FROM Employees
WHERE HireDate BETWEEN '1993-01-01' AND GETDATE()

-- 16. Get all employees who have title : “Ms.” And “Mrs.”
SELECT *
FROM Employees
WHERE TitleOfCourtesy IN ('Ms.','Mrs')

-- 17. Get all employees who have a Home phone number that has area code 206

SELECT *
FROM Employees
WHERE HomePhone LIKE '(206%'


--EXTRA PDF STUFF

-- 1. Retrieve all the columns from the Customers table for customers who are from the UK.
SELECT *
FROM Customers
WHERE Country = 'UK'

-- 2. Using the Products table, list the product names and their unit prices where the unit price is greater than 30.
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice > 30

-- 3. Count the number of products in the Products table that have been discontinued.
SELECT COUNT(ProductID) Number_Of_Discontinued
FROM Products
WHERE Discontinued = 1

-- 4. Find the average, maximum, and minimum unit prices from the Products table.
SELECT AVG(UnitPrice) Avg_Price, MAX(UnitPrice) Max_Price, MIN(UnitPrice) Min_Price
FROM Products


-- 5. Retrieve the names of categories and the count of products in each category from the Categories and Products tables.
SELECT COUNT(ProductID), CategoryName
FROM Products
JOIN Categories
ON Products.CategoryID = Categories.CategoryID
GROUP BY CategoryName


-- 6. List the suppliers (SupplierID and CompanyName) from the Suppliers table who are not from USA, Germany, or UK.
SELECT SupplierID, CompanyName
FROM Suppliers
WHERE Country NOT IN ('USA','Germany','UK')

-- 7. Retrieve all the distinct countries from the Customers table.
SELECT DISTINCT(Country) Country
FROM Customers

-- 8. Find the top 5 most expensive products (Product name and Unit price) from the Products table.
SELECT TOP 5 ProductName, UnitPrice
FROM Products
ORDER BY UnitPrice DESC

-- 9. Using the Orders and Order Details tables, calculate the total revenue for each order (OrderID).
SELECT Orders.OrderID, Orders.Freight + (UnitPrice * Quantity * 1 - Discount)
FROM Orders
LEFT JOIN [Order Details]
ON Orders.OrderID = [Order Details].OrderID

-- 10. List all employees (FirstName and LastName) and the count of orders they have taken from the Employees and Orders tables.
SELECT Employees.EmployeeID, FirstName, LastName, COUNT(OrderID)
FROM Employees
JOIN Orders
ON Employees.EmployeeID = Orders.EmployeeID
GROUP BY Employees.EmployeeID, FirstName, LastName


-- 11. Retrieve customers (CustomerID and CompanyName) who have placed more than 10 orders using the Customers and Orders tables.
SELECT Customers.CustomerID, CompanyName
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, CompanyName
HAVING COUNT(OrderID) > 10

-- 12. From the Products table, retrieve the names of products that are out of stock (units in stock is 0).
SELECT ProductName
FROM Products
WHERE UnitsInStock = 0

-- 13. Using the Products and Categories tables, list the names of products and their respective categories where the category is either 'Beverage' or 'Confectionery'.

SELECT ProductName, CategoryName
FROM Products
JOIN Categories
ON Products.CategoryID = Categories.CategoryID
--WHERE CategoryName IN ('Beverage', 'Confectionery')
WHERE CategoryName IN ('Beverages', 'Confections')
GROUP BY CategoryName, ProductName


-- 14. Identify which supplier (SupplierID and CompanyName from Suppliers table) has the highest number of products in the Products table.
SELECT TOP 1 Suppliers.SupplierID, CompanyName
FROM Suppliers
JOIN Products
ON Suppliers.SupplierID = Products.SupplierID
GROUP BY Suppliers.SupplierID, CompanyName
ORDER BY COUNT(Products.SupplierID) DESC


-- 15. List all the products (ProductID and ProductName) which have never been ordered. Use the Products and Order Details tables.
SELECT Products.ProductID, ProductName, COUNT([Order Details].ProductID)
FROM Products
JOIN [Order Details]
ON Products.ProductID = [Order Details].ProductID
GROUP BY Products.ProductID, ProductName
HAVING COUNT([Order Details].ProductID) = 0

-- 16. Retrieve all orders (OrderID from Orders table) that were placed in December 1997.
SELECT OrderID
FROM Orders
WHERE OrderDate BETWEEN '1997-12-01' AND '1997-12-31'

-- 17. Using the Employees and Orders tables, find out which employee has processed the most number of orders in 1998.

SELECT TOP 1 Employees.EmployeeID, FirstName, LastName, COUNT(OrderID)
FROM Employees
JOIN Orders
ON Employees.EmployeeID = Orders.EmployeeID
WHERE OrderDate BETWEEN '1998-01-01' AND '1998-12-31'
GROUP BY Employees.EmployeeID, FirstName, LastName
ORDER BY COUNT(OrderID) DESC

-- 18. Find the customer (CustomerID and CompanyName from Customers table) who has purchased the most by quantity in the Order Details table.
SELECT TOP 1 Orders.OrderID, Customers.CustomerID, CompanyName, COUNT(Quantity)
FROM Customers
LEFT JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
LEFT JOIN [Order Details]
ON Orders.OrderID = [Order Details].OrderID
GROUP BY Customers.CustomerID, CompanyName, Orders.OrderID
Order By COUNT(Quantity) DESC



-- 19. From the Shippers and Orders tables, determine which shipper has delivered the most number of orders.
SELECT TOP 1 CompanyName, COUNT(OrderID)
FROM Shippers
JOIN Orders
ON Shippers.ShipperID = Orders.ShipVia
Group By CompanyName
Order By COUNT(OrderID) DESC

-- 20. Identify the top 3 categories in terms of the number of products they have using the Categories and Products tables

SELECT TOP 3 CategoryName, COUNT(CategoryName)
FROM Products
JOIN Categories
ON Products.CategoryID = Categories.CategoryID
GROUP BY CategoryName
ORDER BY COUNT(CategoryName)DESC
