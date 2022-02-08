using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using ITNepal.HSIL.Helpers;

namespace ITNepal.HSIL.Log
{
    class Logger
    {
        public const Int16 RTN_SUCCESS = 1;
        public const Int16 RTN_ERROR = 0;
        public const Int16 DEBUG_ON = 1;
        public const Int16 DEBUG_OFF = 0;
        public Int16 p_iErrDispMethod;
        public Int16 p_iDeleteDebugLog;
        public string p_sLogDir;

        private const Int16 MAXFILESIZE_IN_MB = 5;
        private const string LOG_FILE_ERROR = "ErrorLog";
        private const string LOG_FILE_ERROR_ARCH = "ErrorLog_";
        private const string LOG_FILE_DEBUG = "DebugLog";
        private const string LOG_FILE_DEBUG_ARCH = "DebugLog_";
        private const Int16 FILE_SIZE_CHECK_ENABLE = 1;
        private const Int16 FILE_SIZE_CHECK_DISABLE = 0;
        private string sLogPath = ConfigurationManager.AppSettings["sLogPath"].ToString();
        private string sJSONPath = ConfigurationManager.AppSettings["sjsonPath"].ToString();


        public long WriteToLogFile_Debug(string strErrText, string strSourceName, Int16 intCheckFileForDelete = 1)
        {
            long functionReturnValue = 0;

            // **********************************************************************************
            //   Function   :    WriteToLogFile_Debug()
            //   Purpose    :    This function checks if given input file name exists or not
            //
            //   Parameters :    ByVal strErrText As String
            //                       strErrText = Text to be written to the log
            //                   ByVal intLogType As Integer
            //                       intLogType = Log type (1 - Log ; 2 - Error ; 0 - None)
            //                   ByVal strSourceName As String
            //                       strSourceName = Function name calling this function
            //                   Optional ByVal intCheckFileForDelete As Integer
            //                       intCheckFileForDelete = Flag to indicate if file size need to be checked before logging (0 - No check ; 1 - Check)
            //   Return     :    0 - FAILURE
            //                   1 - SUCCESS
            //   Author     :    JOHN
            //   Date       :    MAY 2013
            //   Changes    : 
            //                   
            // **********************************************************************************

            StreamWriter oStreamWriter = null;
            string strFileName = string.Empty;
            string strArchFileName = string.Empty;
            // string strTempString = string.Empty;
            char c = ' ';
            double lngFileSizeInMB = 0;
            int iFileCount = 0;

            try
            {
                strSourceName = strSourceName.PadLeft(40, c);
                strErrText = "[" + string.Format(DateTime.Now.ToString(), "MM_dd_yyyy HH:mm:ss") + "]" + "[" + strSourceName + "] " + strErrText;
                //strFileName = p_sLogDir + "\\" + LOG_FILE_DEBUG + ".log";
                //strArchFileName = p_sLogDir + "\\" + LOG_FILE_DEBUG_ARCH + string.Format(DateTime.Now.ToString(), "yyMMddHHMMss") + ".log";

                string spath;
                //= Path.GetDirectoryName(
                //       Assembly.GetAssembly(typeof(clsCommon)).CodeBase);
                if (string.IsNullOrEmpty(sLogPath))
                {
                    // var directory = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                    spath = GlobalMethods_Variables.sPath; //System.IO.Path.GetDirectoryName(directory);
                }
                else
                {
                    spath = sLogPath;
                }

                //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                strFileName = spath + "\\" + LOG_FILE_DEBUG + ".log";
                // strArchFileName = spath + "\\" + LOG_FILE_DEBUG_ARCH + string.Format(DateTime.Now.ToString(), "yy_MM_dd_HHMMss") + ".log";
                strArchFileName = spath + "\\" + LOG_FILE_DEBUG_ARCH + Convert.ToDateTime(DateTime.Now).ToString("MMM_dd_yyyy_HHmmss") + ".log";

                if (intCheckFileForDelete == FILE_SIZE_CHECK_ENABLE)
                {
                    if (File.Exists(strFileName))
                    {
                        FileInfo fi = new FileInfo(strFileName);

                        lngFileSizeInMB = (fi.Length / 1024) / 1024;

                        if (lngFileSizeInMB >= MAXFILESIZE_IN_MB)
                        {
                            //If intCheckDeleteDebugLog=1 then remove all debug_log file
                            if (p_iDeleteDebugLog == 1)
                            {
                                foreach (string sFileName in Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), LOG_FILE_DEBUG_ARCH + "*"))
                                {
                                    File.Delete(sFileName);
                                }
                            }
                            File.Move(strFileName, strArchFileName);
                        }
                    }
                }
                oStreamWriter = File.AppendText(strFileName);
                oStreamWriter.WriteLine(strErrText);
                functionReturnValue = RTN_SUCCESS;
            }
            catch (Exception exc)
            {
                functionReturnValue = RTN_ERROR;
            }
            finally
            {
                if ((oStreamWriter != null))
                {
                    oStreamWriter.Flush();
                    oStreamWriter.Close();
                    oStreamWriter = null;
                }
            }
            return functionReturnValue;

        }

        public long WriteToLogFile(string strErrText, string strSourceName, Int16 intCheckFileForDelete = 1)
        {
            long functionReturnValue = 0;

            // **********************************************************************************
            //   Function   :    WriteToLogFile()
            //   Purpose    :    This function checks if given input file name exists or not
            //
            //   Parameters :    ByVal strErrText As String
            //                       strErrText = Text to be written to the log
            //                   ByVal intLogType As Integer
            //                       intLogType = Log type (1 - Log ; 2 - Error ; 0 - None)
            //                   ByVal strSourceName As String
            //                       strSourceName = Function name calling this function
            //                   Optional ByVal intCheckFileForDelete As Integer
            //                       intCheckFileForDelete = Flag to indicate if file size need to be checked before logging (0 - No check ; 1 - Check)
            //   Return     :    0 - FAILURE
            //                   1 - SUCCESS
            //   Author     :    JOHN
            //   Date       :    MAY 2014
            // **********************************************************************************

            StreamWriter oStreamWriter = null;
            string strFileName = string.Empty;
            string strArchFileName = string.Empty;
            // string strTempString = string.Empty;
            char c = ' ';
            double lngFileSizeInMB = 0;
            int iFileCount = 0;

            try
            {
                strSourceName = strSourceName.PadLeft(40, c);
                strErrText = "[" + string.Format(DateTime.Now.ToString(), "MM_dd_yyyy HH:mm:ss") + "]" + "[" + strSourceName + "] " + strErrText;
                //strFileName = p_sLogDir + "\\" + LOG_FILE_DEBUG + ".log";
                //strArchFileName = p_sLogDir + "\\" + LOG_FILE_DEBUG_ARCH + string.Format(DateTime.Now.ToString(), "yyMMddHHMMss") + ".log";

                string spath;
                //= Path.GetDirectoryName(
                //       Assembly.GetAssembly(typeof(clsCommon)).CodeBase);
                if (string.IsNullOrEmpty(sLogPath))
                {
                    var directory = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                    spath = System.IO.Path.GetDirectoryName(directory);
                }
                else
                {
                    spath = sLogPath;
                }

                //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                strFileName = spath + "\\" + LOG_FILE_ERROR + ".log";
                // strArchFileName = spath + "\\" + LOG_FILE_DEBUG_ARCH + string.Format(DateTime.Now.ToString(), "yy_MM_dd_HHMMss") + ".log";
                strArchFileName = spath + "\\" + LOG_FILE_ERROR_ARCH + Convert.ToDateTime(DateTime.Now).ToString("MMM_dd_yyyy_HHmmss") + ".log";

                if (intCheckFileForDelete == FILE_SIZE_CHECK_ENABLE)
                {
                    if (File.Exists(strFileName))
                    {
                        FileInfo fi = new FileInfo(strFileName);

                        lngFileSizeInMB = (fi.Length / 1024) / 1024;

                        if (lngFileSizeInMB >= MAXFILESIZE_IN_MB)
                        {
                            //If intCheckDeleteDebugLog=1 then remove all debug_log file
                            if (p_iDeleteDebugLog == 1)
                            {
                                foreach (string sFileName in Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), LOG_FILE_DEBUG_ARCH + "*"))
                                {
                                    File.Delete(sFileName);
                                }
                            }
                            File.Move(strFileName, strArchFileName);
                        }
                    }
                }
                oStreamWriter = File.AppendText(strFileName);
                oStreamWriter.WriteLine(strErrText);
                functionReturnValue = RTN_SUCCESS;
            }
            catch (Exception exc)
            {
                functionReturnValue = RTN_ERROR;
            }
            finally
            {
                if ((oStreamWriter != null))
                {
                    oStreamWriter.Flush();
                    oStreamWriter.Close();
                    oStreamWriter = null;
                }
            }
            return functionReturnValue;

        }

        public long WriteToLogFile_Json(string strErrText, String sFileName)
        {
            long functionReturnValue = 0;

            // **********************************************************************************
            //   Function   :    WriteToLogFile()
            //   Purpose    :    This function checks if given input file name exists or not
            //
            //   Parameters :    ByVal strErrText As String
            //                       strErrText = Text to be written to the log
            //                   ByVal intLogType As Integer
            //                       intLogType = Log type (1 - Log ; 2 - Error ; 0 - None)
            //                   ByVal strSourceName As String
            //                       strSourceName = Function name calling this function
            //                   Optional ByVal intCheckFileForDelete As Integer
            //                       intCheckFileForDelete = Flag to indicate if file size need to be checked before logging (0 - No check ; 1 - Check)
            //   Return     :    0 - FAILURE
            //                   1 - SUCCESS
            //   Author     :    JOHN
            //   Date       :    MAY 2014
            // **********************************************************************************

            StreamWriter oStreamWriter = null;
            string strFileName = string.Empty;
            string strArchFileName = string.Empty;
            // string strTempString = string.Empty;
            double lngFileSizeInMB = 0;
            int iFileCount = 0;
            Int16 intCheckFileForDelete = 1;

            try
            {

                string spath;

                if (string.IsNullOrEmpty(sJSONPath))
                {
                    var directory = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                    spath = System.IO.Path.GetDirectoryName(directory);
                }
                else
                {
                    spath = sJSONPath;
                }

                //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                strFileName = spath + "\\" + sFileName;
                // strArchFileName = spath + "\\" + LOG_FILE_DEBUG_ARCH + string.Format(DateTime.Now.ToString(), "yy_MM_dd_HHMMss") + ".log";
                //  strArchFileName = spath + "\\" + LOG_FILE_ERROR_ARCH + Convert.ToDateTime(DateTime.Now).ToString("MMM_dd_yyyy_HHmmss") + ".log";
                strArchFileName = spath + "\\" + sFileName + "_ARCH" + Convert.ToDateTime(DateTime.Now).ToString("MMM_dd_yyyy_HHmmss") + ".log";

                if (intCheckFileForDelete == FILE_SIZE_CHECK_ENABLE)
                {
                    if (File.Exists(strFileName))
                    {
                        FileInfo fi = new FileInfo(strFileName);

                        lngFileSizeInMB = (fi.Length / 1024) / 1024;

                        if (lngFileSizeInMB >= MAXFILESIZE_IN_MB)
                        {
                            //If intCheckDeleteDebugLog=1 then remove all debug_log file
                            if (p_iDeleteDebugLog == 1)
                            {
                                foreach (string sFileName1 in Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), LOG_FILE_DEBUG_ARCH + "*"))
                                {
                                    File.Delete(sFileName1);
                                }
                            }
                            File.Move(strFileName, strArchFileName);
                        }
                    }
                }
                String sLine = "*****************************************************************************************************************";
                String sStartline = "Port Over on : " + Convert.ToDateTime(DateTime.Now).ToString("MMM_dd_yyyy_HHmmss");
                oStreamWriter = File.AppendText(strFileName);
                oStreamWriter.WriteLine(sLine);
                oStreamWriter.WriteLine(sStartline);
                oStreamWriter.WriteLine(strErrText);
                oStreamWriter.WriteLine(sLine);
                functionReturnValue = RTN_SUCCESS;
            }
            catch (Exception exc)
            {
                functionReturnValue = RTN_ERROR;
            }
            finally
            {
                if ((oStreamWriter != null))
                {
                    oStreamWriter.Flush();
                    oStreamWriter.Close();
                    oStreamWriter = null;
                }
            }
            return functionReturnValue;

        }
    }
}
