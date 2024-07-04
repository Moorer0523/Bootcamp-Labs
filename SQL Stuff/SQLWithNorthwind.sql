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
