using System;
using System.Collections.Generic;
using TinkkoffAcquiringSdk.Constants;
using TinkkoffAcquiringSdk.Responses;

namespace TinkkoffAcquiringSdk.Requests
{
    /// <summary>
    ///     Инициирует новый платеж
    /// </summary>
    public record InitRequest : AcquiringRequest<InitResponse>
    {
        private const string RecurrentFlagY = "Y";
        private string? _description;

        public InitRequest() : base(AcquiringApi.InitMethod)
        {
        }

        /// <summary>
        ///     Сумма в копейках
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        ///     Номер заказа в системе продавца
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        ///     Название шаблона формы оплаты продавца
        /// </summary>

        public string? PayForm { get; set; }

        /// <summary>
        ///     Идентификатор покупателя в системе продавца
        /// </summary>
        public string? CustomerKey { get; set; }

        /// <summary>
        ///     Краткое описание заказа, макс. длина 250 символов
        /// </summary>
        public string? Description
        {
            get => _description;
            set => _description = value?.Substring(0, 250);
        }

        /// <summary>
        ///     Язык платёжной формы.
        ///     ru - форма оплаты на русском языке;
        ///     en - форма оплаты на английском языке.
        ///     По-умолчанию - форма оплаты на русском языке
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        ///     Форма проведения платежа [ru.tinkoff.acquiring.sdk.models.enums.PayType]
        /// </summary>
        private string? PayType { get; set; }

        /// <summary>
        ///     Объект с данными чека
        /// </summary>
        public object? Receipt { get; set; }

        /// <summary>
        ///     Указывает, что совершается рекуррентный или нерекуррентный платеж
        /// </summary>
        public bool Recurrent { get; set; }

        /// <summary>
        ///     Флаг, что происходит оплата в рекуретном режиме, и вместо вызова FinishAuthorize необходимо вызвать Charge
        /// </summary>
        public bool ChargeFlag { get; set; }

        /// <summary>
        ///     Список с данными магазинов
        /// </summary>
        public List<object>? Shops { get; set; }

        /// <summary>
        ///     Список с данными чеков
        /// </summary>
        public List<object>? Receipts { get; set; }

        /// <summary>
        ///     Срок жизни ссылки
        /// </summary>
        public DateTime? RedirectDueDate { get; set; }

        public override Dictionary<string, object> ToDictionary()
        {
            var map = base.ToDictionary();

            AddIfNotNull(map, AcquiringFields.Amount, Amount.ToString());
            AddIfNotNull(map, AcquiringFields.OrderId, OrderId);
            AddIfNotNull(map, AcquiringFields.CustomerKey, CustomerKey);
            AddIfNotNull(map, AcquiringFields.Description, Description);
            AddIfNotNull(map, AcquiringFields.PayForm, PayForm);
            AddIfNotNull(map, AcquiringFields.Recurrent, Recurrent ? RecurrentFlagY : null);
            AddIfNotNull(map, AcquiringFields.Language, Language);
            AddIfNotNull(map, AcquiringFields.PayType, PayType);
            AddIfNotNull(map, AcquiringFields.Receipt, Receipt);
            AddIfNotNull(map, AcquiringFields.Receipts, Receipts);
            AddIfNotNull(map, AcquiringFields.Shops, Shops);
            AddIfNotNull(map, AcquiringFields.RedirectDueDate, RedirectDueDate.ToString());
            return map;
        }

        public override void Validate()
        {
        }
    }
}