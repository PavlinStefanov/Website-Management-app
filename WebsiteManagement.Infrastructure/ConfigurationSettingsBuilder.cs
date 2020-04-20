using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace WebsiteManagement.Infrastructure
{
    public static class ConfigurationSettingsBuilder
    {
        private static readonly string FileName = "appsettings.json";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetExecutionDirectory()
        {
            try
            {
                var settingsFileLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;

                return Path.GetDirectoryName(settingsFileLocation);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get settings file location.", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IConfigurationRoot GetSettingsFile()
        {
            try
            {
                string executionDirectoryPath = GetExecutionDirectory();

                var settingsBuilder = new ConfigurationBuilder()
                    .SetBasePath(executionDirectoryPath)
                    .AddJsonFile(FileName);

                return settingsBuilder.Build();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get {FileName}.", ex);
            }
        }
    }
}
