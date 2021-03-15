using Newtonsoft.Json;

namespace TinkkoffAcquiringSdk.Responses
{
    /// <summary>
    /// Базовый класс для ответов
    /// </summary>
    public record AcquiringResponse
    {
        /// <summary>
        ///     Идентификатор терминала
        /// </summary>
        public string? TerminalKey { get; set; }

        /// <summary>
        ///     Cтатус успешного выполнения запроса
        /// </summary>
        [JsonProperty("Success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Rод ошибки
        /// </summary>
        public long ErrorCode { get; set; }

        /// <summary>
        ///     Краткое описание ошибки
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        ///     Подробное описание ошибки
        /// </summary>
        public string? Details { get; set; }
    }
}