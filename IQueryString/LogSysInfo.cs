// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace QueryStringWrapper
{
    public class LogSystemInformation
    {
        #region Win32 API's

        [DllImport("User32.dll")]
        static extern int GetDesktopWindow();

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        [DllImport("User32.dll")]
        static extern int GetWindowDC(int hWnd);

        [DllImport("User32.dll")]
        static extern IntPtr ReleaseDC(int hWnd, IntPtr hDC);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        static extern int GetSystemMetrics(int nIndex);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
        
        private const int LOGPIXELSX = 88;
        private const int LOGPIXELSY = 90;
        private const int SM_DIGITIZER = 94;

        #endregion Win32 API's

        #region Structures

        public struct Processor
        {
            public String Name;
            public uint CurrentClockSpeed;
            public String Architecture;
        }

        public struct MachineHardwareStruct
        {
            public String Manufacturer;
            public String Model;
            public String Type;
            public String BiosVersion;
            public Processor[] Processors;
        }

        public struct OperatingSystemStruct
        {
            public string BuildNumber;
            public string BuildType;
            public string Caption;
            public string CSDVersion;
            public bool Debug;
            public String Description;
            public String Locale;
            public uint MajorVersion;
            public String Manufacturer;
            public uint MinorVersion;
            public String Name;
            public uint OperatingSystemSKU;
            public uint OSLanguage;
            public uint OSProductSuite;
            public ushort OSType;
            public string OtherTypeDescription;
            public ushort ServicePackMajorVersion;
            public ushort ServicePackMinorVersion;
            public uint SuiteMask;
            public string Version;
        }

        public struct OperatingSystemConfigStruct
        {
            public String MachineHardware;
            public String Domain;
            public string LoggedOnUser;
            public string MachineName;
            public bool HighContrast;
            public string ThemeFileName;
            public string ThemeColor;
            public string ThemeThemeSize;
            public Single DpiX;
            public Single DpiY;
            public Rectangle PrimaryMonitorMaximizedWindowSize;
            public Rectangle VirtualScreen;
            public bool IsMousePresent;
            public bool IsPenWindows;
            public bool IsTabletServiceStarted;
            public string VisualStylesAuthor;
            public string VisualStylesColorScheme;
            public string VisualStylesCompany;
            public string VisualStylesDescription;
            public string VisualStylesDisplayName;
            public bool VisualStylesIsEnabledByUser;
            public bool VisualStylesIsSupportedByOS;
            public string VisualStylesVersion;
            public bool DwmIsCompositionEnabled;
        }

        #endregion Structures

        #region Variable declarations

        private OperatingSystemStruct _operatingSystem;
        private MachineHardwareStruct _machineHardware;
        private OperatingSystemConfigStruct _operatingSystemConfig;

        #endregion Variable declarations

        #region Properties

        public OperatingSystemConfigStruct OperatingSystemConfig 
        { 
            get 
            { 
                return _operatingSystemConfig; 
            } 
            set 
            { 
                _operatingSystemConfig = value; 
            } 
        }
        
        public OperatingSystemStruct OperatingSystem 
        { 
            get 
            { 
                return _operatingSystem; 
            } 
            set 
            { 
                _operatingSystem = value; 
            } 
        }
        
        public MachineHardwareStruct MachineHardware 
        { 
            get 
            { 
                return _machineHardware; 
            } 
            set 
            { 
                _machineHardware = value; 
            } 
        }

        #endregion

        public LogSystemInformation()
        {
            this.Get("127.0.0.1", null, null);
        }

        private void Get(String host, String username, String password)
        {
            // No blank username's allowed.
            if (username == "")
            {
                username = null;
                password = null;
            }

            // Configure the connection settings.
            ConnectionOptions options = new ConnectionOptions();
            options.Username = username;
            options.Password = password;
            ManagementPath path = new ManagementPath(String.Format("\\\\{0}\\root\\cimv2", host));
            ManagementScope scope = new ManagementScope(path, options);

            // Try and connect to the remote (or local) machine.
            scope.Connect();

            // Populate the class.
            GetSystemInformation(scope);
        }

        private void GetSystemInformation(ManagementScope scope)
        {
            this._operatingSystemConfig.LoggedOnUser = Environment.UserName;

            this._operatingSystemConfig.VisualStylesAuthor = VisualStyleInformation.Author;
            this._operatingSystemConfig.VisualStylesColorScheme = VisualStyleInformation.ColorScheme;
            this._operatingSystemConfig.VisualStylesCompany = VisualStyleInformation.Company;
            this._operatingSystemConfig.VisualStylesDescription = VisualStyleInformation.Description;
            this._operatingSystemConfig.VisualStylesDisplayName = VisualStyleInformation.DisplayName;
            this._operatingSystemConfig.VisualStylesIsEnabledByUser = VisualStyleInformation.IsEnabledByUser;
            this._operatingSystemConfig.VisualStylesIsSupportedByOS = VisualStyleInformation.IsSupportedByOS;
            this._operatingSystemConfig.VisualStylesVersion = VisualStyleInformation.Version;
            this._operatingSystemConfig.DwmIsCompositionEnabled = DwmIsCompositionEnabled();

            PropertyInfo[] pi = typeof(SystemInformation).GetProperties();

            for (int piIndex = 0; piIndex < pi.Length; piIndex++)
            {
                switch (pi[piIndex].Name)
                {
                    case "HighContrast":
                        {
                            this._operatingSystemConfig.HighContrast = (bool)pi[piIndex].GetValue(null, null);
                        }
                        break;
                    case "PenWindows":
                        {
                            this._operatingSystemConfig.IsPenWindows = (bool)pi[piIndex].GetValue(null, null);
                        }
                        break;
                    case "MousePresent":
                        {
                            this._operatingSystemConfig.IsMousePresent = (bool)pi[piIndex].GetValue(null, null);
                        }
                        break;
                }
            }

            this._operatingSystemConfig.PrimaryMonitorMaximizedWindowSize = Screen.PrimaryScreen.Bounds;

            this._operatingSystemConfig.VirtualScreen = SystemInformation.VirtualScreen;

            int hWnd = LogSystemInformation.GetDesktopWindow();

            this._operatingSystemConfig.IsTabletServiceStarted = (0 == LogSystemInformation.GetSystemMetrics(SM_DIGITIZER)) ? false : true;

            int hDC = LogSystemInformation.GetWindowDC(hWnd);
            IntPtr hDcPtr = new IntPtr(hDC);

            this._operatingSystemConfig.DpiX = LogSystemInformation.GetDeviceCaps(hDcPtr, LOGPIXELSX);
            this._operatingSystemConfig.DpiY = LogSystemInformation.GetDeviceCaps(hDcPtr, LOGPIXELSY);

            LogSystemInformation.ReleaseDC(hWnd, hDcPtr);

            // Only get the first BIOS in the list. Usually this is all there is.
            foreach (ManagementObject mo in new ManagementClass(scope, new ManagementPath("Win32_BIOS"), null).GetInstances())
            {
                this._machineHardware.BiosVersion = mo["Version"].ToString();

                break;
            }

            foreach (ManagementObject mo in new ManagementClass(scope, new ManagementPath("Win32_OperatingSystem"), null).GetInstances())
            {
                String[] versionNumbers = mo["Version"].ToString().Split(".".ToCharArray());
                
                _operatingSystem.BuildNumber = mo["BuildNumber"] as string;

                if (versionNumbers.Length > 0)
                {
                    _operatingSystem.MajorVersion = uint.Parse(versionNumbers[0] as string);
                }

                if (versionNumbers.Length > 1)
                {
                    _operatingSystem.MinorVersion = uint.Parse(versionNumbers[1] as string);
                }

                _operatingSystem.BuildType = mo["BuildType"] as string;
                _operatingSystem.Caption = mo["Caption"] as string;
                _operatingSystem.CSDVersion = mo["CSDVersion"] as string;
                _operatingSystem.Debug = (bool)mo["Debug"];
                _operatingSystem.Description = mo["Description"] as string;
                _operatingSystem.Locale = mo["Locale"] as string;
                _operatingSystem.Manufacturer = mo["Manufacturer"] as string;
                _operatingSystem.OperatingSystemSKU = (uint)mo["OperatingSystemSKU"];
                _operatingSystem.OSLanguage = (uint)mo["OSLanguage"];
                _operatingSystem.OSProductSuite = (uint)mo["OSProductSuite"];
                _operatingSystem.OSType = (ushort)mo["OSType"];
                _operatingSystem.OtherTypeDescription = mo["OtherTypeDescription"] as string;
                _operatingSystem.ServicePackMajorVersion = (ushort)mo["ServicePackMajorVersion"];
                _operatingSystem.ServicePackMinorVersion = (ushort)mo["ServicePackMinorVersion"];
                _operatingSystem.SuiteMask = (uint)mo["SuiteMask"];
                _operatingSystem.Version = mo["Version"] as string;

                break;
            }

            foreach (ManagementObject mo in new ManagementClass(scope, new ManagementPath("Win32_ComputerSystem"), null).GetInstances())
            {
                this._machineHardware.Manufacturer = mo["Manufacturer"].ToString();
                this._machineHardware.Model = mo["Model"].ToString();
                this._machineHardware.Type = mo["SystemType"].ToString();
                this._operatingSystemConfig.Domain = mo["Domain"].ToString();
                this._operatingSystemConfig.MachineName = Environment.MachineName;

                break;
            }

            ManagementObjectSearcher moSearch = new ManagementObjectSearcher(scope, new ObjectQuery("Select Name, InstallDate, CurrentClockSpeed, Architecture from Win32_Processor"));
            ManagementObjectCollection moReturn = moSearch.Get();

            _machineHardware.Processors = new Processor[moReturn.Count];
            int processorIndex = 0;
            foreach (ManagementObject mo in moReturn)
            {
                _machineHardware.Processors[processorIndex].Name = mo["Name"].ToString().Trim();
                _machineHardware.Processors[processorIndex].Architecture = mo["Architecture"].ToString();
                _machineHardware.Processors[processorIndex].CurrentClockSpeed = uint.Parse(mo["CurrentClockSpeed"].ToString());
                processorIndex++;
            }
        }
    }
}