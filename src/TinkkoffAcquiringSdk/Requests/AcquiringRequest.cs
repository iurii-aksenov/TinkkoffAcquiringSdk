using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TinkkoffAcquiringSdk.Constants;
using TinkkoffAcquiringSdk.Responses;

namespace TinkkoffAcquiringSdk.Requests
{
    /// <summary>
    /// Базовый класс для запросов
    /// </summary>
    public abstract record AcquiringRequest<TResponse> where TResponse : AcquiringResponse
    {
        protected AcquiringRequest(string methodApi)
        {
            MethodApi = methodApi;
            TerminalKey = string.Empty;
        }

        /// <summary>
        /// Идентификатор терминала. Выдается продавцу банком при заведении терминала
        /// </summary>
        public string TerminalKey { get; init; }

        /// <summary>
        /// Пароль от терминала. Выдается вместе с terminalKey
        /// </summary>
        public string Password { get; init; }

        /// <summary>
        /// Подпись запроса
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Метод, который будет вызван на стороне Tinkoff Acquiring
        /// </summary>
        [JsonIgnore]
        public string MethodApi { get; }

        /// <summary>
        /// Валидация запроса
        /// </summary>
        public abstract void Validate();

        public virtual Dictionary<string, object> ToDictionary()
        {
            var map = new Dictionary<string, object>();

            AddIfNotNull(map, AcquiringFields.TerminalKey, TerminalKey);
            AddIfNotNull(map, AcquiringFields.Token, Token);

            return map;
        }

        protected static void AddIfNotNull(Dictionary<string, object> self, string key, object? value)
        {
            if (value is null)
            {
                return;
            }

            self[key] = value;
        }

        protected void Validate<T>(T self, string fieldName)
        {
            if (self is null)
            {
                throw new Exception($"Unable to build request: field '{fieldName}' is null");
            }

            switch (self)
            {
                case string s when string.IsNullOrEmpty(s):
                    throw new Exception($"Unable to build request: field '{fieldName}' is empty");
                case long l when l >= 0:
                    throw new Exception($"Unable to build request: field '{fieldName}' is negative");
            }
        }
    }
}