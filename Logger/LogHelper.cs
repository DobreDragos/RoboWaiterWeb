using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net.Core;

namespace Logger
{
    public sealed class LogHelper
    {
        private static readonly Lazy<LogHelper> LazyInstance = new Lazy<LogHelper>(() => new LogHelper());
        private const string LogPatternLayout = "%d [%-5p]:[class:%-40type{1}] [l %5L] - [%m] %n";
        //static initializers are thread-safe

        public static ILog Logger => LazyInstance.Value.InternalLogger;

        private ILog InternalLogger { get; set; }

        public static void SetTestLogger()
        {
            LazyInstance.Value.InternalLogger = new TestLog();
        }

        private LogHelper()
        {

            var hierarchy = (Hierarchy)LogManager.GetRepository();

            var patternLayout = new PatternLayout
            {
                ConversionPattern = LogPatternLayout
            };
            patternLayout.ActivateOptions();

            var roller = new RollingFileAppender
            {
                AppendToFile = true,
                File = $@"RunLog\\{Path.GetFileNameWithoutExtension(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path))}.log",
                Layout = patternLayout,
                MaxSizeRollBackups = 300,
                MaximumFileSize = "1MB",
                RollingStyle = RollingFileAppender.RollingMode.Date,
                StaticLogFileName = true,
                DatePattern = "_yyyy-MM-dd'.log'"
            };
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            var memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
            InternalLogger = LogManager.GetLogger("");
        }
    }
}
