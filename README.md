# За приложението
 
Приложението се стартира всеки ден в избрано от мен време, за да проверява дали има добавени нови фаилове. Ако открие, че има нови непрочетени файлове ги прочита и ги записва в базата от данни. Важно е да се отбележе, че приложението чете само файлове във csv формат. Приложението е направена така, че да добавя само записи, които не съществуват в базата от данни. Има няколко контролера, с които може да извличате информация за регионите или страните, както и за продажбите. 


# Конфигурация  
 * В приложението има 5 модела: <br/>
    Region модел, който съдържа информацията за регионите;<br/>
    Country модел, който съдържа информация за държавите;<br/>
    Order модел, съдържащ информация за поръчките;<br/>
    Sales модел, който съдържа информация продажбите;<br/>
    LatestAdd модел, който записва в базата от данни името на последният файл, който сме прочели;<br/>
    
 * Приложението има 3 контролера:<br/>
    IdentityController , чрез него потребителите могат да се регистрират или да влязат в профила си. <br/>
    CountryConroller, който дава информация за компаниите.<br/>
    RegionController Ви информира за регионите, за някои от методите е зададен атрибута [Authorize], което означава, че потребителят трябва да е влязал в профила си.<br/>
    
 * Цялата логика на контролерите и четенето на данни е изнесена с services, който са регистрирани в StartUp класът на приложението.
   
 * Приложението чете csv файловете, използвайки библиотеката CsvHelper. Стартира се в определено от мен време, използвайки библиотеката Quartz.

# Как да стартирате приложението на вашето устройство?
 * Първо трябва да промените пътя на папката, която искате да прочетете. Може да го направите като отидете в асемблито на Services, от там изберете папката Common и в класа DirectoryString да промените пътя.
 * Трябва да промените връзката с SQL сървъра. Можете да направите това като отидете в асемблито Date и изберете класът ApplicationDbContext. В методът OnConfiguring трябва да промените името на Server-а. Препоръчително е да изтриете папката с миграции и да направите нови такива след като свържете приложението с вашият SQL сървър.
 * Ако искате да промените часът, в който приложението ще се стартира, за да провери дали има нови непрочетени файлове в директорията, трябва да отидете в класа Startup, откъде да промените часът, в който да се изпълнява Quartz.
    
# Съдържание
 * Models -> В това assembly са всички модели, всеки модел в приложението наследява BaseModel
 * Date -> Връзката с БД
 * Services -> В това assembly съм сложил VM(view models), дефинирал съм няколко Exception-a, тук слагам и всички константи, които използвам в приложението. Тук е дефинирана и голяма част от функциалността на приложението. 
 * TestApp -> Конзолно приложение, което прави заявки към API-то, чрез него тествам дали заявките работят
 * UniProject.Test -> Няколко теста, които са за четенето на файлове
 * AppServer -> Тук са дефинирани контролерите и е сетнат е Quartz
