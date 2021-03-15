namespace TinkkoffAcquiringSdk
{
    public class AcquiringOptions
    {
        /// <summary>
        /// Ключ терминала. Выдается после подключения к Tinkoff Acquiring
        /// </summary>
        public string TerminalKey { get; set; } = null!;

        /// <summary>
        /// Позволяет переключать SDK с тестового режима и обратно. В тестовом режиме деньги с карты не
        /// списываются. По-умолчанию выключен
        /// </summary>
        public bool IsDeveloperMode { get; set; } = false;
    }
}