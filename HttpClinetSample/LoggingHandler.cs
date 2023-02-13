using System.Diagnostics;

namespace HttpClinetSample
{
    public class LoggingHandler : DelegatingHandler
    {

        private readonly ILogger<LoggingHandler> _logger;
        private readonly Stopwatch _stopwatch = new();

        public LoggingHandler(ILogger<LoggingHandler> logger)
        {
            _logger = logger;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("sending request to GitHub");
            _stopwatch.Start();
            var ressponse = base.SendAsync(request, cancellationToken);
            _stopwatch.Stop();
            _logger.LogInformation($"Request completed in {_stopwatch.ElapsedMilliseconds} ms");
            _stopwatch.Reset();

            return ressponse;
        }
    }
}
