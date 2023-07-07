using System;
using System.IO;

namespace MyLogger
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerManager();
            logger.Information("Clicking on Save button", "INFO"); // Acceptance test
            
            // ANSWER TASK 1.1
            // NOTE: Path for file log was not implement as paremeter in function because as a best practice at moment to deploy projects or automation 
            // frameworks we should define where all utilities and files(reports, logs, etc) should be saved to avoid problems or exceptions when code or 
            // automated tests are run on differents envs or deployed with pipelines on testing envs in CI/CT.

            // COMMENTED TEST SCENARIOS
            // logger.Information("Clicking on Save button", "INFO"); // Acceptance test
            // logger.Information("Erron on Save button", "WARNING"); // Acceptance test
            // logger.Information("Clicking on Generate Button", "INFO"); // Functional test
            // logger.Information("Warning at moment to save file", "WARNING"); // Functional test
            // logger.Information("Erron at moment to save file", "ERROR"); // Functional test
            // logger.Information("", "WARNING"); // Functional test
            // logger.Information("", ""); // Functional test
            // logger.Information("Erron at moment to save file", ""); // Functional test
            // logger.Information("Erron at moment to save file", string.Empty); // Functional test
            // logger.Information(string.Empty, "ERROR"); // Functional test
            // logger.Information(11111111112222222222222, "INFO"); // Negative test for Message Parameter
            // logger.Information("Clicking Exit button", ERROR); // Negative test for Level Parameter
            // logger.Information(11111111112222222222222, 4564); // Negative test
            // logger.Information(12.5, 4.5); // Negative test for parameters
            // logger.Information("Clicking Exit button", false); // Negative test for Level Parameter
            // logger.Information("Clicking Exit button", true); // Negative test for Level Parameter
            // logger.Information(true, "ERROR"); // Negative test for Message Parameter
            // logger.Information(false, "ERROR"); // Negative test for Message Parameter
            // logger.Information(true, false); // Negative test for parameters
            // logger.Information(true, true); // Negative test for parameters
            // logger.Information(false, true); // Negative test for parameters
            // logger.Information(false, false); // Negative test for parameters
            // logger.Information("Clicking ###^^^%%&^*(&*(&$#))", "INFO"); // Negative test for parameters
            // logger.Information("Clicking exit button", "WARNING $$$$$$%^^^&&&***(())**"); // Negative test for parameters
            // logger.Information("1231547894651324658798787987987897", "INFO"); // Testing Boundary for Message Parameter
            // logger.Information("Click Button", "WARNINGGGGGGGGGGGGGGGG"); // Testing Boundary for Level Parameter

        }
    }

    public sealed class LoggerManager
    {
        private static string LoggerReportPath = Directory.GetCurrentDirectory();
        const string loggerFileName = @"application.log";
        string fullPath = Path.Combine(LoggerReportPath, loggerFileName);

        public LoggerManager()
        {
            if (!File.Exists(fullPath))
            {
                FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Close();
            }
        }

        public void Information(string message, string level)
        {     
            var date = DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            string customTemplate = $"[{date}][{level}] {message}";

            using(StreamWriter sw = File.AppendText(fullPath))
            {
                sw.WriteLine(customTemplate);
                sw.Flush();
                sw.Close();
            }            
        }

        private static LoggerManager _logger;
        public static LoggerManager Instance => _logger ?? (_logger = new LoggerManager());
    } 
}