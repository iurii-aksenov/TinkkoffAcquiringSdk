using System;

namespace TinkkoffAcquiringSdk.Responses
{
    public record GetStateResponse : AcquiringResponse
    {
        /// <summary>
        ///     Номер заказа в системе продавца
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        ///     Кникальный идентификатор транзакции в системе банка
        /// </summary>
        public long PaymentId { get; set; }

        /// <summary>
        ///     Статус транзакции
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     Сумма заказа в копейках
        /// </summary>
        public long? Amount { get; set; }

        public ResponseStatusType GetStatusType()
        {
            return ResponseStatusConverter.GetStatusType(Status);
        }
    }
}