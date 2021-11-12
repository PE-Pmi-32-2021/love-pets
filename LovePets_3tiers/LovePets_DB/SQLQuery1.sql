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

delete from Profile where ID > 1;
DBCC CHECKIDENT (Profile, RESEED, 0);

INSERT INTO Profile ([ProfileFullname], [ProfileName], [Breed], [Coloring], [Gender], [BirthDate], [Age], [Photolink])
VALUES
 (N'Lolitta', N'Lolly', N'Border-collie', N'Black and white', 1,' 1/8/1999', 2, N'rvrvwrbvwrbvwwr');

select * from profile

update Profile set [Photolink]=N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/Photos/Other_snake.jpg';

delete from Profile;
DBCC CHECKIDENT (Profile, RESEED, 0);


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


delete from reminder;
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
 (N'Чи готовий(-а) ти прибирати за своїм улюбленцем?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/1.png'),
 (N'Який в тебе досвід спілкування з тваринами?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/2.jpg'),
 (N'Яку підготовку ти готовий(-а) пройти?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/3.jpeg'),
 (N'Яку кількість вільного простору ти можеш виділити?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/4.jpg'),
 (N'Як багато часу ти зможеш приділити улюбленцю?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/5.jpg'),
 (N'Як часто ти залишаєш дім на декілька днів/тижнів ?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/6.jpg'),
 (N'Чи готовий(-а) ти брати тваринку зі собою, коли покидаєш дім більше ніж на добу?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/7.jpg'),
 (N'Скільки коштів ви готові витратити на утримування тваринки?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/8.jpg'),
 (N'Твоє ставлення до шуму?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/9.jpg'),
 (N'Чи важливо тобі отримувати віддачу від улюбленця?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/10.jpg'),
 (N'Чи готовий(-а) ти до активних прогулянок мінімум двічі на день зі своїм улюбленцем?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/11.jpg'),
 (N'Якого розміру ти хочеш мати улюбленця?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/12.jpg'),
 (N'Чи маєш ти або хтось вдома алергію на шерсть?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/13.jpg'),
 (N'Чи є в тебе вдома маленькі діти?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/14.jpg'),
 (N'Підходяща для тебе середня тривалість життя тваринки', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/15.jpg'),
 (N'Для тебе ділитися своєю їжею з тваринкою', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/16.jpg'),
 (N'Чи є в тебе вже є улюбленець (-нці)?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/17.jpg'),
 (N'Тваринка для вас - ', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/18.jpg'),
 (N'Як ти відносишся до шерсті, яка може бути у будь-яких ( навіть в найбільш неочікуваних) місцях', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/19.jpg'),
 (N'Чи зможеш ти завести кілька тваринок, якщо вони потребують пари?', 0, N'C:/love-pets/love-pets/LovePets_3tiers/LovePets_UI/love_petsPhoto/20.jpg')
;

delete from Questions;
DBCC CHECKIDENT (Questions, RESEED, 0);


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
 (N'Завжди готовий(-а)!', 1, 1, 1, 1, 1, 1),
 (N'Готовий(-а) по мірі можливостей', 0, 1, 1, 1, 0, 1),
 (N'Краще щоб роботи було мінімально', 0, 0, 0, 1, 0, 1),

 (N'Я ніколи не мав(-ла) тваринки', 1, 1, 0, 0, 0, 2),
 (N'Мав(-ла) улюбленця в дитинстві', 1, 1, 1, 0, 0, 2),
 (N'Я досвідчений власник домашнього зоопарку', 1, 1, 1, 1, 1, 2),

 (N'Мінімальне вкладення часу і зусиль',0, 0, 1, 0, 0, 3),
 (N'Мене не лякають тваринки, які будуть потребувати додаткового дресирування',1, 1, 1, 1, 1, 3),
 (N'Я можу приборкати навіть дикого звіра',0, 0, 0, 1, 0, 3),

 (N'Я знайду куточок для улюбленця', 0, 0, 1, 1, 1, 4),
 (N'Маю квартиру', 0, 1, 1, 1, 1, 4),
 (N'В мене будинок та велике подвіря, тваринці буде виділено багато місця', 1, 1, 1, 1, 1, 4),

 (N'Я працюю(вчуся), вдома буваю тільки ввечері(1-2 год/день)', 0, 0, 0, 1, 0, 5),
 (N'Я маю вільний графік, та можу довше часу проводити з моїм меншим другом (2-4 год/день)', 0, 1, 0, 1, 0, 5),
 (N'Я майже завжди вдома і з задоволенням приділятиму багато уваги улюбленцю (більше 4 год/день)', 1, 1, 1, 1, 1, 5),
 (N'Маю цілодобову підтримку родини вдома', 1, 1, 1, 1, 1, 5),

 (N'Взагалі не залишаю дім', 1, 1, 1, 1, 1, 6),
 (N'Декілька разів на місяць', 0, 0, 0, 1, 0, 6),
 (N'Декілька разів на рік', 0, 0, 0, 1, 0, 6),
 (N'Декілька разів на рік буваю вдома', 0, 0, 0, 0, 0, 6),
  
 (N'Так, куди я туди і вона, ми будемо як нерозлийвода', 1, 1, 0, 0, 0, 7),
 (N'Не завжди буде така можливість', 0, 1, 0, 1, 1, 7),
 (N'Ніяк не зможу взяти(', 0, 0, 0, 1, 0, 7),

 (N'Мінімально', 0, 0, 0, 1, 1, 8),
 (N'Скільки потрібно', 1, 1, 1, 1, 1, 8),
 (N'Буде як "Галя-балувана"', 0, 0, 0, 0, 0, 8),

 (N'Взагалі не витримую шум', 0, 0, 0, 1, 0, 9),
 (N'Нейтральне, проте не люблю надмірного галасу', 0, 1, 0, 1, 0, 9),
 (N'Абсолютно не заважає шум', 1, 1, 1, 1, 1, 9),
 (N'Шум! Це ж моє друге імя!', 1, 1, 1, 0, 1, 9),

 (N'Дуже важливо, саме так я отримую позитивні емоції', 1, 1, 0, 0, 0, 10),
 (N'Не дуже важливо, проте люблю проводити час з тваринкою', 1, 1, 1, 0, 1, 10),
 (N'Зовсім не важливо, просто цікаво спостерігати за нею', 0, 0, 1, 1, 1, 10),

 (N'Звичайно!', 1, 0, 0, 0, 0, 11),
 (N'Нууу, швидше "так" ніж "ні"', 1, 0, 0, 0, 0, 11),
 (N'А можна щось менш активне?', 0, 1, 1, 1, 1, 11),

 (N'Малесенького (до 2 кг)', 0, 0, 1, 0, 1, 12),
 (N'Маленького (2 - 10 кг)', 1, 1, 0, 1, 0, 12),
 (N'Середнього (10-30 кг)', 1, 1, 0, 1, 0, 12),
 (N'Великого (30-50 кг)', 1, 0, 0, 1, 0, 12),
 (N'Гігантського (більше 50 кг)', 1, 0, 0, 1, 0, 12),

 (N'Так', 0, 0, 0, 1, 1, 13),
 (N'Ні', 1, 1, 1, 1, 1, 13),

 (N'Так, моя тваринка має ладнати з дітьми та не зачіпати їх', 0, 0, 1, 0, 0, 14),
 (N'Ні, діток немає', 1, 1, 1, 1, 1, 14),

 (N'до 3-х років', 0, 0, 1, 0, 0, 15),
 (N'3 - 10 рокiв', 0, 0, 0, 0, 1, 15),
 (N'10 - 20 років', 1, 1, 0, 1, 0, 15),
 (N'більше 20', 0, 0, 0, 1, 0, 15),

 (N'Нормально, поділюся шматочком', 1, 1, 0, 0, 0, 16),
 (N'Моя їжа = моя їжа', 0, 0, 1, 1, 1, 16),
 (N'Я на дієті, з радістю віддам свою порцію', 1, 1, 0, 0, 0, 16),
 (N'Чого це я маю ділитися? Хай вона зі мною ділиться', 1, 1, 0, 0, 0, 16),

 (N'Так', 0, 0, 0, 0, 0, 17),
 (N'Ні', 0, 0, 0, 0, 0, 17),

 (N'Для душі, буде моїм другом', 1, 1, 0, 0, 0, 18),
 (N'Для охорони', 1, 0, 0, 0, 0, 18),
 (N'Похизуватися перед друзями', 0, 0, 0, 1, 0, 18),
 (N'Щоб прикрасити інтерєр', 0, 0, 0, 1, 1, 18),

 (N'Не уявляю життя без неї', 1, 1, 0, 0, 0, 19),
 (N'Нейтрально', 1, 1, 1, 1, 1, 19),
 (N'Фу! Фу! ФУУ!!!', 0, 0, 0, 1, 1, 19),

 (N'Так, в потрібній кількості', 0, 0, 1, 0, 1, 20),
 (N'Так, але максимум ще одного', 0, 0, 0, 0, 1, 20),
 (N'Ні, я і на цю ледве наважуюсь', 1, 1, 0, 1, 0, 20);


Select * from Answers


delete from Answers;
DBCC CHECKIDENT (Answers, RESEED, 0);


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
 (N'Собака — друг людини. Стара, але дуже точна і мудра фраза. Але принісши в будинок цуценя, ви по суті заводите ще одну дитину. Адже собака має потребу у величезній увазі, це і щеплення, і прогулянки, і годування, і дресирування, і купання. Тому, вибравши собаку підходящої породи, відразу ж готуйте дитину до того, що догляд за твариною буде її обовязком.', N'Про собаку мріють багато, але не всі її заводять. Чому? Вся справа в тому, що цей вихованець вимагає від людини повної самовіддачі і уваги. З собакою потрібно не тільки грати, гуляти на вулиці, просто доглядати за нею, але і правильно виховувати, дресирувати. Собака по типу характеру підійде людині активного, сильного духом, не ледачому.', N'Вітаємо! Ваша тваринка - собака!', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Собака1.jpg', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Собака2.jpg'),
 (N'Якщо ви спокійна людина, після роботи хочете проводити вільний час вдома і лише трохи готові грати з вихованцем, тоді вам може підійти кішка - один з найбільш самостійних і незалежних видів домашніх тварин.  Це вихованець, який здатний подарувати масу приємний емоцій, але в той же час кішки ненав`язливі і не вимагають багато уваги і часу. Однак все ж враховуйте породу, так як всі вони відрізняються і за характером, і за особливостями догляду.', N'Майже все, що потрібно більшості домашніх котів – це їжа, вода і чистий лоток. Тим не менш, багато хто з них не проти пограти з пухнастою іграшкою або поганяти по квартирі м*ячик. Основна проблема щодо кішок – велика кількість шерсті та подряпані м*які меблі. Але це вирішується регулярними вичісуваннями, стрижкою пазурів і купівлею когтеточки. В цілому кішки найоптимальніші домашні вихованці для квартири.', N'Вітаємо! Ваша тваринка - кіт!', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Кіт1.jpg', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Кіт2.jpg'),
 (N'Гризуни не вимагають особливого догляду, достатньо лише годувати два рази в день і чистити клітку декілька разів в тиждень. Можливо, розведення дрібних звірів стане тренуванням до того, щоб завести більш серйозну тварину.Серед величезної кількості видів домашніх гризунів практично кожен може підібрати для себе підходящого вихованця. ', N'Якщо хочете більше часу приділяти звірятку, гуляти з нею на вулиці, причісувати і більше спілкуватися, тоді заведіть морську свинку, кролика або тхора. Якщо хочете просто за кимось доглядати, придбайте хом`ячка, шиншилу, щурики. Гризуни підходять людям спокійним, не агресивним, ласкавим. А також це ідеальний перший вихованець для дітей.', N'Вітаємо! Ваша тваринка - гризун!', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Гризун1.jpg', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Гризун2.jpg'),
  (N'Сьогодні все частіше можна зустріти рептилій в числі домашніх улюбленців. Хоча процент власників цих екзотичних тварин дуже маленький 3-5%, проте з кожним роком він росте. Утримувати таких тварин в домашніх умовах почали ще пару десятків років тому. Вже давно нікого не здивуєш таким видом домашніх улюбленців, вони викликають відчуття страху та настороженого інтересу одночасно. В сучасних любителів екзотичних домашніх тварин можна зустріти ящірки, хамелеони, змій, черепах та навіть крокодилів.', N'Якщо ви вирішили завести рептилію вам необхідно знати, що їм потрібна увага та турбота, хоча деякі види не привередливі і за ними не потрібний пристальний догляд, вони можуть проживати в різних температурних  діапазонах, та в різних вологових інтервалах, через це вони більш витривалі та життєстійкі. Важливим фактором є розмір тварини: маленьких чи середніх розмірів легше утримувати. Більшість видів вважаються легкими в утриманні, мають хороший апетит та легко розмножуються в неволі.', N'Вітаємо! Ваша тваринка - рептилія!', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Рептилія1.jpg', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Рептилія2.jpg'),
   (N'Птахи - відмінний вибір для кожного. Красива, яскрава активна пташка приверне увагу і підніме настрій.  За цими улюбленцями потрібен відповідальний догляд і знання особливостей різних видів, але в основному вони невибагливі і займають мало місця. Деякі види можна навчити повторювати якісь слова. Проте будьте готові до шуму і раннього підйому, так як пташки в більшості своїй прокидаються дуже рано.', N'Пам*ятайте: вирішивши придбати птаха, ви берете на себе відповідальність за самого дрібного члена вашої родини, який при правильному догляді та годуванні може прожити з вами не один десяток років. Щоб вдало обрати домашнього птаха потрібно попередньо ознайомитися з його видовими особливостями та умовами утримання. Пам*ятайте, що чи більший птах - тим більше потрібно ресурсів для його утримання.', N'Вітаємо! Ваша тваринка - папуга!', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Птах1.jpg', N'C:\love-pets\love-pets\LovePets_3tiers\LovePets_UI\Photos\Птах2.jpg')
;
Select * from results

delete from results;
DBCC CHECKIDENT (results, RESEED, 0);

