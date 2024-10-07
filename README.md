# tssRocket
Tss Inital Public Project

 Нужно избегать дальнейшего жесктого связывания, и, по-хорошему, продумать промежуточный слой, через который будут работать App и Unigate (и другие проекты, которые будут "ходить" через апи), чтобы потом проект можно было смаштабировать. Пока монолит (соотвественно вызов осуществляется через контроллеры)

Архитектура:
/TssRocket.App
/TssRocket.Data
/TssRocket.Domain
/TssRocket.UniGate
/TssRocket.WebApp

- Data - содержит модели данных для работы с базой данных, миграции и классы, работающие с "нижним слоем" - доступом к бд (Postgress, ms sql etc)
- Domain - интерфейсы и взаимодействие с моделями баз данных ( работа с "промежуточым слоем"- связка с /***.Data), сервисы для работы с репозиториями и т.д. Должны содержать базовые объекты взаимодействия, которые не знают о "верхнем" слое (т.е. по сути промежуточный слой взаимодейтсвия, содержащий данные и датасервисы), а также не работают напрямую с базой данных и проч. По-сути базовый абстрактный слой, максимально отвязанный от всего остального)
- App - слой взаимодействия между веб приложением и данными. Здесь используем паттерн Mediator, чтобы избежать жесткой связки. + поможет избежать боли в дальнейшем смасштабировании приложения (ниже напишу про микросервисы)
- WebApp - непосредственно приложение (MVC). Там же нужно реализовать всю логику Web APi (CRUD Rest API).


Пожелания:
Если делать с жесткой связкой взаимодейтсвия моделей , то приложение будет крайне трудно масштабировать, поэтому предлагаю после имплементации вынести веб апи в отдельный проект, как и взаимодействие с бд (т.е. по сути должно быть 3 отдельных микроосервиса - работа с базой данных, работа с API сторонних компаний, обработка и контроль (God Service). По-хорошему вообще базы данных должны быть разные. Но на этапе проектирования и внедрения микроархитектурная реализация займет очень много времени, поэтому пока "забиваем". Если проект "выстрелит", то архитектурно монолит можно будет разнести на микросервисы как раз таки благодаря тому, что у нас нет жесткой привязки
