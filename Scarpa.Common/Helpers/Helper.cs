using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Scarpa.Common.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        private const string configurado = "configurado";
        private static readonly bool SettingsDefault = false;

        public static bool Configurado
        {
            get => AppSettings.GetValueOrDefault(configurado, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(configurado, value);
        }

    }
}
