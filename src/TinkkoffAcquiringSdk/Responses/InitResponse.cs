namespace TinkkoffAcquiringSdk.Responses
{
    public record InitResponse : AcquiringResponse
    {
        public long? Amount { get; set; }

        public string? OrderId { get; set; }

        public long? PaymentId { get; set; }

        public ResponseStatusType? Status { get; set; }
    }
}