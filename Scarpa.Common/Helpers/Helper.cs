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
        private const string celular = "celular";
        private const string token = "token";

        private static readonly bool _boolDefault = false;
        private static readonly string _stringDefault = string.Empty;
        public static string Token 
        { 
            get => AppSettings.GetValueOrDefault(token,_stringDefault); 
            set => AppSettings.AddOrUpdateValue(token,value); 
        }
        public static string Celular 
        { 
            get => AppSettings.GetValueOrDefault(celular, _stringDefault); 
            set => AppSettings.AddOrUpdateValue(celular, value); 
        }
        public static bool Configurado
        {
            get => AppSettings.GetValueOrDefault(configurado, _boolDefault);
            set => AppSettings.AddOrUpdateValue(configurado, value);
        }

    }
}
