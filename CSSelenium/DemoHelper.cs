using System;
using System.Threading;

namespace CSSelenium
{
    /// <summary>
    /// This class is created to pause the execution (for debugging purpose), if needed.
    /// Please NOTE that this is just for debugging and is not recommended to use in actual tests.
    /// </summary>
    public class DemoHelper
    {
        public static void Pause(int sleepTime = 2000)
        {
            Thread.Sleep(sleepTime);
        }
    }
}
