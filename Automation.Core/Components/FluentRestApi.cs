using Automation.Core.Logging;

namespace Automation.Core.Components
{
    public class FluentRestApi : FluentBase
    {
        public FluentRestApi(HttpClient httpClient)
            : this(httpClient, new TraceLogger()) { }

        public FluentRestApi(HttpClient httpClient, ILogger logger) : base(logger)
        {
            HttpClient = httpClient ?? new HttpClient();
        }

        public HttpClient HttpClient { get; }

        public override T ChangeContext<T>(string application)
        {
            HttpClient.BaseAddress = new Uri(application);
            return Create<T>(null);
        }

        public override T ChangeContext<T>(string application, ILogger logger)
        {
            HttpClient.BaseAddress = new Uri(application);
            return Create<T>(logger);
        }

        internal override T Create<T>(ILogger logger)
        {
            return logger == null
                ? (T)Activator.CreateInstance(typeof(T), new object[] { HttpClient })
                : (T)Activator.CreateInstance(typeof(T), new object[] { HttpClient, logger });
        }
    }
}
