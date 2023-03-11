DELETE FROM BS.Afwezigheid
DELETE FROM BS.DocentRichting
DELETE FROM BS.Richting
DELETE FROM BS.Gebruiker
DELETE FROM BS.Rol

-- Reset id's naar 0
DBCC CHECKIDENT ('BS.Afwezigheid', RESEED, 0)
DBCC CHECKIDENT ('BS.DocentRichting', RESEED, 0)
DBCC CHECKIDENT ('BS.Richting', RESEED, 0)
DBCC CHECKIDENT ('BS.Rol', RESEED, 0)

-- Insert rollen
INSERT INTO BS.Rol (Naam)
VALUES ('Admin')
INSERT INTO BS.Rol (Naam)
VALUES ('Docent')

-- Insert gebruikers
INSERT INTO BS.Gebruiker (Rnummer, Voornaam, Achternaam, Email, RolId)
VALUES ('r0455572', 'Gilles', 'Lagrillière', 'gilles.lagrilliere@gmail.com', 1)
INSERT INTO BS.Gebruiker (Rnummer, Voornaam, Achternaam, Email, [Status], RolId)
VALUES ('r2698657', 'Bert', 'Jansens', 'bert.jansens@gmail.com', 1, 2)
INSERT INTO BS.Gebruiker (Rnummer, Voornaam, Achternaam, Email, [Status], RolId)
VALUES ('r6988548', 'Jan', 'Peeters', 'jan.peeters@gmail.com', 0, 2)

-- Insert richtingen
INSERT INTO BS.Richting (Naam)
VALUES ('graduaat programmeren')
INSERT INTO BS.Richting (Naam)
VALUES ('graduaat netwerken')
INSERT INTO BS.Richting (Naam)
VALUES ('bachelor verpleegkunde')

-- Insert docentRichtingen
INSERT INTO BS.DocentRichting (Rnummer, RichtingId)
VALUES ('r0455572', 1)
INSERT INTO BS.DocentRichting (Rnummer, RichtingId)
VALUES ('r0455572', 2)
INSERT INTO BS.DocentRichting (Rnummer, RichtingId)
VALUES ('r2698657', 3)
INSERT INTO BS.DocentRichting (Rnummer, RichtingId)
VALUES ('r6988548', 3)

-- Insert afwezigheden
INSERT INTO BS.Afwezigheid (Rnummer, Begindatum, Einddatum)
VALUES ('r0455572', '20230324 00:00:00', '20230401 00:00:00')
INSERT INTO BS.Afwezigheid (Rnummer, Begindatum, Einddatum)
VALUES ('r0455572', '20230624 00:00:00', '20230701 00:00:00')
INSERT INTO BS.Afwezigheid (Rnummer, Begindatum, Einddatum)
VALUES ('r2698657', '20230315 00:00:00', '20230320 00:00:00')
INSERT INTO BS.Afwezigheid (Rnummer, Begindatum, Einddatum)
VALUES ('r6988548', '20230315 00:00:00', '20230318 00:00:00')