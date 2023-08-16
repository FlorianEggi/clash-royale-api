using ClashRoyaleApiBackend.Services;
using log4net;
using log4net.Config;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClashRoyaleApiBackend.Tasks
{
    public class NewPlayerTask : BackgroundService
    {
        private int counter = 0;
        private readonly IServiceProvider _serviceProvider;
        private DateTime lastseen;
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        public NewPlayerTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var before = lastseen;
                var after = GetPlayerLastSeen();
                // Debug.WriteLine($"before => {before.ToString("HH:mm")} - after => {after.ToString("HH:mm")}");
                if(before != after)
                {
                    lastseen = after;
                    var str = $"----- Sebi logged in just now => {lastseen.ToString("HH:mm")}  => running for {5 * counter} Seconds -----";
                    log.Info(str);
                    Debug.WriteLine(str);
                }

                counter++;
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

        private DateTime GetPlayerLastSeen()
        {
            var date = DateTime.UtcNow;
            using (var scope = _serviceProvider.CreateScope())
            {
                var _apiService = scope.ServiceProvider.GetRequiredService<RoyaleAPIService>();
                var lastSeen = _apiService.GetMembersOfClan("200CPP28").Result.items.Where(d => d.name == "sebi").FirstOrDefault().lastSeen;
                date = DateTime.ParseExact(lastSeen, "yyyyMMddTHHmmss.fffZ", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal);
            }
            return date;
        }
    }
}
