using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace CardGame.Helpers
{
    public static class LogHelper
    {
        public static ColumnOptions GetColumnOptions()
        {
            var options = new ColumnOptions();
            options.Store.Add(StandardColumn.LogEvent);
            options.Store.Remove(StandardColumn.Properties);
            options.Id.ColumnName = "LogId";
            options.LogEvent.ColumnName = "EventJson";
            options.LogEvent.ExcludeAdditionalProperties = true;
            //options.TimeStamp.ColumnName = "CreatedAtDate";
            options.TimeStamp.ConvertToUtc = true;
            //options.AdditionalDataColumns = new System.Data.DataColumn[]
            //{
            //    new DataColumn {ColumnName = "CreatedAtDate" }
            //    new DataColumn { ColumnName = "CreatedByUser" },
            //    new DataColumn { ColumnName = "CreatedByHost" }
            //};
            return options;
        }

        public static void ConfigureLog()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Logger(new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.MSSqlServer(ConnectionStrings.Logging.Connection
                        , ConnectionStrings.Logging.Table, columnOptions:GetColumnOptions())
                    .CreateLogger())
                .WriteTo.Logger(new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Debug()
                    .CreateLogger())
                .CreateLogger();
        }

        public static void Verbose()
        {
            Serilog.Log.Verbose("Testing {LogLevel}", "Verbose");
        }
        public static void Info()
        {
            Serilog.Log.Information("Testing {LogLevel}", "Verbose");
        }
        public static void Error(Exception ex)
        {
            Serilog.Log.Error(ex, "Testing {LogLevel}", "Error");
        }

    }
}
