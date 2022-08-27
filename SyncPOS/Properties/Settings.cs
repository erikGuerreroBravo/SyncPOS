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

        [DefaultSettingValue("Data Source=(local);Initial Catalog=pos_admin;User ID=sa;Password=Plaza15")]
        [SpecialSetting(SpecialSetting.ConnectionString)]
        [DebuggerNonUserCode]
        [ApplicationScopedSetting]
        public string pos_adminConnectionString => (string)this[nameof(pos_adminConnectionString)];
    }
}