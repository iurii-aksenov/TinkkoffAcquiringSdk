using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TinkkoffAcquiringSdk.Constants;
using TinkkoffAcquiringSdk.Requests;
using TinkkoffAcquiringSdk.Responses;
using TinkkoffAcquiringSdk.Utils;

namespace TinkkoffAcquiringSdk
{
    /// <summary>
    ///     Класс позволяет конфигурировать SDK и осуществлять взаимодействие с Tinkoff Acquiring API.
    ///     Методы осуществляют обращение к API.
    /// </summary>
    public class AcquiringApiClient
    {
        private static readonly HttpClient HttpClient = new();
        private static readonly JsonSerializerSettings Settings = new() {NullValueHandling = NullValueHandling.Ignore};

        private static readonly HashSet<string> TokenIgnoreFields = new()
        {
            AcquiringFields.Data,
            AcquiringFields.Receipt,
            AcquiringFields.Receipts,
            AcquiringFields.Shops
        };

        private readonly string _password;
        private readonly string _terminalKey;

        /// <param name="terminalKey">Ключ терминала. Выдается после подключения к Tinkoff Acquiring</param>
        /// <param name="password">Пароль от терминала. Выдается вместе с terminalKey</param>
        public AcquiringApiClient(string terminalKey, string password)
        {
            _terminalKey = terminalKey;
            _password = password;
        }

        /// <summary>
        ///     Позволяет переключать SDK с тестового режима и обратно. В тестовом режиме деньги с карты не
        ///     списываются. По-умолчанию выключен
        /// </summary>
        public static bool IsDeveloperMode { get; set; }

        /// <summary>
        ///     Инициирует платежную сессию
        /// </summary>
        public async Task<InitResponse> InitPaymentSessionAsync(InitRequest request)
        {
            request = request with
            {
                TerminalKey = _terminalKey,
                Password = _password
            };
            return await SendRequestAsync<InitResponse, InitRequest>(request);
        }

        /// <summary>
        ///     Возвращает статус платежа
        /// </summary>
        public async Task<GetStateResponse> GetStateAsync(GetStateRequest request)
        {
            request = request with
            {
                TerminalKey = _terminalKey,
                Password = _password
            };
            return await SendRequestAsync<GetStateResponse, GetStateRequest>(request);
        }

        private static async Task<TResponse> SendRequestAsync<TResponse, TRequest>(TRequest request)
            where TResponse : AcquiringResponse where TRequest : AcquiringRequest<TResponse>
        {
            request.Token = MakeToken(request);
            var json = JsonConvert.SerializeObject(request, Settings);
            var url = GetUrl(request.MethodApi);
            using HttpContent content = new StringContent(json, Encoding.UTF8, AcquiringApi.Json);
            var response = await HttpClient.PostAsync(url, content);
            var responseContent = response.Content;
            var body = await responseContent.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        private static string MakeToken<TResponse>(AcquiringRequest<TResponse> request)
            where TResponse : AcquiringResponse
        {
            var parameters = request.ToDictionary();

            parameters.Remove(AcquiringFields.Token);
            parameters[AcquiringFields.PasswordKey] = request.Password;

            var sortedKeys = new List<string>(parameters.Keys);
            sortedKeys.Sort();

            var builder = new StringBuilder();
            var ignoredKeys = TokenIgnoreFields;
            foreach (var key in sortedKeys)
            {
                if (!ignoredKeys.Contains(key))
                {
                    builder.Append(parameters[key]);
                }
            }

            return CryptoUtils.Sha256(builder.ToString());
        }

        /// <summary>
        ///     Возвращает базовый Url для переданного названия метода запроса.
        ///     Зависит от режима работы SDK [AcquiringClient.IsDeveloperMode]
        /// </summary>
        private static string GetUrl(string apiMethod)
        {
            var url = IsUseV1Api(apiMethod) ? IsDeveloperMode ? AcquiringApi.ApiUrlDebugOld :
                AcquiringApi.ApiUrlReleaseOld :
                IsDeveloperMode ? AcquiringApi.ApiUrlDebug : AcquiringApi.ApiUrlRelease;
            return url.Replace("[0]", apiMethod);
        }

        private static bool IsUseV1Api(string apiMethod)
        {
            return AcquiringApi.OldMethodsList.Contains(apiMethod);
        }
    }
}