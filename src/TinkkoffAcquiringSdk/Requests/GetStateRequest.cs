using System.Collections.Generic;
using TinkkoffAcquiringSdk.Constants;
using TinkkoffAcquiringSdk.Responses;

namespace TinkkoffAcquiringSdk.Requests
{
    /// <summary>
    ///     Возвращает статус платежа
    /// </summary>
    public record GetStateRequest : AcquiringRequest<GetStateResponse>
    {
        public GetStateRequest(long paymentId) : base(AcquiringApi.GetStateMethod)
        {
            PaymentId = paymentId;
        }

        /// <summary>
        ///     Уникальный идентификатор транзакции в системе банка
        /// </summary>
        public long PaymentId { get; }

        public override Dictionary<string, object> ToDictionary()
        {
            var map = base.ToDictionary();
            AddIfNotNull(map, AcquiringFields.PaymentId, PaymentId);
            return map;
        }

        public override void Validate()
        {
            Validate(PaymentId, AcquiringFields.PaymentId);
        }
    }
}