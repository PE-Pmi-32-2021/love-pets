DROP TABLE IF EXISTS Profile CASCADE;
CREATE TABLE IF NOT EXISTS Profile (
  ID SERIAL Primary key,
  ProfileFullname varchar NOT NULL,
  ProfileName varchar NOT NULL,
  Breed varchar NOT NULL,
  Coloring varchar NOT NULL,
  Gender bool NOT NULL,
  BirthDate date NOT NULL,
  Age int NOT NULL,
  Photolink varchar NOT NULL
);

INSERT INTO Profile (ProfileFullname, ProfileName, Breed, Coloring, Gender, BirthDate, Age, Photolink)
(VALUES
 ('Lolitta', 'Lolly', 'Border-collie', 'Black and white', true,' 1/8/1999', 2, 'rvrvwrbvwrbvwwr'),
 ('Mikaella', 'Mikki', 'Maltese', 'white', true,' 2/4/2001', 10, 'jhvvkjb'),
 ('Dekster', 'Deks', 'taksa', 'black', false, '3/12/2004', 12, 'hbgjhvjhv')
);

CREATE DOMAIN remType AS text 
	CHECK (VALUE IN ('feeding','treatment','vet','birthday','other'));
DROP TABLE IF EXISTS Reminder CASCADE;
CREATE TABLE IF NOT EXISTS Reminder (
  ID SERIAL Primary key,
  RemindingDate timestamp NOT NULL,
  Reminding varchar NOT NULL,
  ReminderType remType,
  ProfileID int REFERENCES Profile(ID) ON DELETE CASCADE
);


INSERT INTO Reminder (RemindingDate, Reminding, ReminderType, ProfileID)
(VALUES
 ('2021-11-08 22:05:06', 'vet', 'feeding', 1),
 ('2021-12-09 23:05:06', 'eat', 'treatment', 2),
 ('2021-11-10 21:05:06', 'walk', 'other', 3),
 ('2021-10-18 20:05:06', 'clean', 'treatment', 1),
 ('2021-11-17 12:25:06', 'groomer', 'birthday', 3),
 ('2021-11-08 21:05:06', 'vet', 'vet', 2)
 );


INSERT INTO Questions (Question, QuestionType, PhotoLink)
(VALUES
 ('Question1', true, 'jhvbjkvkj'),
 ('Question2', false, 'jkbvjkbvk'),
 ('Question3', false, 'fxcfghjk')
);

DROP TABLE IF EXISTS Answers CASCADE;
CREATE TABLE IF NOT EXISTS Answers (
  ID SERIAL Primary key,
  Answer varchar NOT NULL,
  Dogs int NOT NULL,
  Cats int NOT NULL,
  Rodents int NOT NULL,
  Reptiles int NOT NULL,
  Birds int NOT NULL,
  QuestionsID int REFERENCES Questions(ID) ON DELETE CASCADE
);


INSERT INTO Answers (Answer, Dogs, Cats, Rodents, Reptiles, Birds, QuestionsID)
(VALUES
 ('Answer1', 0, 3, 0, 2, 0, 1),
 ('Answer2', 0, 0, 0, 5, 0, 1),
 ('Answer3',0, 1, 0, 0, 0, 1),
 ('Answer4', 0, 0, 2, 0, 0, 1),
 ('Answer5',1, 0, 0, 4, 0, 1)
);


DROP TABLE IF EXISTS Results CASCADE;
CREATE TABLE IF NOT EXISTS Results (
  ID SERIAL Primary key,
  Paragraph1 varchar,
  Paragraph2 varchar,
  PhotoLink1 varchar,
  PhotoLink2 varchar,
  PhotoLink3 varchar
);

INSERT INTO Results (Paragraph1, Paragraph2, PhotoLink1, PhotoLink2, PhotoLink3)
(VALUES
 ('1Paragraph1', '1Paragraph2', '1PhotoLink1', '1PhotoLink2', '1PhotoLink3'),
 ('2Paragraph1', '2Paragraph2', '2PhotoLink1', '2PhotoLink2', '2PhotoLink3'),
 ('3Paragraph1', '3Paragraph2', '3PhotoLink1', '3PhotoLink2', '3PhotoLink3')
);
