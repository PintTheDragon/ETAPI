using System.Reflection;
using PluginFramework;

namespace ETAPI.Features
{
    public static class Log
    {
        /// <summary>
        /// Shorthand for info log. Includes assembly name for tag.
        /// </summary>
        /// <param name="message">The message/object to be logged.</param>
        public static void Info(object message) => PluginSystem.Manager.Logger.Info(Assembly.GetCallingAssembly().GetName().Name, message.ToString());
        
        /// <summary>
        /// Shorthand for warn log. Includes assembly name for tag.
        /// </summary>
        /// <param name="message">The message/object to be logged.</param>
        public static void Warn(object message) => PluginSystem.Manager.Logger.Warn(Assembly.GetCallingAssembly().GetName().Name, message.ToString());
        
        /// <summary>
        /// Shorthand for error log. Includes assembly name for tag.
        /// </summary>
        /// <param name="message">The message/object to be logged.</param>
        public static void Error(object message) => PluginSystem.Manager.Logger.Error(Assembly.GetCallingAssembly().GetName().Name, message.ToString());
        
        /// <summary>
        /// Shorthand for debug log. Includes assembly name for tag.
        /// </summary>
        /// <param name="message">The message/object to be logged.</param>
        public static void Debug(object message) => PluginSystem.Manager.Logger.Debug(Assembly.GetCallingAssembly().GetName().Name, message.ToString());
    }
}