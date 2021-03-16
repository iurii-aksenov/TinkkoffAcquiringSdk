using System.Collections.Generic;

namespace TinkkoffAcquiringSdk.Constants
{
    /// <summary>
    ///     Содержит константы для создания запросов к Acquiring API
    /// </summary>
    public static class AcquiringApi
    {
        public const string AddCardMethod = "AddCard";
        public const string AttachCardMethod = "AttachCard";
        public const string ChargeMethod = "Charge";
        public const string FinishAuthorizeMethod = "FinishAuthorize";
        public const string GetAddCardStateMethod = "GetAddCardState";
        public const string Check3DsVersionMethod = "Check3dsVersion";
        public const string GetCardListMethod = "GetCardList";
        public const string GetStateMethod = "GetState";
        public const string InitMethod = "Init";
        public const string RemoveCardMethod = "RemoveCard";
        public const string SubmitRandomAmountMethod = "SubmitRandomAmount";
        public const string GetQrMethod = "GetQr";
        public const string GetStaticQrMethod = "GetStaticQr";
        public const string Submit3DsAuthorization = "Submit3DSAuthorization";
        public const string Submit3DsAuthorizationV2 = "Submit3DSAuthorizationV2";
        public const string Complete3DsMethodV2 = "Complete3DSMethodv2";

        public const string ApiErrorCode3Dsv2NotSupported = "106";
        public const string ApiErrorCodeCustomerNotFound = "7";
        public const string ApiErrorCodeChargeRejected = "104";
        public const string ApiErrorCodeNoError = "0";

        public const string RecurringTypeKey = "recurringType";
        public const string RecurringTypeValue = "12";
        public const string FailMapiSessionID = "failMapiSessionId";

        internal const int StreamBufferSize = 4096;
        internal const string ApiRequestMethodPost = "POST";

        internal const string Json = "application/json";
        internal const string FormUrlEncoded = "application/x-www-form-urlencoded";
        internal const int Timeout = 40000;

        public const string ApiUrlReleaseOld = "https://securepay.tinkoff.ru/rest";
        public const string ApiUrlDebugOld = "https://rest-api-test.tcsbank.ru/rest";

        public const string ApiVersion = "v2";
        public static string ApiUrlRelease = $"https://securepay.tinkoff.ru/{ApiVersion}/[0]";
        public static string ApiUrlDebug = $"https://rest-api-test.tcsbank.ru/{ApiVersion}/[0]";

        /// <summary>
        ///     Коды ошибок при привязке карты
        /// </summary>
        public static List<string> ErrorCodesAttachedCard = new()
        {
            "3",
            "6"
        };

        /// <summary>
        ///     Коды ошибок, вызванные временными неполадками системы
        /// </summary>
        public static List<string> ErrorCodesFallback = new()
        {
            "9999",
            "231",
            "3",
            "3001"
        };

        /// <summary>
        ///     Коды ошибок, сообщение которых можно показать конечным пользователям
        /// </summary>
        public static List<string> ErrorCodesForUserShowing = new()
        {
            "53",
            "206",
            "224",
            "225",
            "252",
            "99",
            "101",
            "1006",
            "1012",
            "1013",
            "1014",
            "1015",
            "1030",
            "1033",
            "1034",
            "1035",
            "1036",
            "1037",
            "1038",
            "1039",
            "1040",
            "1041",
            "1042",
            "1043",
            "1051",
            "1054",
            "1057",
            "1065",
            "1082",
            "1089",
            "1091",
            "1096"
        };

        public static List<string> OldMethodsList = new() { "Submit3DSAuthorization" };
    }
}