﻿namespace WebApplicationCSharp.Service.LogInService
{
    public interface ILoggingService
    {
        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="exception"></param>
        void LogError(Exception exception);
        /// <summary>
        /// Log info
        /// </summary>
        /// <param name="message"></param>
        void LogInfo(string message);


    }
}
