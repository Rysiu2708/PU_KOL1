Create TRIGGER DodajHistorie
ON students
after update
AS
BEGIN
  
     insert into history(Imie, Nazwisko, GrupaId, HistoriakAkcji, Data)
		select s.Imie, s.NAzwisko, s.GrupaId, 'Edycja', getdate() from inserted s
    
END;