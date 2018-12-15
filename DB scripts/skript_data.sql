
INSERT INTO osoba VALUES(1,'Marek' , 'Klus', '1980/05/02', 'marek.klus@seynam.cz', 725558365, 0 )
INSERT INTO osoba VALUES(2,'Aleš' , 'Opatrný', '1990/06/19', 'opatrny@seynam.cz', 725558365, 1 )
INSERT INTO osoba VALUES(3,'Klára' , 'Dobøická', '1982/08/25', 'klarka@seynam.cz', 725558365, 0 )
INSERT INTO osoba VALUES(4,'Ivana' , 'Dostálová', '1981/07/23', 'iva.d@seynam.cz', 725558365, 3 )
INSERT INTO osoba VALUES(5,'Martin' , 'Vopršálek', '1973/02/11', 'voprsalek@seynam.cz', 725558365, 4 )
INSERT INTO osoba VALUES(6,'Bára' , 'Stará', '1969/09/30', 'stara.b@seynam.cz', 725558365, 5 )
INSERT INTO osoba VALUES(7,'Marcel' , 'Menšík', '1989/11/09', 'marcelm@seynam.cz', 725558365, 6 )
INSERT INTO osoba VALUES(8,'Ondra' , 'Kantor', '1974/04/10', 'kantor@seynam.cz', 725558365, 7 )
INSERT INTO osoba VALUES(9,'Martina' , 'Kralová', '1975/05/21', 'kralova@seynam.cz', 725558365, 8 )
INSERT INTO osoba VALUES(10,'Tomáš' , 'Bajnar', '1985/10/03', 'bajnar@seynam.cz', 725558365, 2 )

INSERT INTO staj VALUES(1,'NewPort', 5 ,'725564326', 'heslo1', 4)
INSERT INTO staj VALUES(2,'JK Baník Ostrava',7,'596325468', 'heslo2', 6)
INSERT INTO staj VALUES(3,'Equicentrum Olomouc',1,'608536213', 'heslo3', 10)
INSERT INTO staj VALUES(4,'Stáj Mustang',3,'728896352', 'heslo4', 8)
INSERT INTO staj VALUES(5,'JK Opava Kateøinky',10,'726543659', 'heslo5', 2)



INSERT INTO JEZDEC VALUES('KLU0001',1,'1', 1, 'heslo' )
INSERT INTO JEZDEC VALUES('DOB0001',1,'1', 3, 'heslo' )
INSERT INTO JEZDEC VALUES('VOP0001',1,'1', 5 , 'heslo')
INSERT INTO JEZDEC VALUES('DOS0001',2,'1', 4 , 'heslo')
INSERT INTO JEZDEC VALUES('KAN0001',2,'0', 8 , 'heslo')
INSERT INTO JEZDEC VALUES('KRA0001',3,'1', 9 , 'heslo')
INSERT INTO JEZDEC VALUES('BAJ0001',3,'1', 10 , 'heslo')
INSERT INTO JEZDEC VALUES('MEN0001',3,'1', 7 , 'heslo')


INSERT INTO kun (cislo_licence, sid, jmeno, majitel, licence) VALUES('TAR0002', 2, 'Tara', 2, '0')
INSERT INTO kun (cislo_licence, sid, jmeno,plemeno, majitel, licence) VALUES('MAG0035', 2, 'Magelan','Shetlandský pony', 2, '1')
INSERT INTO kun VALUES ('NAO0105', 3, 'Naome del Heribus', 'KWPN', '2001/04/17', 3, '1')
INSERT INTO kun VALUES ('GOL0005', 3, 'Goldy 2', 'ÈT', '2004/04/24', 6, '1')
INSERT INTO kun VALUES ('LEO0234', 3, 'Leonardo', 'ST', '2003/05/03', 7, '1')
INSERT INTO kun VALUES ('CAM0024', 3, 'Camaro', 'ÈT', '2010/04/03', 3, '1')
INSERT INTO kun VALUES ('GWE0003', 2, 'Gwen', 'KWPN', '2008/04/15', 2, '1')
INSERT INTO kun VALUES ('HAS0003', 4, 'Hasan', 'Starokladrubský Kùò', '2013/04/08', 2, '1')
INSERT INTO kun VALUES ('REZ0245', 1, 'Reznak', 'ÈT', '2010/04/10', 3, '1')
INSERT INTO kun VALUES ('KAI0200', 2, 'Kaira', 'KWPN', '2009/04/25', 4, '1')
INSERT INTO kun VALUES ('LAC2014', 1, 'Lacaros', 'Paint Horse', '2012/03/29', 8, '1')
INSERT INTO kun VALUES ('NES0360', 2, 'Nesquik', 'KWPN', '2010/04/17', 8, '1')
INSERT INTO kun VALUES ('DRA0047', 5, 'Drak', 'Starokladrubský Kùò', '2014/05/25', 7, '0')
INSERT INTO kun VALUES ('ASS1003', 5, 'Assissi', 'Oldenburský kùò', '2015/04/15', 3, '1')
INSERT INTO kun VALUES ('LEE0325', 5, 'Lee Diamond', 'ÈT', '2015/04/25', 3, '1')
INSERT INTO kun VALUES ('STA1245', 1, 'Stan', 'Starokladrubský Kùò', '2012/04/10', 5, '1')
INSERT INTO kun VALUES ('JOK0362', 1, 'Joker', 'Paint Horse', '2007/03/10', 4, '1')
INSERT INTO kun VALUES ('CEL3021', 5, 'Celebrita', 'ÈT', '2005/04/24', 3, '1')

INSERT INTO zavody VALUES (1, 2, '2019/06/15')
INSERT INTO zavody VALUES (5, 5, '2019/06/25')
INSERT INTO zavody VALUES (2, 3, '2019/07/20')
INSERT INTO zavody VALUES (3, 4, '2019/08/03')
INSERT INTO zavody VALUES (4, 3, '2019/09/30')
INSERT INTO zavody VALUES (6, 3, '2018/12/30')
INSERT INTO zavody VALUES (7, 4, '2018/12/10')
INSERT INTO zavody VALUES (8, 4, '2018/09/8')


INSERT INTO dvojice VALUES(1, 'KLU0001', 'NAO0105')
INSERT INTO dvojice VALUES(2, 'VOP0001', 'CEL3021')
INSERT INTO dvojice VALUES(3, 'KRA0001', 'JOK0362')
INSERT INTO dvojice VALUES(4, 'BAJ0001', 'LEO0234')
INSERT INTO dvojice VALUES(5, 'VOP0001', 'HAS0003')
INSERT INTO dvojice VALUES(6, 'KLU0001', 'KAI0200')
INSERT INTO dvojice VALUES(7, 'KLU0001', 'LEO0234')
INSERT INTO dvojice VALUES(8, 'KLU0001', 'GWE0003')
INSERT INTO dvojice VALUES(9, 'KRA0001', 'KAI0200')
INSERT INTO dvojice VALUES(10, 'BAJ0001', 'NAO0105')
INSERT INTO dvojice VALUES(11, 'DOB0001', 'KAI0200')
INSERT INTO dvojice VALUES(12, 'MEN0001', 'REZ0245')
INSERT INTO dvojice VALUES(13, 'DOS0001', 'GOL0005')
INSERT INTO dvojice VALUES(14, 'DOS0001', 'CAM0024')
INSERT INTO dvojice VALUES(15, 'KLU0001', 'NES0360')
INSERT INTO dvojice VALUES(16, 'BAJ0001', 'ASS1003')
INSERT INTO dvojice VALUES(17, 'MEN0001', 'JOK0362')
INSERT INTO dvojice VALUES(18, 'MEN0001', 'LEE0325')
INSERT INTO dvojice VALUES(19, 'DOB0001', 'LAC2014')
INSERT INTO dvojice VALUES(20, 'KLU0001','REZ0245')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(1,1, 'ZL', '00:01:02.3100000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(2,1, 'L*', '00:00:56.4500000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(3,1, 'S**', '00:01:20.3000000' )

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(4,  2, 'S**', '00:00:59.5900000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(5, 2, 'L*', '00:00:59.4800000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(6, 3, 'ZM', '00:01:12.1300000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(7, 3, 'Z', '00:00:56.1300000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(8, 4, 'ZL', '00:01:05.2100000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(9, 4, 'S*', '00:00:58.3100000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(10, 5, 'S*', '00:01:10.0100000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(11, 5, 'ST*', '00:01:02.8100000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(12, 5, 'T**', '00:01:12.1500000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(13, 6, 'L*', '00:01:12.0000000')

INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(14, 6, 'S**', '00:01:00.00000')
INSERT INTO soutez (cid, zid, obtiznost, limit) VALUES(16, 8, 'S**', '00:01:00.00000')



/*
execute dbo.PridejVysledek 1, 1,'00:01:02.3100000', 2, '0' 
execute dbo.PridejVysledek 2, 1,'00:01:10.0000000', 0, '0' 
execute dbo.PridejVysledek 3, 1,'00:01:00.2800000', 1, '0' 
execute dbo.PridejVysledek 5, 2, '00:00:56.4500000', 3, '0' 
execute dbo.PridejVysledek 7, 2,  '00:01:00.3500000', 0, '0' 
execute dbo.PridejVysledek 8, 2,  '00:01:02.3100000', 0, '0' 
execute dbo.PridejVysledek 9, 3,  '00:01:20.3000000', 2, '0' 
execute dbo.PridejVysledek 10,3, '00:01:15.0000000', 3, '0' 
execute dbo.PridejVysledek 13, 3,  '00:01:25.3200000', 1, '0' 
execute dbo.PridejVysledek 16, 3,  '00:01:15.3800000', 2, '0' 
execute dbo.PridejVysledek  17, 3, '00:01:30.3200000', 0, '0' 
execute dbo.PridejVysledek  18, 3,  '00:01:02.3100000', 0, '0' 
INSERT INTO vysledek ( did, cid,  vyloucen ) VALUES(4, 3,  '1' )

execute dbo.PridejVysledek 2, 4, '00:00:59.5900000', 0, '0'
execute dbo.PridejVysledek  3, 4,  '00:01:00.0300000', 1, '0'
execute dbo.PridejVysledek  5, 4, '00:00:58.0100000', 2, '0'
execute dbo.PridejVysledek  6, 4, '00:01:03.2100000', 1, '0'
execute dbo.PridejVysledek  7, 4, '00:00:56.8200000', 0, '0'
INSERT INTO vysledek (did, cid, vyloucen) VALUES( 15, 4,  '1' )
execute dbo.PridejVysledek  8, 5,  '00:00:59.4800000', 2, '0'
execute dbo.PridejVysledek  10, 5, '00:01:05.5900000', 2, '0'
execute dbo.PridejVysledek  11, 5, '00:01:01.0200000', 0, '0'
execute dbo.PridejVysledek  13, 5, '00:00:59.5800000', 0, '0'
execute dbo.PridejVysledek  20, 5, '00:00:58.3100000', 0, '0'

execute dbo.PridejVysledek  19, 6, '00:01:12.1300000', 6, '0'
execute dbo.PridejVysledek  17, 6, '00:01:05.2600000', 0, '0'
execute dbo.PridejVysledek  10, 6,  '00:01:00.8100000', 1, '0'
execute dbo.PridejVysledek  9, 6,  '00:01:01.1000000', 0, '0'
execute dbo.PridejVysledek  8, 6,  '00:01:10.0000000', 0, '0'
execute dbo.PridejVysledek  5, 7,  '00:00:56.1300000', 6, '0'
execute dbo.PridejVysledek  7, 7,  '00:00:59.2600000', 0, '0'
execute dbo.PridejVysledek  4, 7,  '00:00:58.8100000', 1, '0'
execute dbo.PridejVysledek  2, 7, '00:00:57.1000000', 0, '0'
execute dbo.PridejVysledek  1, 7,  '00:01:01.0000000', 0, '0'

execute dbo.PridejVysledek  3, 8,  '00:01:05.2100000', 0, '0'
execute dbo.PridejVysledek  4, 8,  '00:01:10.0100000', 0, '0'
execute dbo.PridejVysledek  6, 8,  '00:00:59.4800000', 1, '0'
execute dbo.PridejVysledek  2, 8,  '00:01:00.1500000', 0, '0'
execute dbo.PridejVysledek  1, 8,  '00:01:03.1800000', 0, '0'
execute dbo.PridejVysledek  10, 8,  '00:00:59.9100000', 2, '0'
execute dbo.PridejVysledek  8, 8, '00:01:11.3100000', 0, '0'
execute dbo.PridejVysledek  9, 9,  '00:00:58.3100000', 1, '0'
execute dbo.PridejVysledek  7, 9, '00:01:01.6800000', 0, '0'
execute dbo.PridejVysledek  11, 9, '00:01:08.0000000', 0, '0'
execute dbo.PridejVysledek  13, 9,  '00:00:59.9900000', 1, '0'
execute dbo.PridejVysledek  15, 9,  '00:01:00.0100000', 2, '0'
execute dbo.PridejVysledek  17, 9,  '00:01:04.1400000', 0, '0'
execute dbo.PridejVysledek  18, 9,  '00:01:10.2600000', 3, '0'
INSERT INTO vysledek ( did, cid, vyloucen ) VALUES(5, 9, '1' )

execute dbo.PridejVysledek  3, 10,  '00:01:10.0100000', 0, '0'
execute dbo.PridejVysledek  4, 10,  '00:01:02.0000000', 1, '0'
execute dbo.PridejVysledek  7, 10,  '00:01:13.2500000', 0, '0'
execute dbo.PridejVysledek  9, 10,  '00:01:25.0000000', 0, '0'
execute dbo.PridejVysledek  13, 10,  '00:00:59.8100000', 2, '0'
execute dbo.PridejVysledek  18, 11,  '00:01:02.8100000', 0, '0'
execute dbo.PridejVysledek  10, 11,  '00:00:57.0200000', 0, '0'
execute dbo.PridejVysledek  11, 11,  '00:00:56.0100000', 0, '0'
execute dbo.PridejVysledek  1, 11,  '00:01:11.1100000', 1, '0'
execute dbo.PridejVysledek  8, 11,  '00:00:55.1200000', 0, '0'
execute dbo.PridejVysledek  12, 12,  '00:01:12.1500000', 2, '0'
execute dbo.PridejVysledek  14, 12, '00:01:14.1500000', 0, '0'
execute dbo.PridejVysledek  15, 12, '00:01:20.0000000', 0, '0'
execute dbo.PridejVysledek  16, 12, '00:01:35.2400000', 1, '0'
execute dbo.PridejVysledek  17, 12,  '00:01:05.3400000', 1, '0'
execute dbo.PridejVysledek  2, 12,  '00:01:00.8400000', 0, '0'
execute dbo.PridejVysledek  5, 12, '00:01:03.7500000', 0, '0'*/

INSERT INTO vysledek (did, cid) VALUES( 10, 13)
INSERT INTO vysledek (did, cid) VALUES( 5, 14)
INSERT INTO vysledek (did, cid) VALUES( 8, 13)
INSERT INTO vysledek (did, cid) VALUES( 18, 13)









