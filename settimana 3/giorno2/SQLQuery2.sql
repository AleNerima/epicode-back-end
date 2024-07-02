-- 1. Selezione di tutti i prodotti (tutti i campi)
SELECT * FROM Products;

-- 2. Selezione di tutti i prodotti con una quantità disponibile (UnitsInStock) di almeno 40 pezzi
SELECT * FROM Products
WHERE UnitsInStock >= 40;

-- 3. Selezione di tutti i dipendenti (Employees) che abitano a Londra
SELECT * FROM Employees
WHERE City = 'London';

-- 4. Selezione di tutti gli ordini, ordinati in ordine decrescente per spese di trasporto (Freight)
SELECT * FROM Orders
ORDER BY Freight DESC;

-- 5. Selezione degli ordini il cui importo del trasporto è compreso tra 90 e 200
SELECT * FROM Orders
WHERE Freight BETWEEN 90 AND 200;

-- 6. Selezione di tutti i prodotti la cui categoria è "1"
SELECT * FROM Products
WHERE CategoryID = 1;

-- 7. Selezione di tutte le righe dei dettagli degli ordini che hanno applicato uno sconto
SELECT * FROM [Order Details]
WHERE Discount <> 0;

-- 8. Selezione di tutti gli ordini del cliente con ID "BOTTM" le cui spese di trasporto superano l'importo di 50
SELECT * FROM Orders
WHERE CustomerID = 'BOTTM' 
AND Freight > 50;
