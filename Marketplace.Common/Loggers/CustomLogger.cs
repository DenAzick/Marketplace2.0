using Microsoft.Extensions.Configuration;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Common.Loggers
{
    public class CustomLogger
    {
        public static Serilog.Core.Logger WriteLogToFileSendToTelegram(IConfiguration configuration, string fileName = "logger.txt")
        {
            var botToken = configuration["ConnectionToTelegram:Bot_Token"]!;
            var chatId = long.Parse(configuration["ConnectionToTelegram:MY_ChatID"]!);

            var logger = new LoggerConfiguration()
                .WriteTo.File($@"Loggers\{fileName}", LogEventLevel.Error)
                .WriteTo.Telegram(botToken, chatId.ToString(), restrictedToMinimumLevel: LogEventLevel.Error)
                .CreateLogger();

            return logger;
        }
    }
}
