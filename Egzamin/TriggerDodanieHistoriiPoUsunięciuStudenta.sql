CREATE TRIGGER DodajHistoriePoUsunieciu
ON students
after delete
AS
BEGIN

   
        insert into history(Imie, Nazwisko, GrupaId, HistoriakAkcji, Data)
		select s.Imie, s.Nazwisko, s.GrupaId, 'Usuniecie', getdate() from deleted s
   
END;