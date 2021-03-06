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
select * from profile

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
Select * from reminder

DROP TABLE IF EXISTS Categories CASCADE;
CREATE TABLE IF NOT EXISTS Categories (
  ID SERIAL Primary key,
  Category varchar NOT NULL,
  Breed varchar NOT NULL,
  PhotoLink varchar NOT NULL
);

INSERT INTO Categories (Category, Breed, PhotoLink)
(VALUES
 ('Dog', 'Border-collie', 'jhvbjkvkj'),
 ( 'Cat', 'sfinks', 'jkbvjkbvk'),
 ('Bird', 'owl', 'fxcfghjk')
);
Select * from Categories

DROP TABLE IF EXISTS Information CASCADE;
CREATE TABLE IF NOT EXISTS Information (
  ID SERIAL Primary key,
  InGeneral varchar NOT NULL,
  Nutrition varchar NOT NULL,
  Care varchar NOT NULL,
  Health varchar NOT NULL,
  PhotoLink1 varchar,
  PhotoLink2 varchar,
  PhotoLink3 varchar,
  CategoriesID int REFERENCES Categories(ID) ON DELETE CASCADE
);


INSERT INTO Information (InGeneral, Nutrition, Care, Health, PhotoLink1, PhotoLink2, PhotoLink3, CategoriesID)
(VALUES
 ('DogBla', 'food1', 'love', 'Health1', 'irhwrioh', 'bebaetbaetn', 'erbebetb', 1),
 ('DogBlaa', 'food2', 'hug', 'Health2','etaetbebb', 'tbetbeber', 'sbttnb', 2),
 ( 'CatBla', 'milk', 'pet', 'Health3', 'erbr', 'erbree', 'aetberber', 3),
 ( 'CatBlaa', 'milk2', 'do not disturb', 'Health4', 'arerg', 'earbb', 'aergaerb', 1),
 ('BirdBla', 'mice', 'clean', 'Health5', 'erbeb', 'eberberb', 'aerberber', 2),
 ('BirdBlaa', 'mice2', 'listen', 'Health6', 'aererb', 'aergwrg', 'ergab', 3)
);
Select * from Information

DROP TABLE IF EXISTS Questions CASCADE;
CREATE TABLE IF NOT EXISTS Questions (
  ID SERIAL Primary key,
  Question varchar NOT NULL,
  QuestionType bool NOT NULL,
  PhotoLink varchar NOT NULL
);	


INSERT INTO Questions (Question, QuestionType, PhotoLink)
(VALUES
 ('Question1', true, 'jhvbjkvkj'),
 ( 'Question2', false, 'jkbvjkbvk'),
 ('Question3', false, 'fxcfghjk')
);
Select * from Questions

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
 ('m?', 0, 0, 0, 0, 0, 1),
 ('m2?', 0, 0, 0, 0, 0, 2),
 ('m3?',0, 0, 0, 0, 0, 3),
 ('m4?', 0, 0, 0, 0, 0, 1),
 ('m5?',0, 0, 0, 0, 0, 2),
 ('m6?',0, 0, 0, 0, 0, 1)
);
Select * from Answers

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
Select * from results
