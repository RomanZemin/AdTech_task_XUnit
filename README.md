# Employee Manager Console Application

## Описание проекта

Этот проект представляет собой консольное приложение для управления списком сотрудников, сохраненным в формате JSON. Приложение позволяет добавлять, обновлять, получать и удалять записи о сотрудниках.

## Формат записи о сотруднике

- **Id** (int): уникальный идентификатор сотрудника
- **FirstName** (string): имя сотрудника
- **LastName** (string): фамилия сотрудника
- **SalaryPerHour** (decimal): почасовая оплата сотрудника

## Доступные операции

Приложение поддерживает следующие операции, которые могут быть выполнены с помощью командной строки:

1. **Добавление сотрудника:**
-add FirstName:<Имя> LastName:<Фамилия> Salary:<Зарплата>
Пример: `-add FirstName:John LastName:Doe Salary:100.50`

2. **Обновление информации о сотруднике:**
-update Id:<Id> [FirstName:<Имя>] [LastName:<Фамилия>] [Salary:<Зарплата>]
Пример: `-update Id:1 FirstName:Jane Salary:150.75`

3. **Получение информации о сотруднике:**
-get Id:<Id>
Пример: `-get Id:1`

4. **Удаление сотрудника:**
-delete Id:<Id>
Пример: `-delete Id:1`

5. **Получение списка всех сотрудников:**
-getall

## Структура проекта

- **Program.cs:** основной файл с точкой входа и реализацией команд.
- **EmployeeManager.cs:** класс для управления списком сотрудников.
- **Employee.cs:** класс для представления сотрудника.
- **employees.json:** файл для хранения данных о сотрудниках.

## Unit-тесты

Unit-тесты для проекта находятся в отдельной папке `XUnitTest` в решении. Чтобы подключить и запустить тесты:

1. Убедитесь, что у вас установлены необходимые пакеты NuGet для XUnit.
2. Откройте файл решения (`.sln`) и добавьте проект тестов в решение.
3. Запустите тесты через Test Explorer в Visual Studio.

## Запуск проекта

### С использованием Visual Studio:

1. Склонируйте репозиторий.
2. Откройте файл решения (`.sln`) в Visual Studio.
3. Убедитесь, что проект `AdTech_task` установлен как `Startup Project`.
4. Нажмите `F5` или `Ctrl+F5` для запуска проекта.

### С использованием командной строки:

1. Склонируйте репозиторий.
2. Перейдите в директорию проекта:
`cd path/to/AdTech_task`

Воспользуйтесь dotnet для запуска проекта:
`dotnet run -- -add FirstName:John LastName:Doe Salary:100.50`

Примеры использования
Добавление нового сотрудника:
`dotnet run -- -add FirstName:John LastName:Doe Salary:100.50`

Обновление информации о сотруднике:
`dotnet run -- -update Id:1 FirstName:Jane Salary:150.75`

Получение информации о сотруднике:
`dotnet run -- -get Id:1`

Удаление сотрудника:
`dotnet run -- -delete Id:1` 

Получение списка всех сотрудников:
`dotnet run -- -getall`
