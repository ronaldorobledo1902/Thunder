namespace GerenciadorMaterial.Api.Configuracao
{
    public class SqlServerSettings
    {
        public static string SessionName => "Core:Data:SqlServer";

        public string? ConnectionString { get; set; }

        public bool EnableSensitiveDataLogging { get; set; }

        public bool EnableDetailedErrors { get; set; }

        public bool EnableServiceProviderCaching { get; set; } = true;


        public bool EnableThreadSafetyChecks { get; set; } = true;


        public int LoggingCacheTimeInSeconds { get; set; } = 1;


        public SqlServerRetryStrategySettings Retry { get; set; } = new SqlServerRetryStrategySettings();


        public SqlServerTimeoutStrategySettings Timeout { get; set; } = new SqlServerTimeoutStrategySettings();


        public int MaxBatchSize { get; set; }

        public int CompatibilityLevel { get; set; } = 150;


        public int MaxPoolSize { get; set; } = 1024;


        public void Validate()
        {
            ArgumentNullException.ThrowIfNull(ConnectionString, "ConnectionString");
        }
    }
}
