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
        /// 开启MP配置界面，同时阻塞现有进程
        /// </summary>
        public void OpenConfigPanelBlocked()
        {
            Process iniSetProces = Process.Start(yeCommUtilPath, mpiniFileName);
            iniSetProces.WaitForExit();
        }

        //MP实力对象公开入口
        public AxMPScope axMPScope1;

        //初始化连接
        public void InitAxMPScope()
        {
            this.axMPScope1 = new AxMPScope();
            this.axMPScope1.CreateControl();
            this.axMPScope1.ConnectFilePath = mpiniFilePath;
        }
        //开启连接--传入1
        public void OpenAxMPScope()
        {
            this.axMPScope1.Open(1);
        }
        //销毁连接
        public void DisposeAxMPScope()
        {
            if (this.axMPScope1 != null)
                this.axMPScope1.Dispose();
        }
        //重新连接--包装上面三个--返回值：true则正确连接/false则无法连接
        public bool ReconnectMPScope()
        {
            try
            {
                DisposeAxMPScope();//断开连接
                InitAxMPScope();//初始化连接
                OpenAxMPScope();//打开连接

                return true;//连接成功
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());

                return false;//连接失败
            }
        }
        //MB寄存器Set --BIT数据/位
        public bool SetMB(bool value)
        {
            try
            {
                //InitAxMPScope();
                //OpenAxMPScope();
                axMPScope1.set_MB(0, 0, value);
                //DisposeAxMPScope();
                return true;
            }
            catch(Exception e)
            {
                Trace.TraceError(e.ToString());
                return false;
            }
            
            
        }
        //MB寄存器Get --BIT数据/位
        public bool GetMB()
        {
            //InitAxMPScope();
            //OpenAxMPScope();
            bool value=axMPScope1.get_MB(0, 0);
            //DisposeAxMPScope();
            return value;
        }
        //ML寄存器Set
        public bool SetML(int value)
        {
            try
            {
                //InitAxMPScope();
                //OpenAxMPScope();
                axMPScope1.set_ML(0, value);
                //DisposeAxMPScope();
                return true;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                return false;
            }
        }
        //ML寄存器Get
        public int GetML()
        {
            //InitAxMPScope();
            //OpenAxMPScope();
            int value = this.axMPScope1.get_ML(0);
            //DisposeAxMPScope();
            return value;
        }
        //MW寄存器Set
        public bool SetMW(int nOffset,short value)
        {
            try
            {
                axMPScope1.set_MW(nOffset, value);
                return true;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                return false;
            }
        }
        //MW寄存器Get
        public short GetMW(int nOffset)
        {
            short value = axMPScope1.get_MW(nOffset);
            return value;
        }
       
    }
}
