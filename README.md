# Test_ZdorovayaNorka

Завод по производству "ZdorovayaNorka"

Веб приложение выполнено в ASP.NET Web API и использует следующее:
1. NET 5 https://dotnet.microsoft.com/download/dotnet/5.0
2. ASP.NET Core 5.0 Web Api, https://docs.microsoft.com/ru-ru/aspnet/core/tutorials/first-
web-api?view=aspnetcore-5.0&tabs=visual-studio, https://docs.microsoft.com/en-
us/learn/modules/build-web-api-aspnet-core/
3. EntityFramework Core 5.0 https://docs.microsoft.com/en-us/ef/core/ ,
https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
4. EF Core Sqlite https://entityframeworkcore.com/providers-sqlite

Сущности:

1. Сотрудники должны иметь следующие данные:

- номер пропуска (ID),
- Фамилия,
- Имя,
- Отчество,
- Должность,
- Cписок всех входов/выходов с завода (назовем их смены).

2. Должность

- Id
- Name

Должности у сотрудников будут трех видов:

- Менеджер,
- Инженер,
- Тестировщик свечей

3. Смены содержат:
  
- id смены (поле для БД)
- время начала смены (когда человек пришел на завод “ZdorovayaNorka“),
- конца смены (когда ушел)
- количество отработанных часов (заполняется в конце смены)
- ссылку на работника.


WebApi Содержит два следующих контролера с функциями:

Checkpoint (КПП)

1. StartShift - отмечается старт рабочего дня
2. EndShift - отмечается конец рабочего дня

HRDepartment (Отдел кадров)

1. Create - Создание сотрудника
2. Delete - Удаляет сотрудника
3. Update - Редактирование сотрудника
4. GetAllEmployees - Получение списока всех сотрудников (если требуется то по id позиции)
5. GetAllPositions - Получения списка позиций
