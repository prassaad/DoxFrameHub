using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Web.Utilities
{
    public static class ExceptionLogger
    {
        /// <summary>
        /// Logs the exception to the file.
        /// Every day new log file be created
        /// </summary>
        /// <param name="exceptionToLog">Exception object refrence</param>
        /// <param name="hostingEnvironment">Hosting environment object reference</param>
        public static void LogException(Exception exceptionToLog, IWebHostEnvironment hostingEnvironment, HttpRequest httpRequest = null)
        {
            StreamWriter writer = null;
            try
            {
                string filePth = Path.Combine(hostingEnvironment.ContentRootPath, "Logs", $"LogFile_{DateTime.UtcNow.ToString("MM_dd_yyyy")}.txt");
                writer = new StreamWriter(filePth, true);
                string error = "Log Written Date : " + DateTime.Now.ToString() + Environment.NewLine;
                error += "Error Name : " + exceptionToLog.GetType().FullName + Environment.NewLine;
                error += "Error Message : " + exceptionToLog.Message + Environment.NewLine;
                error += "Exception Type : " + exceptionToLog.GetType().ToString() + Environment.NewLine;
                error += "Stack trace : " + exceptionToLog?.StackTrace + Environment.NewLine;
                Exception innerEx = null;
                innerEx = exceptionToLog.InnerException;
                while (innerEx != null)
                {
                    error += "Inner Error Message : " + innerEx?.Message + Environment.NewLine;
                    error += "Inner Stack trace : " + innerEx?.StackTrace + Environment.NewLine;
                    innerEx = innerEx.InnerException;
                }
                if (httpRequest != null)
                {
                    error += Environment.NewLine;
                    error += "Request URL : " + httpRequest.Scheme + "://" + httpRequest.Host.ToUriComponent() + httpRequest.PathBase.ToUriComponent() + httpRequest.Path.ToUriComponent() + httpRequest.QueryString.ToUriComponent();
                }

                writer.WriteLine("Log Start");
                writer.WriteLine(error);
                writer.WriteLine("Log End");
                writer.WriteLine(Environment.NewLine);
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                msg = string.Empty;
            }
        }
        public static async Task LogExceptionAsync(Exception exceptionToLog, IWebHostEnvironment hostingEnvironment)
        {
            StreamWriter writer = null;
            try
            {
                string filePth = Path.Combine(hostingEnvironment.ContentRootPath, "Logs", $"LogFile_{DateTime.UtcNow.ToString("MM_dd_yyyy")}.txt");
                writer = new StreamWriter(filePth, true);
                string error = "Log Written Date : " + DateTime.Now.ToString() + Environment.NewLine;
                error += "Error Name : " + exceptionToLog.GetType().FullName + Environment.NewLine;
                error += "Error Message : " + exceptionToLog.Message + Environment.NewLine;
                error += "Exception Type : " + exceptionToLog.GetType().ToString() + Environment.NewLine;
                error += "Stack trace : " + exceptionToLog?.StackTrace + Environment.NewLine;
                Exception innerEx = null;
                innerEx = exceptionToLog.InnerException;
                while (innerEx != null)
                {
                    error += "Inner Error Message : " + innerEx?.Message + Environment.NewLine;
                    error += "Inner Stack trace : " + innerEx?.StackTrace + Environment.NewLine;
                    innerEx = innerEx.InnerException;
                }
                writer.WriteLine("Log Start");
                writer.WriteLine(error);
                writer.WriteLine("Log End");
                writer.WriteLine(Environment.NewLine);
                writer.Flush();
                writer.Close();
                await Task.FromResult(string.Empty);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                msg = string.Empty;
            }
        }
        public static async Task StaticLogExceptionAsync(Exception exceptionToLog)
        {
            StreamWriter writer = null;
            try
            {
                var rootDirectory = AppContext.BaseDirectory;
                rootDirectory = rootDirectory.Contains("bin") ? rootDirectory.Substring(0, rootDirectory.IndexOf("bin")) : rootDirectory;
                string filePth = Path.Combine(rootDirectory, "Logs", $"LogFile_{DateTime.UtcNow.ToString("MM_dd_yyyy")}.txt");
                writer = new StreamWriter(filePth, true);
                string error = "Log Written Date : " + DateTime.Now.ToString() + Environment.NewLine;
                error += "Error Name : " + exceptionToLog.GetType().FullName + Environment.NewLine;
                error += "Error Message : " + exceptionToLog.Message + Environment.NewLine;
                error += "Exception Type : " + exceptionToLog.GetType().ToString() + Environment.NewLine;
                error += "Stack trace : " + exceptionToLog?.StackTrace + Environment.NewLine;
                Exception innerEx = null;
                innerEx = exceptionToLog.InnerException;
                while (innerEx != null)
                {
                    error += "Inner Error Message : " + innerEx?.Message + Environment.NewLine;
                    error += "Inner Stack trace : " + innerEx?.StackTrace + Environment.NewLine;
                    innerEx = innerEx.InnerException;
                }
                writer.WriteLine("Log Start");
                writer.WriteLine(error);
                writer.WriteLine("Log End");
                writer.WriteLine(Environment.NewLine);
                writer.Flush();
                writer.Close();
                await Task.FromResult(string.Empty);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                msg = string.Empty;
            }
        }
        /// <summary>
        /// Write's the error log to Logfile.txt file
        /// </summary>
        /// <param name="msgToWrite">Message to log </param>
        /// <param name="hostingEnvironment">Hosting environment object reference</param>
        public static void LogMessage(string msgToWrite, IWebHostEnvironment hostingEnvironment)
        {
            StreamWriter writer = null;
            try
            {
                string filePth = Path.Combine(hostingEnvironment.ContentRootPath, "Logs", $"LogFile_{DateTime.UtcNow.ToString("MM_dd_yyyy")}.txt");
                writer = new StreamWriter(filePth, true);
                writer.WriteLine("Log Start");
                writer.WriteLine("Log Written Date : " + DateTime.Now.ToString() + Environment.NewLine);
                writer.WriteLine(msgToWrite);
                writer.WriteLine("Log End");
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                msg = string.Empty;
            }
        }
        public static async Task<IEnumerable<ErrorInfo>> GetErrorLog(IWebHostEnvironment hostingEnvironment, int noOfDaysLog = 7)
        {
            var result = new List<ErrorInfo>();
            try
            {
                string filePth = Path.Combine(hostingEnvironment.ContentRootPath, "Logs");
                DirectoryInfo di = new DirectoryInfo(filePth);
                if (di.Exists)
                {

                    var fileList = di.GetFiles().OrderByDescending(g => g.CreationTime).Take(noOfDaysLog).ToList();
                    fileList.ForEach(file =>
                    {
                        var fileContent = File.ReadAllText(file.FullName);
                        if (!string.IsNullOrEmpty(fileContent))
                        {
                            var splitContent = fileContent.Split("Log End").ToList();
                            if (splitContent != null)
                            {
                                var changedContent = splitContent.Where(x => !string.IsNullOrEmpty(x.Trim())).Select(g => new ErrorInfo() { ErrorLogged = g.Trim() }).ToList();
                                if (changedContent != null)
                                    result.AddRange(changedContent);
                            }
                        }
                    });
                }
            }
            catch (Exception)
            {
            }
            return await Task.FromResult(result);
        }
    }
    public class ErrorInfo
    {
        public string ErrorLogged { get; set; }
    }
}
