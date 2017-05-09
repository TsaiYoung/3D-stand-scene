using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CompetitionIndice
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();///此方法为应用程序启用可视样式。
                                             ///如果控件和操作系统支持视觉样式，则控件将以视觉样式进行绘制。
            ///简单的说就是让你的控件（包括窗体）显示出来。
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
