using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SyncPOS.Properties
{
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    [CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = (Settings)SettingsBase.Synchronized((SettingsBase)new Settings());

        public static Settings Default
        {
            get
            {
                Settings defaultInstance = Settings.defaultInstance;
                return defaultInstance;
            }
        }

        /// <summary>cadena original que apunta al servidor
        /// /[DefaultSettingValue("Data Source=(local);Initial Catalog=pos_admin;User ID=sa;Password=Plaza15")]
        /// </summary>
        [DefaultSettingValue("Data Source=LAPTOP-CVOMG1OH;Initial Catalog=pos_admin;User ID=sa;Password=Sistemas410")]
        [SpecialSetting(SpecialSetting.ConnectionString)]
        [DebuggerNonUserCode]
        [ApplicationScopedSetting]
        public string pos_adminConnectionString => (string)this[nameof(pos_adminConnectionString)];
    }
}