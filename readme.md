


# Not official Tinkoff Acquiring SDK for C#, Net 5.0.

(ENG is below)

Rus

Данный SDK базируется на официальном SDK для андроида [TinkoffCreditSystems/AcquiringSdkAndroid(https://github.com/TinkoffCreditSystems/AcquiringSdkAndroid)]

На данный момент содержит метод GetState, который возвращает текущий статус платежа. Имеет методы расширения для ASP.Core

### Подготовка к работе
Для начала работы с SDK вам понадобятся:
* Terminal key
* Пароль
* Public key

Которые выдаются после подключения к [Интернет-Эквайрингу][acquiring].

SDK позволяет настроить режим работы (debug/prod). По умолчанию - режим prod.
Чтобы настроить debug режим, установите параметры:
```csharp
AcquiringSdk.isDeveloperMode = true // используется тестовый URL, деньги с карт не списываются
AcquiringSdk.isDebug = true         // включение логирования запросов (в будущем)
```

### Структура
SDK состоит из следующих модулей:

#### Core
Является базовым модулем для работы с Tinkoff Acquiring API. Модуль реализует протокол взаимодействия с сервером и позволяет не осуществлять прямых обращений в API. 

Основной класс модуля - **AcquiringClient** - предоставляет интерфейс для взаимодействия с Tinkoff Acquiring API. Для работы необходимы ключи и пароль продавца (см. **Подготовка к работе**).

### Поддержка
- По возникающим вопросам просьба обращаться на [iurii.aksenov@yandex.ru][support-email]
- Баги и feature-реквесты можно направлять в раздел [issues][issues]

### Ссылки
[Тинькофф Оплата - Документация API (https://oplata.tinkoff.ru/develop/api/payments/)]

---

Eng

This SDK is based on the official SDK for Android [TinkoffCreditSystems/AcquiringSdkAndroid(https://github.com/TinkoffCreditSystems/AcquiringSdkAndroid)]

Currently contains a GetState method that returns the current status of the payment. Has extension methods for ASP.Core

### Getting started
To get started with the SDK, you will need:
* Terminal key
* Password
* Public key

Which are issued after connecting to [Internet Acquiring] [acquiring].

The SDK allows you to customize the mode of operation (debug / prod). The default is prod mode.
To configure debug mode, set the parameters:
```csharp
AcquiringSdk.isDeveloperMode = true // a test URL is used, money is not debited from cards
AcquiringSdk.isDebug = true // enable request logging (in the future)
```

### Structure
The SDK consists of the following modules:

#### Core
It is a basic module for working with the Tinkoff Acquiring API. The module implements the protocol of interaction with the server and allows you not to make direct calls to the API.

The main class of the module - **AcquiringClient** - provides an interface for interacting with the Tinkoff Acquiring API. To work, you need the keys and password of the seller (see **Getting started**).

### Support
- If you have any questions, please contact [iurii.aksenov@yandex.ru] [support-email]
- Bugs and feature requests can be sent to the [issues] [issues] section

### Links
[Tinkoff Payment - API Documentation (https://oplata.tinkoff.ru/develop/api/payments/)]
