﻿using System;
using System.IO;
using System.Globalization;

namespace Microsoft.HockeyApp
{
    internal class HockeyConstants
    {

        internal static string GetPathToHockeyCrashes()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (!path.EndsWith("\\", StringComparison.OrdinalIgnoreCase)) { path += "\\"; }
            path += "HockeyApp\\" + HockeyClientWPFExtensions.AppIdHash + "\\";
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            return path;
        }

        internal const string CrashFilePrefix = "crashinfo_";

        internal const string USER_AGENT_STRING = "Hockey/WinWPF";
        internal const string SDKNAME = "HockeySDKWinWPF";

        // ToDo: read sdk version from assembly file.
        internal const string SDKVERSION = "2.2.2"; 

        internal const string NAME_OF_SYSTEM_SEMAPHORE = "HOCKEYAPPSDK_SEMAPHORE";
    }
}