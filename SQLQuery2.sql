CREATE TABLE k‰ytt‰j‰t (id INTEGER IDENTITY(1, 1) NOT NULL PRIMARY KEY, k‰ytt‰j‰tunnus VARCHAR(20));

CREATE TABLE k‰ytt‰j‰nreenit (id INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY, k‰ytt‰j‰_id INTEGER FOREIGN KEY REFERENCES k‰ytt‰j‰t(ID), pvm VARCHAR(10));

CREATE TABLE harjoitukset (id INTEGER IDENTITY (1,1) NOT NULL PRIMARY KEY, liike VARCHAR(30));

CREATE TABLE reeni (id INTEGER IDENTITY (1,1) NOT NULL PRIMARY KEY, harjoitus_id INTEGER FOREIGN KEY REFERENCES harjoitukset(id), reeni_id INTEGER FOREIGN KEY REFERENCES k‰ytt‰j‰nreenit(id), toistom‰‰r‰ INTEGER, paino INTEGER);

INSERT INTO K‰ytt‰j‰t(k‰ytt‰j‰tunnus) VALUES ('Leevi');

INSERT INTO harjoitukset(liike) VALUES ('vinopenkki(smith)');

SELECT * FROM k‰ytt‰j‰t;

SELECT * FROM k‰ytt‰j‰nreenit;

SELECT * FROM harjoitukset;

SELECT * FROM reeni;

SELECT ti.id AS id, a.nimi AS asiakas, tu.nimi AS tuote, ti.toimitettu AS toimitettu FROM tilaukset ti, asiakkaat a, tuotteet tu WHERE a.id=ti.asiakas_id AND tu.id=ti.tuote_id;