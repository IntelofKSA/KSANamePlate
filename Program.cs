using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/* KSANamePlate
 * 
 * Copyright (c) 2013. Intel of KSA Students Union.
 * 
 * Programmer: Sam Brad Jo
 * 
 * Version: 1.20.0000
 * Date: 2013-12-05
 * 
 * Released Under the MIT License
 */

namespace KSANamePlate
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
