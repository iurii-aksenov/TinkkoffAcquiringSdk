using System;
using System.Threading.Tasks;
using TinkkoffAcquiringSdk.Requests;
using TinkkoffAcquiringSdk.Responses;
using Xunit;

namespace TinkkoffAcquiringSdk.UnitTests
{
    public class AcquiringClientTests
    {
        private readonly AcquiringClient _client;

        public AcquiringClientTests()
        {
            _client = new AcquiringClient(TestPaymentData.TestTerminalKey, TestPaymentData.TestPass);
        }

        private async Task<long?> InitSessionAsync(bool isRecurrent)
        {
            var request = new InitRequest
            {
                Amount = 2000,
                OrderId = new Random().Next().ToString(),
                ChargeFlag = isRecurrent,
                CustomerKey = TestPaymentData.TestCustomerKey,
                PayForm = TestPaymentData.TestPayForm,
                Recurrent = isRecurrent,
            };
            var response = await _client.InitPaymentSessionAsync(request);

            var paymentId = response.PaymentId;

            return paymentId;
        }


        [Fact]
        public async Task GetState_ValidPaymentId_ReturnSuccess()
        {
            AcquiringClient.IsDeveloperMode = true;
            var paymentId = await InitSessionAsync(false);
            var request = new GetStateRequest(paymentId.Value);
            var response =await _client.GetStateAsync(request);
            Assert.True(response.IsSuccess && response.GetStatusType() == ResponseStatusType.New);
        }
    }
}
