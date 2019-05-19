using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace AutoOglasiAndroid.Models
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }
        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
        public static string Email
        {
            get => AppSettings.GetValueOrDefault(nameof(Email), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Email), value);
        }
        public static int UserID
        {
            get => AppSettings.GetValueOrDefault(nameof(UserID),0);
            set => AppSettings.AddOrUpdateValue(nameof(UserID), value);
        }

    }
}
