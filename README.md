# TaskSite
Для работы приложения необходимо иметь установленную СУБД PostgreSQL 
(для ОС Windows доступна на сайте https://www.enterprisedb.com/downloads/postgres-postgresql-downloads) и Visual Studio (желательно 2019)
При установке СУБД оставить имя пользователя postgres, пароль 123, чтобы не изменять конфигурационные файлы

После установки СУБД следует создать новую базу данных с именем tasksite
https://drive.google.com/file/d/14SDtIYtpdS98fCcc0j3ki8urj-H7vRV_/view?usp=sharing
https://drive.google.com/open?id=1X6vq71-TVjZxkmAGuwRAHhTaQTeRnavm

(Если изменение строки подключения всё же требуется, следует обратиться к файлам TaskSiteDB.tt в папке DataModels:

LoadPostgreSQLMetadata("localhost", "5432", "tasksite", "postgres", "123");
сервер (дефолтный) - порт (дефолтный) - название базы данных - логин (дефолтный) - пароль

И appsettings.json в корневом каталоге

"DefaultConnection": "Server=localhost;Port=5432;Database=tasksite;UserId=postgres;Password=123;")

Запуск приложения производится в Visual Studio по нажатию F5
