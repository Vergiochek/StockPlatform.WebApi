# StockPlatform.WebApi
Backend для сток-платформы.

Что и как реализовано:
- Структура всей платформы состоит из трёх проектов: StockPLatform.WebApi, StockPlatform.Core и StockPlatform.LoggerService. 
   - Первый проект StockPlatform.WebApi - главный, основной. В нём находятся главные файлы для работы платформы: контроллеры, которые содержат в себе необходимые endpoints для работы; класс Startup.cs, который является входной точкой платформы со всеми настройками сервисов и конфигурациями; lauchSettings.json, который отвечает за настройки проекта; файлы для глобального обработчика ошибок и логгирования: модель ErrorDetails.cs, расширение ExceptionMiddlewareExtensions.cs и nlog.config файл конфигурации для логгирования.
   - Второй проект StockPlatform.Core - библиотека-проект, в котором находятся все сущности, их сервисы с интерфейсами, в которых прописаны все методы для работы с endpoints в контроллерах, и файлы для БД: DbClient, IDbClient и StockPlatformDbConfig (про БД отдельное описание ниже).
   - Ну и третий проект StockPlatform.LoggerService - библиотека-проект, представляющая собой простой сервис для логирования. Внутри находятся интерфейс ILoggerManager и сам класс LoggerManager.cs, который наследует этот интерфейс (про логирование отдельное описание ниже).
- База данных - MongoDb. Имя и названия коллекций для сущностей прописаны как environmentVariables в lauchSettings.json. Connection string, или строка подключения базы данных, прописана через user-secrets manager, то есть прописана как environmentVariable, но не видна в исходном коде на гитхабе. Она хранится локально. И конечно это не является безопасным способом хранения, а просто, как говорится, for development purposes :) Далее были созданы уже вышеупомянутые StockPlatformDbConfig, IDbClient и DbClient:
   - StockPlatformDbConfig.cs - класс для отображения наших environment variables (имени бд, названий коллекций и строки подключения), чтобы использовать их в приложении было намного удобнее.
   - DbClient( и IDbClient интерфейс, который он наследует) - класс, который говорит сам за себя. Это класс, где находится клиент для работы с базой данных MongoDB. Здесь находится сетап для БД: через IOptions вводится конфигурация, которая как раз создана как StockPlatformDbConfig. Создается клиент MongoDB через передачу нашей connection string, из клиента далее достаётся база данных, из которой уже и получаем наши коллекции. Ну а дальаше в этом классе описываются методы, которые возвращают полученные коллекции.
- Заполнение базы данных происходит при добавлении сущностей фото или текстов с помощью POST.
- Прописаны все сущности и реализованы все необходимые endpoints для API: получение всех сущностей, получение всех сущностей Фотография, получение по ID сущности Фотография, изменение сущности Фотография, получение всех сущностей Текст, добавление сущности Текст. Дополнительно было реализовано получение по ID сущности Текст, изменение сущности Текст, добавление сущности Фотография, а также удаление для обеих сущностей.
- Реализован Global Error Handling - глобальный обработчик ошибок. Реализован при помощи Built-In Middleware UseExceptionHandlerMiddleware. Global Error Handling помогает обрабатывать ошибки глобально, то есть не нужно прописывать try-catch блоки для каждого действия. Была создана модель ErrorDetails.cs, этот класс с полями для статус кода и сообщения собирает подробности возникающих ошибок. Далее в классе ExceptionMiddlewareExtensions.cs прописано поведение глобального обработчика ошибок. Там же и происходит логирование ошибок в файл, который создан через nlog.config.
- Реализовано логирование. Реализован при помощи библиотеки NLog. Ошибки, которые отлавливает глобальные обработчик ошибок, записываются в текстовый файл, который создаётся по пути, прописанному в конфиге nlog.config. Само логирование описано в проекте StockPlatform.LoggerService: класс LoggerManager.cs и интерфейс ILoggerManager.cs.
