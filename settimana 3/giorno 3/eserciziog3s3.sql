select COUNT(*) from Orders

select COUNT(*) from Employees

select COUNT(*) from Employees
where City='London'

select AVG(Freight) 
From Orders

select AVG(Freight) 
From Orders
Where CustomerID='BOTTM'

SELECT CustomerID, AVG(Freight)
FROM Orders
Group by CustomerID

SELECT COUNT(*) , City
FROM Employees 
Group by City

SELECT OrderId, SUM((UnitPrice*Quantity)) As TotaleRiga
From [Order Details]
Group by OrderID

SELECT OrderId, SUM((UnitPrice*Quantity)) As TotaleRiga
From [Order Details]
Group by OrderID
Having OrderID=10248

Select Count(*), CategoryID
From Products
Group by CategoryID

Select Count(*), ShipCountry
From Orders
Group by ShipCountry

Select AVG(Freight), ShipCountry
From Orders
Group by ShipCountry

