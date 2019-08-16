using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Prosolve.MicroService.Identification.API.Models.Users;
using Prosolve.MicroService.Identification.Entities.Users;

using Sharpdev.SDK.API;

namespace Prosolve.MicroService.Identification.API.Controllers
{
    public class UserController : SharpdevControllerBase
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserReadResponse), StatusCodes.Status200OK)] // Всё гуд
        [ProducesResponseType(StatusCodes.Status203NonAuthoritative)]             // Всё гуд данные из cache.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                 // Не авторизован
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                   // Некорректные значения для Request
        [ProducesResponseType(StatusCodes
            .Status403Forbidden)]                                  // Не хватает прав доступа у конкретного пользователя
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)] // Не корректный content-type
        [ProducesResponseType(StatusCodes
            .Status408RequestTimeout)]                                     // Превышен лимит по времени выполнения
        [ProducesResponseType(StatusCodes.Status413RequestEntityTooLarge)] // Большой body
        [ProducesResponseType(StatusCodes.Status414RequestUriTooLong)]     // Большой Uri
        [ProducesResponseType(StatusCodes
            .Status429TooManyRequests)]                                  // Слишком много запросов от конкретного пользователя
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Внезапная ошибка при работе сервиса
        [ProducesResponseType(StatusCodes.Status502BadGateway)]          // Какой-то из смежных серверов выдал ошибку
        [ProducesResponseType(StatusCodes
            .Status503ServiceUnavailable)]                          // Техническое обслуживание (в заголовке Retry-After дата окончания)
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)] // Какой-то из смежных серверов выдал тайм аут
        public ActionResult<UserReadResponse> Get([FromBody]UserReadRequest request)
        {
            return new UserReadResponse();
        }

        [HttpHead]
        [ProducesResponseType(typeof(UserReadResponse), StatusCodes.Status200OK)] // Всё гуд
        [ProducesResponseType(StatusCodes.Status203NonAuthoritative)]             // Всё гуд данные из cache.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                 // Не авторизован
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                   // Некорректные значения для Request
        [ProducesResponseType(StatusCodes
            .Status403Forbidden)]                                  // Не хватает прав доступа у конкретного пользователя
        [ProducesResponseType(StatusCodes.Status404NotFound)]      // Ресурс не найден
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)] // Не корректный content-type
        [ProducesResponseType(StatusCodes
            .Status408RequestTimeout)]                                     // Превышен лимит по времени выполнения
        [ProducesResponseType(StatusCodes.Status410Gone)]                  // Ресурс был удалён
        [ProducesResponseType(StatusCodes.Status413RequestEntityTooLarge)] // Большой body
        [ProducesResponseType(StatusCodes.Status414RequestUriTooLong)]     // Большой Uri
        [ProducesResponseType(StatusCodes
            .Status429TooManyRequests)]                                  // Слишком много запросов от конкретного пользователя
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Внезапная ошибка при работе сервиса
        [ProducesResponseType(StatusCodes.Status502BadGateway)]          // Какой-то из смежных серверов выдал ошибку
        [ProducesResponseType(StatusCodes
            .Status503ServiceUnavailable)]                          // Техническое обслуживание (в заголовке Retry-After дата окончания)
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)] // Какой-то из смежных серверов выдал тайм аут
        public ActionResult Head([FromBody]Guid userPublicId)
        {
            return new StatusCodeResult(200);
        }

        [HttpGet("{userPublicId}")]
        [ProducesResponseType(typeof(UserReadResponse), StatusCodes.Status200OK)] // 200 Всё гуд
        [ProducesResponseType(StatusCodes.Status203NonAuthoritative)]             // 203 Всё гуд данные из cache.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                 // 401 Не авторизован
        [ProducesResponseType(StatusCodes
            .Status400BadRequest)] // 400 Некорректные значения для Request
        [ProducesResponseType(StatusCodes
            .Status403Forbidden)]                                  // 403 Не хватает прав доступа у конкретного пользователя
        [ProducesResponseType(StatusCodes.Status404NotFound)]      // 404 Ресурс не найден
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)] // 406 Не корректный content-type
        [ProducesResponseType(StatusCodes
            .Status408RequestTimeout)]                                     // 408 Превышен лимит по времени выполнения
        [ProducesResponseType(StatusCodes.Status410Gone)]                  // 410 Ресурс был удалён
        [ProducesResponseType(StatusCodes.Status413RequestEntityTooLarge)] // 413 Большой body
        [ProducesResponseType(StatusCodes.Status414RequestUriTooLong)]     // 414 Большой Uri
        [ProducesResponseType(StatusCodes
            .Status429TooManyRequests)]                                  // 429 Слишком много запросов от конкретного пользователя
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // 500 Внезапная ошибка при работе сервиса
        [ProducesResponseType(StatusCodes
            .Status502BadGateway)] // 502 Какой-то из смежных серверов выдал ошибку
        [ProducesResponseType(StatusCodes
            .Status503ServiceUnavailable)]                          // 503 Техническое обслуживание (в заголовке Retry-After дата окончания)
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)] // 504 Какой-то из смежных серверов выдал тайм аут
        public ActionResult<UserResponse> Get([FromRoute]Guid userPublicId)
        {
            // 503 Техническое обслуживание (в заголовке Retry-After дата окончания)

            // 406 Не корректный content-type
            // 413 Большой body
            // 414 Большой Uri
            // 400 Некорректные значения для Request

            // 401 Не авторизован

            // 429 Слишком много запросов от конкретного пользователя

            // 403 Не хватает прав доступа у конкретного пользователя

            // 200 Всё гуд // 203 Всё гуд данные из cache. // 404 Ресурс не найден // 410 Ресурс был удалён

            // 408 Превышен лимит по времени выполнения
            // 500 Внезапная ошибка при работе сервиса
            // 502 Какой-то из смежных серверов выдал ошибку
            // 504 Какой-то из смежных серверов выдал тайм аут

            return new StatusCodeResult(410);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]      // Объект успешно сложен.
        [ProducesResponseType(StatusCodes.Status202Accepted)]     // Заявка на создание объекта принята.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Не авторизован
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   // Некорректные значения для Request
        [ProducesResponseType(StatusCodes
            .Status403Forbidden)]                                          // Не хватает прав доступа у конкретного пользователя
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]         // Не корректный content-type
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]        // Превышен лимит по времени выполнения
        [ProducesResponseType(StatusCodes.Status413RequestEntityTooLarge)] // Большой body
        [ProducesResponseType(StatusCodes.Status414RequestUriTooLong)]     // Большой Uri
        [ProducesResponseType(StatusCodes
            .Status429TooManyRequests)]                                  // Слишком много запросов от конкретного пользователя
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Внезапная ошибка при работе сервиса
        [ProducesResponseType(StatusCodes.Status502BadGateway)]          // Какой-то из смежных серверов выдал ошибку
        [ProducesResponseType(StatusCodes
            .Status503ServiceUnavailable)]                          // Техническое обслуживание (в заголовке Retry-After дата окончания)
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)] // Какой-то из смежных серверов выдал тайм аут
        public ActionResult Post([FromBody]string value)
        {
            var userBuilder = new UserBuilder{Version = 1};
            this._identityService.CreateUsers(new IUserBuilder[] { userBuilder });

            return this.Created(new Uri("https://ya.ru/"), value);
        }

        // PUT api/values/5
        [HttpPut("{userPublicId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]      // Объект успешно сложен.
        [ProducesResponseType(StatusCodes.Status202Accepted)]     // Заявка на создание объекта принята.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Не авторизован
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   // Некорректные значения для Request
        [ProducesResponseType(StatusCodes
            .Status403Forbidden)]                                          // Не хватает прав доступа у конкретного пользователя
        [ProducesResponseType(StatusCodes.Status404NotFound)]              // Ресурс не найден
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]         // Не корректный content-type
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]        // Превышен лимит по времени выполнения
        [ProducesResponseType(StatusCodes.Status409Conflict)]              // Некорректная версия объекта
        [ProducesResponseType(StatusCodes.Status413RequestEntityTooLarge)] // Большой body
        [ProducesResponseType(StatusCodes.Status414RequestUriTooLong)]     // Большой Uri
        [ProducesResponseType(StatusCodes
            .Status429TooManyRequests)]                                  // Слишком много запросов от конкретного пользователя
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Внезапная ошибка при работе сервиса
        [ProducesResponseType(StatusCodes.Status502BadGateway)]          // Какой-то из смежных серверов выдал ошибку
        [ProducesResponseType(StatusCodes
            .Status503ServiceUnavailable)]                          // Техническое обслуживание (в заголовке Retry-After дата окончания)
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)] // Какой-то из смежных серверов выдал тайм аут
        public ActionResult Put([FromRoute]Guid userPublicId, [FromBody]string value)
        {
            return new StatusCodeResult(410);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]      // Объект успешно сложен.
        [ProducesResponseType(StatusCodes.Status202Accepted)]     // Заявка на создание обновление принята.
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Не авторизован
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   // Некорректные значения для Request
        [ProducesResponseType(StatusCodes
            .Status403Forbidden)]                                          // Не хватает прав доступа у конкретного пользователя
        [ProducesResponseType(StatusCodes.Status404NotFound)]              // Ресурс не найден
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]         // Не корректный content-type
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]        // Превышен лимит по времени выполнения
        [ProducesResponseType(StatusCodes.Status409Conflict)]              // Некорректная версия объекта
        [ProducesResponseType(StatusCodes.Status413RequestEntityTooLarge)] // Большой body
        [ProducesResponseType(StatusCodes.Status414RequestUriTooLong)]     // Большой Uri
        [ProducesResponseType(StatusCodes
            .Status429TooManyRequests)]                                  // Слишком много запросов от конкретного пользователя
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Внезапная ошибка при работе сервиса
        [ProducesResponseType(StatusCodes.Status502BadGateway)]          // Какой-то из смежных серверов выдал ошибку
        [ProducesResponseType(StatusCodes
            .Status503ServiceUnavailable)]                          // Техническое обслуживание (в заголовке Retry-After дата окончания)
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)] // Какой-то из смежных серверов выдал тайм аут
        public ActionResult Patch([FromRoute]Guid userPublicId)
        {
            return new StatusCodeResult(201);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]    // Контент удалён
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Не авторизован
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   // Некорректные значения для Request
        [ProducesResponseType(StatusCodes
            .Status403Forbidden)]                                          // Не хватает прав доступа у конкретного пользователя
        [ProducesResponseType(StatusCodes.Status404NotFound)]              // Ресурс не найден
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]         // Не корректный content-type
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]        // Превышен лимит по времени выполнения
        [ProducesResponseType(StatusCodes.Status413RequestEntityTooLarge)] // Большой body
        [ProducesResponseType(StatusCodes.Status414RequestUriTooLong)]     // Большой Uri
        [ProducesResponseType(StatusCodes
            .Status429TooManyRequests)]                                  // Слишком много запросов от конкретного пользователя
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Внезапная ошибка при работе сервиса
        [ProducesResponseType(StatusCodes.Status502BadGateway)]          // Какой-то из смежных серверов выдал ошибку
        [ProducesResponseType(StatusCodes
            .Status503ServiceUnavailable)]                          // Техническое обслуживание (в заголовке Retry-After дата окончания)
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)] // Какой-то из смежных серверов выдал тайм аут
        public ActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
