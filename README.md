# Управление риэлторами
Описание:
Решение состоит из четырех слоев: SQL-backend (RieltorsManagement.SQL), доступ к данным через EF Core (RieltorsManagement.DAL), бизнес-логика (RieltorsManagement.BLL), Web API (RieltorsManagement.WebAPI).


Первичная настройка:

Выполнить скрипт наката из UpScript.sql RieltorsManagement.SQL (если таблицы будут накатываться существующую БД, то изменить название БД в строчке use RieltorDB, иначе для создания новой БД раскомментировать строчку create database RieltorDB;);

В решении RieltorsManagement.WebAPI в файле appsettings.json изменить строку подключения DefaultConnection.


Тестирование:
При запуске по умолчанию открывается страница index.html для удобства тестирования добавления/изменения/удаления риэлторов.

Риэлторы

Примеры GET-запросов:

https://localhost:44366/api/rieltors - вывод всех риэлторов из БД.

https://localhost:44366/api/rieltors/2 - вывод риэлтора с Id = 2

Параметры фильтрации: lastName (фамилия), division (наименование подразделения).

https://localhost:44366/api/rieltors?lastName=Семен - фильтрация по фамилии

https://localhost:44366/api/rieltors?lastName=Семен&division=1 - фильтрация по фамилии и наименованию подразделения.

Параметры пагинации: page (номер страницы), pageSize (количество элементов, отображаемых на странице). pageSize по умолчанию выставлен равным 5.

https://localhost:44366/api/rieltors?page=2&pageSize=2 - отображение второй страницы, по 2 элемента на странице.

Методы PUT, POST и DELETE можно протестировать через index.html.

Подразделения.

Примеры GET-запросов:

https://localhost:44366/api/divisions - вывод всех подразделений из БД.

https://localhost:44366/api/rieltors/1 - вывод подразделения с Id = 1

Параметры фильтрации: name (наименование подразделения).

https://localhost:44366/api/divisions?name=Отдел - фильтрация по наименованию подразделения.

Параметры пагинации: page (номер страницы), pageSize (количество элементов, отображаемых на странице). pageSize по умолчанию выставлен равным 5.

https://localhost:44366/api/divisions?name=Отдел&page=2&pageSize=1- отображение второй страницы, по 2 элемента на странице для подразделений, в наименовании которых содержится слово Отдел.
