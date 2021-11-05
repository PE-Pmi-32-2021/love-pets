drop TABLE Profile;
drop table Reminder;
drop table Categories;
drop TABLE Information;
drop table Questions;
drop table Answers;
drop table Results;














CREATE TABLE Profile (
  ID int IDENTITY(1,1) Primary key,
  ProfileFullname [NVARCHAR](500) NOT NULL,
  ProfileName [NVARCHAR](500) NOT NULL,
  Breed [NVARCHAR](500) NOT NULL,
  Coloring [NVARCHAR](500) NOT NULL,
  Gender bit NOT NULL,
  BirthDate date NOT NULL,
  Age int NOT NULL,
  Photolink [NVARCHAR](500) NOT NULL
);

DBCC CHECKIDENT (Profile, RESEED, 0);

INSERT INTO Profile ([ProfileFullname], [ProfileName], [Breed], [Coloring], [Gender], [BirthDate], [Age], [Photolink])
VALUES
 (N'Lolitta', N'Lolly', N'Border-collie', N'Black and white', 1,' 1/8/1999', 2, N'rvrvwrbvwrbvwwr');

select * from profile

update Profile set [Photolink]=N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/Photos/Other_snake.jpg';

delete from Profile;


CREATE TABLE Reminder (

  ID int IDENTITY(1,1) Primary key,
  EndTime datetime  NOT NULL,
  StartTime datetime  NOT NULL,
  Subject [NVARCHAR](500) NOT NULL,
  Location [NVARCHAR](500),
  Notes [NVARCHAR](500),
  IsRecursive bit, 
  RecurrenceRule [NVARCHAR](500),
  BackR int ,
  BackG int ,
  BackB int ,
  FrontR int ,
  FrontG int ,
  FrontB int 
);


 
Select * from reminder


CREATE TABLE Categories (
  ID int IDENTITY(1,1) Primary key,
  Category [NVARCHAR](500) NOT NULL,
  Breed [NVARCHAR](500) NOT NULL,
  PhotoLink [NVARCHAR](500) NOT NULL
);

INSERT INTO Categories ([Category], [Breed], [PhotoLink])
VALUES
 (N'Dog', N'Border-collie', N'jhvbjkvkj'),
 (N'Cat', N'sfinks', N'jkbvjkbvk'),
 (N'Bird', N'owl', N'fxcfghjk')
;
Select * from Categories
DROP TABLE Categories;

CREATE TABLE Information (
  ID int IDENTITY(1,1) Primary key,
  InGeneral [NVARCHAR](500) NOT NULL,
  Nutrition [NVARCHAR](500) NOT NULL,
  Care [NVARCHAR](500) NOT NULL,
  Health [NVARCHAR](500) NOT NULL,
  PhotoLink1 [NVARCHAR](500),
  PhotoLink2 [NVARCHAR](500),
  PhotoLink3 [NVARCHAR](500),
  CategoriesID int REFERENCES Categories(ID) ON DELETE CASCADE
);

DROP TABLE Information;

INSERT INTO Information ([InGeneral], [Nutrition], [Care], [Health], [PhotoLink1], [PhotoLink2], [PhotoLink3], [CategoriesID])
VALUES
 (N'DogBla', N'food1', N'love', N'Health1', N'irhwrioh', N'bebaetbaetn', N'erbebetb', 1)
;
Select * from Information


CREATE TABLE Questions (
  ID int IDENTITY(1,1) Primary key,
  Question [NVARCHAR](500) NOT NULL,
  QuestionType bit NOT NULL,
  PhotoLink [NVARCHAR](500) NOT NULL
);	


INSERT INTO Questions ([Question], [QuestionType], [PhotoLink])
VALUES
 (N'Question1', 1, N'jhvbjkvkj'),
 (N'Question2', 0, N'jkbvjkbvk'),
 (N'Question3', 0, N'fxcfghjk')
;
Select * from Questions


CREATE TABLE  Answers (
  ID int IDENTITY(1,1) Primary key,
  Answer [NVARCHAR](500) NOT NULL,
  Dogs int NOT NULL,
  Cats int NOT NULL,
  Rodents int NOT NULL,
  Reptiles int NOT NULL,
  Birds int NOT NULL,
  QuestionsID int REFERENCES Questions(ID) ON DELETE CASCADE
);


INSERT INTO Answers ([Answer], [Dogs], [Cats], [Rodents], [Reptiles], [Birds], [QuestionsID])
VALUES
 (N'm?', 0, 0, 0, 0, 0, 1),
 (N'm2?', 0, 0, 0, 0, 0, 2),
 (N'm3?',0, 0, 0, 0, 0, 3),
 (N'm4?', 0, 0, 0, 0, 0, 1),
 (N'm5?',0, 0, 0, 0, 0, 2),
 (N'm6?',0, 0, 0, 0, 0, 1);
Select * from Answers


CREATE TABLE  Results (
  ID int IDENTITY(1,1) Primary key,
  Paragraph1 [NVARCHAR](500),
  Paragraph2 [NVARCHAR](500),
  PhotoLink1 [NVARCHAR](500),
  PhotoLink2 [NVARCHAR](500),
  PhotoLink3 [NVARCHAR](500)
);

INSERT INTO Results ([Paragraph1], [Paragraph2], [PhotoLink1], [PhotoLink2], [PhotoLink3])
VALUES
 (N'1Paragraph1', N'1Paragraph2', N'1PhotoLink1', N'1PhotoLink2', N'1PhotoLink3'),
 (N'2Paragraph1', N'2Paragraph2', N'2PhotoLink1', N'2PhotoLink2', N'2PhotoLink3'),
 (N'3Paragraph1', N'3Paragraph2', N'3PhotoLink1', N'3PhotoLink2', N'3PhotoLink3')
;
Select * from results

