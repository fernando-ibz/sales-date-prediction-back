USE [StoreSample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Sales].[usp_GetNextOrderPrediction]
    @custids VARCHAR(MAX) 
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OrderHistory TABLE (
        custid INT,
        orderdate DATE
    );

    DECLARE @DateDifferences TABLE (
        custid INT,
        DaysBetween INT
    );

    DECLARE @AverageDays TABLE (
        custid INT,
        AvgDaysBetween FLOAT
    );

    DECLARE @LastOrder TABLE (
        custid INT,
        LastOrderDate DATE
    );

    DECLARE @CustIdTable TABLE (custid INT);

    IF @custids IS NOT NULL AND LEN(@custids) > 0
    BEGIN
        INSERT INTO @CustIdTable (custid)
        SELECT value FROM STRING_SPLIT(@custids, ',');
    END

    IF NOT EXISTS (SELECT 1 FROM @CustIdTable)
    BEGIN
        INSERT INTO @OrderHistory (custid, orderdate)
        SELECT o.custid, o.orderdate
        FROM Sales.Orders o;
    END
    ELSE
    BEGIN
        INSERT INTO @OrderHistory (custid, orderdate)
        SELECT o.custid, o.orderdate
        FROM Sales.Orders o
        INNER JOIN @CustIdTable c ON o.custid = c.custid;
    END

    INSERT INTO @DateDifferences (custid, DaysBetween)
    SELECT
        custid,
        DATEDIFF(DAY,
            LAG(orderdate) OVER (PARTITION BY custid ORDER BY orderdate),
            orderdate
        )
    FROM @OrderHistory;

    INSERT INTO @AverageDays (custid, AvgDaysBetween)
    SELECT
        custid,
        AVG(CAST(DaysBetween AS FLOAT))
    FROM @DateDifferences
    WHERE DaysBetween IS NOT NULL
    GROUP BY custid;

    INSERT INTO @LastOrder (custid, LastOrderDate)
    SELECT
        custid,
        MAX(orderdate)
    FROM @OrderHistory
    GROUP BY custid;

    SELECT
        c.custid,
        c.companyname AS CustomerName,
        l.LastOrderDate,
        DATEADD(DAY, ISNULL(a.AvgDaysBetween, 0), l.LastOrderDate) AS NextPredictedOrder
    FROM Sales.Customers c
    INNER JOIN @LastOrder l ON c.custid = l.custid
    LEFT JOIN @AverageDays a ON c.custid = a.custid
    ORDER BY CustomerName;
END;
GO


