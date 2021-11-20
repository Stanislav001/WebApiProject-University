# TotalError
 
Приложението се стартира всеки ден в избрано от мен време, за да проверява дали има добавени нови фаилове. Ако открие, че има нови непрочетени файлове ги прочита и ги записва в базата от данни. Приложението е направена така, че да добавя само записи, които не съществуват в базата от данни. Има няколко контролера, с които може да извличате информация за регионите или страните, както и за продажбите. 
 * В приложението има 5 модела:
    Region модел, който съдържа информацията за регионите;
    Country модел, който съдържа информация за държавите;
    Order модел, съдържащ информация за поръчките;
    Sales модел, който съдържа информация продажбите;
    LatestAdd модел, който записва в базата от данни името на последният файл, който сме прочели;
    
 * Приложението чете csv файловете, използвайки библиотеката CsvHelper. Стартира се в определено от мен време, използвайки библиотеката Quartz.
    
