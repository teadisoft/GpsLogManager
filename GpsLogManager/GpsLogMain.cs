using System;
using System.Threading;
using System.Windows.Forms;

namespace GpsLogManager
{
    static class GpsLogMain
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //bool isNew = true;
            //Mutex mutex = new Mutex(true, "특정문자열", out isNew);

            //if (isNew == false)
            //{
            //    MessageBox.Show("프로그램이 실행중입니다.");
            //}
            //else
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new GpsLogWriter());
            //    mutex.ReleaseMutex();
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GpsLogWriter());
        }
    }   
}   
