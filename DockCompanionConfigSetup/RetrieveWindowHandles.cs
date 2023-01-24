using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockCompanionConfigSetup
{
    public static class RetrieveWindowHandles
    {
        public static IDictionary<IntPtr, string> WindowList { get; set; }
        public static void GetWindowHandles()
        {
            WindowList = OpenWindowGetter.GetOpenWindows();
            /*foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
            {
                IntPtr handle = window.Key;
                string title = window.Value;

                Console.WriteLine("{0}: {1}", handle, title);
            }*/
        }
    }
}
