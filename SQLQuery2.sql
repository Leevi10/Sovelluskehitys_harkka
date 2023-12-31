CREATE TABLE käyttäjät (id INTEGER IDENTITY(1, 1) NOT NULL PRIMARY KEY, käyttäjätunnus VARCHAR(20));

CREATE TABLE käyttäjänreenit (id INTEGER IDENTITY(1,1) NOT NULL PRIMARY KEY, käyttäjä_id INTEGER FOREIGN KEY REFERENCES käyttäjät(ID), pvm VARCHAR(10));

CREATE TABLE harjoitukset (id INTEGER IDENTITY (1,1) NOT NULL PRIMARY KEY, liike VARCHAR(30));

CREATE TABLE reeni (id INTEGER IDENTITY (1,1) NOT NULL PRIMARY KEY, harjoitus_id INTEGER FOREIGN KEY REFERENCES harjoitukset(id), reeni_id INTEGER FOREIGN KEY REFERENCES käyttäjänreenit(id), toistomäärä INTEGER, paino INTEGER);

INSERT INTO Käyttäjät(käyttäjätunnus) VALUES ('Leevi');

INSERT INTO harjoitukset(liike) VALUES ('vinopenkki(smith)');

SELECT * FROM käyttäjät;

SELECT * FROM käyttäjänreenit;

SELECT * FROM harjoitukset;

SELECT * FROM reeni;

SELECT ti.id AS id, a.nimi AS asiakas, tu.nimi AS tuote, ti.toimitettu AS toimitettu FROM tilaukset ti, asiakkaat a, tuotteet tu WHERE a.id=ti.asiakas_id AND tu.id=ti.tuote_id;
SELECT re.id AS id, k.käyttäjätunnus AS käyttäjä, ha.liike AS liike, re.paino AS paino, re.toistomäärä AS toistot, kr.pvm AS pvm FROM reeni re, käyttäjät k, harjoitukset ha, käyttäjänreenit kr WHERE kr.id=re.reeni_id AND k.id=kr.käyttäjä_id AND ha.id=re.harjoitus_id;