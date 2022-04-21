-- 1..1
-- 1..*
-- *..*
-- Data Integrity (Data Correctness)
-- Entity Integrity - Primary Key Constraint
-- Referential Integrity - Foreign Key Constraint
-- Domain Integrity 
-- User-Defined Integrity

-- CRUD
-- Create, Retrieve, Update, Delete

use ToyUniverse;

SELECT * FROM Toys;

SELECT
    cToyId,
    vToyName,
    vToyDescription,
    mToyRate
FROM
    Toys;

SELECT TOP 5 * FROM Toys;

SELECT
    cToyId,
    vToyName,
    vToyDescription,
    mToyRate
FROM
    Toys
WHERE
    cToyId = '000001';

SELECT
    cToyId,
    vToyName,
    vToyDescription,
    mToyRate
FROM
    Toys
WHERE
    cBrandId = '001';

SELECT
    cToyId,
    vToyName,
    vToyDescription,
    mToyRate
FROM
    Toys
WHERE 
    mToyRate >= 10 AND mToyRate <= 20;

SELECT
    cToyId,
    vToyName,
    vToyDescription,
    mToyRate,
    cBrandId
FROM
    Toys
WHERE
    mToyRate <= 20 OR cBrandId = '002';

SELECT
    cToyId,
    vToyName,
    vToyDescription,
    mToyRate,
    cBrandId
FROM
    Toys
WHERE
    (mToyRate >= 10 AND mToyRate <= 20)
        OR cBrandId = '002';

SELECT
    cToyId AS "Id",
    vToyName AS "Name",
    vToyDescription as "Description",
    mToyRate as "Price",
    cBrandId as "BrandId"
FROM
    Toys
WHERE
    cToyId >= 10 AND mToyRate <= 20
ORDER BY
    mToyRate, cBrandId DESC;

SELECT
    cToyId AS "Id",
    vToyName AS "Name",
    vToyDescription as "Description",
    mToyRate as "Price",
    cBrandId as "BrandId"
FROM
    Toys
WHERE
    vToyName LIKE '%Doll%';

-- AVG, SUM, COUNT, MIN, MAX
SELECT 
    MIN(mToyRate) AS MINIMUM_PRICE,
    MAX(mToyRate) AS MAXIMUM_PRICE,
    SUM(mToyRate) AS TOTAL_CATALOG_PRICE,
    AVG(mToyRate) AS AVERAGE_PRICE,
    COUNT(*) AS NUMBER_OF_TOYS
FROM Toys;

-- COLUMNS NOT USED IN AN AGGREGATE FUNCTION
-- COLUMNS THAT ARE USED IN AGGREGATE FUNCTION
-- COLUMNS NOT USED IN AN AGGREGATE FUNCTION SHOULD BE DEFINE IN GROUP BY CLAUSE
SELECT cBrandId, cCategoryId, COUNT(*) AS TOTAL_COUNT
FROM Toys
WHERE cBrandId = '001'
GROUP BY cBrandId, cCategoryId
HAVING COUNT(*) > 3


-- non-correlated
SELECT 
    cToyId AS "Id",
    vToyName AS "Name",
    vToyDescription as "Description",
    mToyRate as "Price",
    cBrandId as "BrandId"
FROM 
    Toys
WHERE 
    mToyRate >= (SELECT AVG(mToyRate) FROM Toys)


-- SELECT
-- FROM
-- WHERE
-- GROUP BY
-- HAVING
-- ORDER BY

DROP TABLE Applicant;

CREATE TABLE Applicant 
(
    Id INT NOT NULL,
    FirstName VARCHAR(150) NOT NULL,
    LastName VARCHAR(150) NOT NULL,
    Salary DECIMAL(11, 2) NOT NULL,
    PRIMARY KEY(Id)
);

SELECT * FROM Applicant;

INSERT INTO Applicant(Id, FirstName, LastName, Salary) VALUES(1, 'John', 'Doe', 1000);
INSERT INTO Applicant(Id, FirstName, LastName, Salary) VALUES(2, 'John', 'Doe', 1000);
INSERT INTO Applicant(Id, FirstName, LastName, Salary) VALUES(3, 'John', 'Doe', 1000);

UPDATE Applicant SET FirstName='Jane', Salary = Salary + 10000 WHERE Id = 1;

DELETE FROM Applicant WHERE Id = 3;

SELECT * FROM Toys;

UPDATE Toys SET cBrandId = null WHERE cToyId = '000001';

SELECT COUNT(*) FROM Toys;
SELECT COUNT(cBrandId) FROM Toys;
SELECT COUNT(DISTINCT cBrandId) FROM Toys;

SELECT DISTINCT cBrandId FROM Toys WHERE cBrandId IS NOT NULL; -- IS NULL or IS NOT NULL
SELECT 
    DISTINCT cBrandId, mToyRate 
FROM 
    Toys 
WHERE 
    cBrandId IS NOT NULL
ORDER BY
    cBrandId ASC, mToyRate DESC;

-- INNER
SELECT
    cToyId AS "Id",
    vToyName AS "Name",
    vToyDescription as "Description",
    mToyRate as "Price",
    t.cBrandId as "BrandId",
    cBrandName as "BrandName"
FROM
    Toys t JOIN ToyBrand tb
        ON t.cBrandId = tb.cBrandId;

-- OUTER - LEFT, RIGHT, FULL OUTER

SELECT
    cToyId AS "Id",
    vToyName AS "Name",
    vToyDescription as "Description",
    mToyRate as "Price",
    t.cBrandId as "BrandId",
    cBrandName as "BrandName"
FROM
    Toys t LEFT OUTER JOIN ToyBrand tb
        ON t.cBrandId = tb.cBrandId;


SELECT
    cToyId AS "Id",
    vToyName AS "Name",
    vToyDescription as "Description",
    mToyRate as "Price",
    t.cBrandId as "BrandId",
    cBrandName as "BrandName"
FROM
    Toys t RIGHT OUTER JOIN ToyBrand tb
        ON t.cBrandId = tb.cBrandId;

SELECT
    cToyId AS "Id",
    vToyName AS "Name",
    vToyDescription as "Description",
    mToyRate as "Price",
    t.cBrandId as "BrandId",
    cBrandName as "BrandName"
FROM
    Toys t FULL OUTER JOIN ToyBrand tb
        ON t.cBrandId = tb.cBrandId;