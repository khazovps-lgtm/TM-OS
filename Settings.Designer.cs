using System.ComponentModel;
using System.Configuration;

namespace MyApp.Properties
{
    [SettingsProvider(typeof(LocalFileSettingsProvider))]
    internal sealed partial class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings)(ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("GradientBlue")]
        public string WallpaperType
        {
            get
            {
                return ((string)(this["WallpaperType"]));
            }
            set
            {
                this["WallpaperType"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public string CustomWallpaperPath
        {
            get
            {
                return ((string)(this["CustomWallpaperPath"]));
            }
            set
            {
                this["CustomWallpaperPath"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("25, 25, 35")]
        public Color GradientColor1
        {
            get
            {
                return ((Color)(this["GradientColor1"]));
            }
            set
            {
                this["GradientColor1"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("45, 45, 65")]
        public Color GradientColor2
        {
            get
            {
                return ((Color)(this["GradientColor2"]));
            }
            set
            {
                this["GradientColor2"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Black")]
        public Color SolidColor
        {
            get
            {
                return ((Color)(this["SolidColor"]));
            }
            set
            {
                this["SolidColor"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("True")]
        public bool WindowMaximized
        {
            get
            {
                return ((bool)(this["WindowMaximized"]));
            }
            set
            {
                this["WindowMaximized"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Default")]
        public string CursorType
        {
            get
            {
                return ((string)(this["CursorType"]));
            }
            set
            {
                this["CursorType"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public string CustomCursor1Path
        {
            get
            {
                return ((string)(this["CustomCursor1Path"]));
            }
            set
            {
                this["CustomCursor1Path"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public string CustomCursor2Path
        {
            get
            {
                return ((string)(this["CustomCursor2Path"]));
            }
            set
            {
                this["CustomCursor2Path"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Курсор 1")]
        public string CustomCursor1Name
        {
            get
            {
                return ((string)(this["CustomCursor1Name"]));
            }
            set
            {
                this["CustomCursor1Name"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Курсор 2")]
        public string CustomCursor2Name
        {
            get
            {
                return ((string)(this["CustomCursor2Name"]));
            }
            set
            {
                this["CustomCursor2Name"] = value;
            }
        }
    }
}