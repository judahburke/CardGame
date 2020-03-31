using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Ambit.Services.Product.Extract.Downloader.Test
{
    public abstract class BaseTest
    {
        protected readonly System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();

        protected IConfiguration _config;
        protected IServiceProvider _serviceProvider;
        protected ILoggerFactory _loggerFactory;
        protected ILogger _logger;

        public BaseTest( ITestOutputHelper output )
        {
            _config = new ConfigurationBuilder()
                 //.AddJsonFile( "Properties/testSettings.json" )
                 .Build();

            //https://stackoverflow.com/questions/53690820/how-to-create-a-loggerfactory-with-a-consoleloggerprovider
            IServiceCollection serviceCollection = new ServiceCollection()
                //.AddFabric()
                .AddLogging( builder => builder
                            .ClearProviders()
                            //.AddConsole()
                            .AddFilter( level => level >= LogLevel.Debug )
                            .AddProvider( new TestLoggerProvider(
                                ( _, logLevel ) => logLevel >= LogLevel.Debug, output ) )
                );

            _serviceProvider = serviceCollection.BuildServiceProvider();
            _loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
            _logger = _loggerFactory.CreateLogger<BaseTest>();
            _logger.LogInformation( "Starting tests..." );
        }

        #region Data Modification

        public async Task<bool> PurgeInfoUrlsAsync( int infoId )
        {
            //var parentStructure = await infoId.BuildInfoAsync( _config.GetConnectionString( Catalogs.ERCOTExtracts ) );
            //return await PurgeStructureImportsAsync( parentStructure );
            return await Task.FromResult( true );
        }

        #endregion

        #region Logging
        public class TestLoggerProvider : ILoggerProvider
        {
            private bool _disposed = false;
            private readonly Func<string, LogLevel, bool> _filter;
            private readonly ITestOutputHelper _output;

            public TestLoggerProvider( Func<string, LogLevel, bool> filter, ITestOutputHelper output )
            {
                _filter = filter;
                _output = output;
            }

            public ILogger CreateLogger( string categoryName )
            {
                return new TestLogger( categoryName, _filter, _output );
            }
            public void Dispose()
            {
                Dispose( true );
                GC.SuppressFinalize( this );
            }
            protected virtual void Dispose( bool disposing )
            {
                if ( _disposed ) return;

                if ( disposing )
                {
                    //dispose something
                }

                _disposed = true;

            }
        }

        public class TestLogger : ILogger
        {
            private string _categoryName;
            private Func<string, LogLevel, bool> _filter;
            private ITestOutputHelper _output;

            public TestLogger( string categoryName, Func<string, LogLevel, bool> filter, ITestOutputHelper output )
            {
                _categoryName = categoryName;
                _filter = filter;
                _output = output;
            }

            public void Log<TState>( LogLevel logLevel, EventId eventId, TState state,
                Exception exception, Func<TState, Exception, string> formatter )
            {
                // determine if logging is enabled
                if ( !IsEnabled( logLevel ) ) return;

                // determine message
                if ( formatter == null ) throw new ArgumentNullException( nameof( formatter ), $"No formatter parameter included in Log : {state}" );

                var message = formatter( state, exception );

                if ( String.IsNullOrEmpty( message ) ) return;

                // log to database
                _output.WriteLine( logLevel.ToString() + ":" + eventId.Name + ":" + message + ":" + exception?.StackTrace );

                if ( exception?.InnerException != null ) Log( logLevel, eventId, state, exception.InnerException, formatter );
            }

            public bool IsEnabled( LogLevel logLevel )
            {
                return ( _filter == null || _filter( _categoryName, logLevel ) );
            }

            public IDisposable BeginScope<TState>( TState state )
            {
                return null;
            }
        }
        #endregion
    }
}
