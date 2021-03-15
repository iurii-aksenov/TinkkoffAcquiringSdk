using System;

namespace TinkkoffAcquiringSdk.Responses
{
    public static class ResponseStatusConverter
    {
        public static ResponseStatusType GetStatusType(string status)
        {
            return status switch
            {
                "NEW" => ResponseStatusType.New,
                "CANCELLED" => ResponseStatusType.Cancelled,
                "PREAUTHORIZING" => ResponseStatusType.Preauthorizing,
                "FORMSHOWED" => ResponseStatusType.Formshowed,
                "AUTHORIZING" => ResponseStatusType.Authorizing,
                "THREE_DS_CHECKING" => ResponseStatusType.ThreeDsChecking,
                "THREE_DS_CHECKED" => ResponseStatusType.ThreeDsChecked,
                "AUTHORIZED" => ResponseStatusType.Authorized,
                "REVERSING" => ResponseStatusType.Reversing,
                "REVERSED" => ResponseStatusType.Reversed,
                "CONFIRMING" => ResponseStatusType.Confirming,
                "CONFIRMED" => ResponseStatusType.Confirmed,
                "REFUNDING" => ResponseStatusType.Refunding,
                "REFUNDED" => ResponseStatusType.Refunded,
                "REJECTED" => ResponseStatusType.Rejected,
                "UNKNOWN" => ResponseStatusType.Unknown,
                "LOOP_CHECKING" => ResponseStatusType.LoopChecking,
                "COMPLETED" => ResponseStatusType.Completed,
                "AUTH_FAILED" => ResponseStatusType.AuthFailed,
                "FORM_SHOWED" => ResponseStatusType.FormShowed,
                _ => throw new ArgumentOutOfRangeException($"{nameof(ResponseStatusType)} has no value: '{status}'")
            };
        }
    }

    /// <summary>
    ///     Статус в ответе на запрос методов Acquiring API
    /// </summary>
    public enum ResponseStatusType
    {
        New,
        Cancelled,
        Preauthorizing,
        Formshowed,
        Authorizing,
        ThreeDsChecking,
        ThreeDsChecked,
        Authorized,
        Reversing,
        Reversed,
        Confirming,
        Confirmed,
        Refunding,
        Refunded,
        Rejected,
        Unknown,
        LoopChecking,
        Completed,
        AuthFailed,
        FormShowed
    }
}