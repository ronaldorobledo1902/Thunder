namespace GerenciadorMaterial.Api.Configuracao
{
    public class SqlServerRetryStrategySettings
    {
        public bool Enabled { get; set; }

        public int MaxCount { get; set; } = 6;


        public int MaxRetryDelayInSeconds { get; set; } = 30;


        public ICollection<int>? ErrorNumbersToAdd { get; set; }
    }
}
