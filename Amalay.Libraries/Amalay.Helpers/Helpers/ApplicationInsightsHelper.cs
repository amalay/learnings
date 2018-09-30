using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Amalay.Helpers
{
    public class ApplicationInsightsHelper
    {
        #region "Singleton Intance"

        private static readonly ApplicationInsightsHelper _Instance = new ApplicationInsightsHelper();

        private ApplicationInsightsHelper()
        {
            this.InstrumentationKey = ConfigurationManager.AppSettings["InstrumentationKey"];
        }

        public ApplicationInsightsHelper(string instrumentationKey)
        {
            this.InstrumentationKey = instrumentationKey;
        }

        #endregion

        #region "Properties"

        public static ApplicationInsightsHelper Instance
        {
            get
            {
                return _Instance;
            }
        }

        public string InstrumentationKey { get; set; }

        #endregion

        private Microsoft.ApplicationInsights.TelemetryClient _telemetryClient = null;
        private Microsoft.ApplicationInsights.TelemetryClient TelemetryClient
        {
            get
            {
                if (this._telemetryClient == null && !string.IsNullOrEmpty(this.InstrumentationKey))
                {
                    this._telemetryClient = new Microsoft.ApplicationInsights.TelemetryClient();
                    this._telemetryClient.InstrumentationKey = this.InstrumentationKey;
                }

                return this._telemetryClient;
            }
        }

        /// <summary>
        /// Method to log exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="applicationName"></param>
        /// <param name="moduleName"></param>
        /// <param name="sourceFileName"></param>
        /// <param name="sourceMethodName"></param>
        /// <param name="additionalMessage"></param>
        /// <param name="workflowName"></param>
        /// <param name="logAsync"></param>
        public void LogException(Exception exception, string applicationName, string moduleName, string sourceFileName, string sourceMethodName, string additionalMessage = null, string workflowName = null, bool logAsync = true)
        {
            try
            {
                if (exception != null && this.TelemetryClient != null)
                {
                    IDictionary<string, string> telemetryProperties = new Dictionary<string, string>();

                    if (!string.IsNullOrEmpty(applicationName))
                    {
                        telemetryProperties.Add("ApplicationName", applicationName);
                    }

                    if (!string.IsNullOrEmpty(moduleName))
                    {
                        telemetryProperties.Add("ModuleName", moduleName);
                    }

                    if (!string.IsNullOrEmpty(workflowName))
                    {
                        telemetryProperties.Add("WorkFlow", workflowName);
                        telemetryProperties.Add("BridgeName", workflowName);
                    }

                    if (!string.IsNullOrEmpty(sourceFileName))
                    {
                        telemetryProperties.Add("SourceFileName", sourceFileName);
                    }

                    if (!string.IsNullOrEmpty(sourceMethodName))
                    {
                        telemetryProperties.Add("SourceMethodName", sourceMethodName);
                    }

                    if (!string.IsNullOrEmpty(additionalMessage))
                    {
                        telemetryProperties.Add("AdditionalMessage", additionalMessage);
                    }

                    if (logAsync)
                    {
                        Task.Factory.StartNew(() => this.TelemetryClient.TrackException(exception, telemetryProperties));
                    }
                    else
                    {
                        this.TelemetryClient.TrackException(exception, telemetryProperties);
                    }
                }
            }
            catch (Exception ex)
            {
                this.TelemetryClient.TrackException(ex);
            }
        }

        /// <summary>
        /// Method to log exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="telemetryProperties"></param>
        /// <param name="telemetryMetrics"></param>
        /// <param name="logAsync"></param>
        public void LogException(Exception exception, IDictionary<string, string> telemetryProperties = null, IDictionary<string, double> telemetryMetrics = null, bool logAsync = true)
        {
            try
            {
                if (exception != null && !string.IsNullOrEmpty(exception.Message) && this.TelemetryClient != null)
                {
                    if (logAsync)
                    {
                        Task.Factory.StartNew(() => this.TelemetryClient.TrackException(exception, telemetryProperties, telemetryMetrics));
                    }
                    else
                    {
                        this.TelemetryClient.TrackException(exception, telemetryProperties, telemetryMetrics);
                    }
                }
            }
            catch (Exception ex)
            {
                this.TelemetryClient.TrackException(ex);
            }
        }

        /// <summary>
        /// Method to log trace.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="applicationName"></param>
        /// <param name="moduleName"></param>
        /// <param name="sourceFileName"></param>
        /// <param name="sourceMethodName"></param>
        /// <param name="workflowName"></param>
        /// <param name="logAsync"></param>
        public void LogTrace(string message, string applicationName, string moduleName, string sourceFileName, string sourceMethodName, string workflowName = null, bool logAsync = true)
        {
            if (!string.IsNullOrEmpty(message) && this.TelemetryClient != null)
            {
                try
                {
                    IDictionary<string, string> telemetryProperties = new Dictionary<string, string>();

                    if (!string.IsNullOrEmpty(applicationName))
                    {
                        telemetryProperties.Add("ApplicationName", applicationName);
                    }

                    if (!string.IsNullOrEmpty(moduleName))
                    {
                        telemetryProperties.Add("ModuleName", moduleName);
                    }

                    if (!string.IsNullOrEmpty(workflowName))
                    {
                        telemetryProperties.Add("WorkFlow", workflowName);
                        telemetryProperties.Add("BridgeName", workflowName);
                    }

                    if (!string.IsNullOrEmpty(sourceFileName))
                    {
                        telemetryProperties.Add("SourceFileName", sourceFileName);
                    }

                    if (!string.IsNullOrEmpty(sourceMethodName))
                    {
                        telemetryProperties.Add("SourceMethodName", sourceMethodName);
                    }

                    if (logAsync)
                    {
                        Task.Factory.StartNew(() => this.TelemetryClient.TrackTrace(message, telemetryProperties));
                    }
                    else
                    {
                        this.TelemetryClient.TrackTrace(message, telemetryProperties);
                    }
                }
                catch (Exception ex)
                {
                    this.TelemetryClient.TrackException(ex);
                }
            }
        }

        /// <summary>
        /// Method to log trace.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="telemetryProperties"></param>
        /// <param name="logAsync"></param>
        public void LogTrace(string message, IDictionary<string, string> telemetryProperties = null, bool logAsync = true)
        {
            if (!string.IsNullOrEmpty(message) && this.TelemetryClient != null)
            {
                try
                {
                    if (telemetryProperties != null && telemetryProperties.Count > 0)
                    {
                        if (logAsync)
                        {
                            Task.Factory.StartNew(() => this.TelemetryClient.TrackTrace(message, telemetryProperties));
                        }
                        else
                        {
                            this.TelemetryClient.TrackTrace(message, telemetryProperties);
                        }
                    }
                    else
                    {
                        if (logAsync)
                        {
                            Task.Factory.StartNew(() => this.TelemetryClient.TrackTrace(message));
                        }
                        else
                        {
                            this.TelemetryClient.TrackTrace(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.TelemetryClient.TrackException(ex);
                }
            }
        }
    }
}
