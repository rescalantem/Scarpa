using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Scarpa.Common.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        private const string configurado = "configurado";
        private const string celular = "celular";
        private const string token = "token";
        private const string usuario = "usuario";
        private const string hostapi = "hostapi";
        private const string nombreUsr = "nombreUsr";

        private static readonly bool _boolDefault = false;
        private static readonly string _stringDefault = string.Empty;
        public static string NombreUsr
        {
            get => AppSettings.GetValueOrDefault(nombreUsr, _stringDefault);
            set => AppSettings.AddOrUpdateValue(nombreUsr, value);
        }
        public static string HostApi
        {
            get => AppSettings.GetValueOrDefault(hostapi, _stringDefault);
            set => AppSettings.AddOrUpdateValue(hostapi, value);
        }
        public static string Usuario
        {
            get => AppSettings.GetValueOrDefault(usuario, _stringDefault);
            set => AppSettings.AddOrUpdateValue(usuario, value);
        }
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
