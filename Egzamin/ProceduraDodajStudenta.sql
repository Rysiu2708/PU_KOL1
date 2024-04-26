CREATE PROCEDURE DodajStudenta
    @Imie NVARCHAR(max),
    @Nazwisko NVARCHAR(max),
    @GrupaId INT
AS
BEGIN
    INSERT INTO students(Imie, Nazwisko, GrupaId) VALUES (@Imie, @Nazwisko, @GrupaId); 
    INSERT INTO history(Imie, Nazwisko, GrupaId, HistoriakAkcji, Data) VALUES (@Imie, @Nazwisko, @GrupaId, 'Dodanie', CURRENT_TIMESTAMP)
END