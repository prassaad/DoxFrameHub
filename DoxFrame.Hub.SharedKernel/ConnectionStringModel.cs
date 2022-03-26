namespace DoxFrame.Hub.SharedKernel
{
    public class ConnectionStringModel {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string ConnectionString { get; set; }
        public bool IsPrivate { get; set; }
        public string ProviderName { get; set; }
    }
}
