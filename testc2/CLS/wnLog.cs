// Decompiled with JetBrains decompiler
// Type: smartMain.CLS.wnLog
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace smartMain.CLS
{
    public class wnLog
    {
        public const int LOG_ERROR = 100;
        public const int LOG_ERROR_FILE_UPLOAD = 101;
        public const int LOG_ERROR_FILE_DOWN = 102;
        public const int LOG_ANOTHER = 200;
        public const int LOG_QUERY = 300;
        public const int LOG_QUERY_RESULT = 301;
        public const string LOG_ERROR_STRING = "ERROR";
        public const string LOG_ERROR_FILE_UPLOAD_STRING = "ERROR_FUL";
        public const string LOG_ERROR_FILE_DOWN_STRING = "ERROR_FDL";
        public const string LOG_ANOTHER_STRING = "ETC";
        public const string LOG_QUERY_STRING = "QUERY";
        public const string LOG_QUERY_RESULT_STRING = "QUERY_RESULT";
        private const string logFileName = "program.log";
        private const string logDirectory = "Log";
        private const string dToken = "\\";
        public const string LOGSTRING_NO_QUERY = " There is no queryString";

        private static string convertLogTypeToString(int logType)
        {
            switch (logType)
            {
                case 100:
                    return "ERROR";
                case 200:
                    return "ETC";
                case 300:
                    return "QUERY";
                case 301:
                    return "QUERY_RESULT";
                default:
                    return "UNIDENTIFIED LOG";
            }
        }

        private static string getCurrentDirectory() => true ? "c:" : Directory.GetCurrentDirectory();
        //false ? "c:" : Directory.GetCurrentDirectory();

        private static string getFilePathAndName() => dToken + logDirectory + dToken + DateTime.Now.ToString("yyyy-MM-dd") + logFileName;
        //"\\Log\\program.log";

        private static bool checkIsLogFileExit() => new FileInfo(wnLog.getCurrentDirectory() + wnLog.getFilePathAndName()).Exists;

        private static void createFilePath()
        {
            if (Directory.Exists(getCurrentDirectory() + dToken + logDirectory))
                return;
            Directory.CreateDirectory(getCurrentDirectory() + dToken + logDirectory);
        }

        private static bool createLogFile()
        {
            try
            {
                wnLog.createFilePath();
                using (StreamWriter text = File.CreateText(wnLog.getCurrentDirectory() + wnLog.getFilePathAndName()))
                {
                    text.WriteLine("START LOG : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    text.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private static string getDefaultLogLineText(int logType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\r\n");
            stringBuilder.Append(wnLog.convertLogTypeToString(logType));
            stringBuilder.Append(" [");
            stringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            stringBuilder.Append("] ");
            return stringBuilder.ToString();
        }

        public static void writeLog(int logType, SqlParameterCollection pCollection)
        {
            if (true || !wnLog.checkIsLogFileExit() && !wnLog.createLogFile())
                return;
            string path = wnLog.getCurrentDirectory() + wnLog.getFilePathAndName();
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < pCollection.Count; ++index)
            {
                stringBuilder.Append(wnLog.getDefaultLogLineText(logType));
                stringBuilder.Append(pCollection[index].Value.ToString());
            }
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(stringBuilder.ToString());
                streamWriter.Close();
            }
        }

        public static void writeLog(int logType, DataTable dt)
        {
            if (true || !wnLog.checkIsLogFileExit() && !wnLog.createLogFile())
                return;
            string path = wnLog.getCurrentDirectory() + wnLog.getFilePathAndName();
            StringBuilder stringBuilder = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int index = 0; index < dt.Rows.Count; ++index)
                {
                    for (int columnIndex = 0; columnIndex < dt.Columns.Count; ++columnIndex)
                    {
                        stringBuilder.Append(wnLog.getDefaultLogLineText(logType));
                        stringBuilder.Append(dt.Rows[index][columnIndex].ToString().Replace("\r\n", ""));
                    }
                    stringBuilder.Append(wnLog.getDefaultLogLineText(logType));
                    stringBuilder.Append("=========================================================");
                }
            }
            else
            {
                stringBuilder.Append(wnLog.getDefaultLogLineText(logType));
                stringBuilder.Append("0 row has selected");
            }
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(stringBuilder.ToString());
                streamWriter.Close();
            }
        }

        public static void writeLog(int logType, string[] logText)
        {
            if (true || !wnLog.checkIsLogFileExit() && !wnLog.createLogFile())
                return;
            string path = wnLog.getCurrentDirectory() + wnLog.getFilePathAndName();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str in logText)
            {
                stringBuilder.Append(wnLog.getDefaultLogLineText(logType));
                stringBuilder.Append(str);
            }
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(stringBuilder.ToString());
                streamWriter.Close();
            }
        }

        public static void writeLog(int logType, string logText)
        {
#if !DEBUG
                return;
#endif

            if (!wnLog.checkIsLogFileExit() && !wnLog.createLogFile())
                return;
            string path = wnLog.getCurrentDirectory() + wnLog.getFilePathAndName();
            StringBuilder stringBuilder = new StringBuilder();
            string[] separator = new string[1] { "\r\n" };
            foreach (string str in logText.Split(separator, StringSplitOptions.None))
            {
                stringBuilder.Append(wnLog.getDefaultLogLineText(logType));
                stringBuilder.Append(str);
            }
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(stringBuilder.ToString());
                streamWriter.Close();
            }
        }

        public static void writeExLog(Exception ex)
        {
            if (!wnLog.checkIsLogFileExit() && !wnLog.createLogFile())
                return;
            string path = wnLog.getCurrentDirectory() + wnLog.getFilePathAndName();
            StringBuilder stringBuilder = new StringBuilder();
            string str1 = ex.Message + " - " + ex.ToString();
            int logType = 100;
            string[] separator = new string[1] { "\r\n" };
            foreach (string str2 in str1.Split(separator, StringSplitOptions.None))
            {
                stringBuilder.Append(wnLog.getDefaultLogLineText(logType));
                stringBuilder.Append(str2);
            }
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(stringBuilder.ToString());
                streamWriter.Close();
            }
        }
    }
}
