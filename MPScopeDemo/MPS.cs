using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxYCSMPSCOPELib;
using System.Diagnostics;

namespace MPScopeDemo
{
    class MPS
    {
        private static string yeCommUtilPath = @"C:\Program Files (x86)\YASKAWA\MPScope Ver2\Bin\YeCommUtil.exe";
        private static string mpiniFileName = "test.ini";
        private static string mpiniFilePath = "./" + mpiniFileName;

        /// <summary>
        /// 与MP通讯的类实例
        /// </summary>
        public AxMPScope axMPScope1;

        public string errMessage;

        public static bool SetML_static(int nOffset, int val)
        {
            try
            {
                AxMPScope axMPScope2 = new AxMPScope();
                axMPScope2.CreateControl();
                axMPScope2.ConnectFilePath = mpiniFilePath;

                axMPScope2.Open(1);

                axMPScope2.set_ML(nOffset, val);

                axMPScope2.Dispose();

                return true;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                return false;
            }
        }

        public static bool SetMW(int nOffset, short val)
        {
            try
            {
                AxMPScope axMPScope2 = new AxMPScope(); ;
                axMPScope2.CreateControl();
                axMPScope2.ConnectFilePath = mpiniFilePath;

                axMPScope2.Open(1);

                axMPScope2.set_MW(nOffset, val);

                axMPScope2.Dispose();

                return true;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                return false;
            }
        }

        public static bool SetBitStatus(int nOffSet, short nBitOffSet, bool isBit)
        {
            try
            {
                AxMPScope axMPScope = new AxMPScope(); ;
                axMPScope.CreateControl();
                axMPScope.ConnectFilePath = mpiniFilePath;

                axMPScope.Open(1);

                //axMPScope.set_MW(10002, (short)status);
                axMPScope.set_MB(nOffSet, nBitOffSet, isBit);
                //axMPScope.set_MW(10000, (short)kind);
                //axMPScope.set_MW(10001, (short)count);

                axMPScope.Dispose();

                return true;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                return false;
            }
        }
    }
}
