namespace TinkkoffAcquiringSdk
{
    public class AcquiringOptions
    {
        /// <summary>
        /// Ключ терминала. Выдается после подключения к Tinkoff Acquiring
        /// </summary>
        public string TerminalKey { get; set; } = null!;

        /// <summary>
        /// Пароль от терминала. Выдается вместе с terminalKey
        /// </summary>
        public string Password { get; set; } = null!;
    }
}