using System.Runtime.InteropServices;
using System;

namespace Blu.Shared
{
    public class AC6623
    {
        [DllImport("AC6623.DLL")]
        public static extern IntPtr AC6623_OpenDevice(Int32 dev_num);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_DI(IntPtr hDevice);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_DO(IntPtr hDevice, Int32 data);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_ADV(Int32 adg, Int32 addata);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_CAL(IntPtr hDevice);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_AD(IntPtr hDevice, Int32 ch, Int32 gain, Int32 sidi);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_TAD(IntPtr hDevice, Int32 stch, Int32 endch, Int32 adg, Int32 sidi, Int32 sammode, Int32 trsl, Int32 trpol, Int32 clksl, Int32 clkpol, Int32 tdata);

        [DllImport("AC6623.DLL")]
        unsafe public static extern Int32 AC6623_TAD_Read(IntPtr hDevice, Int32 rdlen, Int32[] addata);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_TAD_Poll(IntPtr hDevice);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_TAD_Stop(IntPtr hDevice);


        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_DA(IntPtr hDevice, Int32 dach, Int32 dadata);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_DA_Mode(IntPtr hHandle, Int32 dag0, Int32 dag1);

        //[DllImport("AC6623.DLL")]
        //public static extern Int32 AC6623_DA_WRun(IntPtr hDevice, Int32 dag0, Int32 dwlen, Int32 dtdata, Int32* dadata);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_DA_WStop(IntPtr hDevice);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_CNT_Run(IntPtr hDevice, Int32 cntch, Int32 cdata);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_CNT_Read(IntPtr hDevice, Int32 cntch, Int32[] cdata, Int32[] tdata);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_PRun(IntPtr hDevice, Int32 pch, Int32 pmode, Int32 pdata0, Int32 pdata1);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_PState(IntPtr hDevice, Int32 pch);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_PSetData(IntPtr hDevice, Int32 pch, Int32 pdata0, Int32 pdata1);

        [DllImport("AC6623.DLL")]
        public static extern Int32 AC6623_PEnd(IntPtr hDevice, Int32 pch);
    }
}