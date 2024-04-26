CREATE PROCEDURE WyswietlHistorie
    @NumerStrony INT,
    @RozmiarStrony INT
AS
DECLARE @PierwszyRekord INT = (@NumerStrony - 1) * @RozmiarStrony + 1;

SELECT * FROM (
    SELECT
        *,
        ROW_NUMBER() OVER (ORDER BY Id) AS NumerWiersza
    FROM
        history
) AS NumerowaneWiersze
WHERE
    NumerWiersza >= @PierwszyRekord
    AND NumerWiersza < @PierwszyRekord + @RozmiarStrony