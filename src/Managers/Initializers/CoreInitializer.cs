namespace XWIN.Managers.Initializers
{
    using Core;
    using Handlers;

    public class CoreInitializer
    {
        public LocalzetXRayCore Core { get; private set; }
        
        public void Register()
        {
            Core = new LocalzetXRayCore();
        }

        public void Setup(HandlersManager handlersManager)
        {
            ConfigHandler configHandler = handlersManager.GetHandler<ConfigHandler>();
            SettingsHandler settingsHandler = handlersManager.GetHandler<SettingsHandler>();
            ProxyHandler proxyHandler = handlersManager.GetHandler<ProxyHandler>();
            TunnelHandler tunnelHandler = handlersManager.GetHandler<TunnelHandler>();

            Core.Setup(
                getConfig: configHandler.GetCurrentConfig,
                getMode: settingsHandler.UserSettings.GetMode,
                getProtocol: settingsHandler.UserSettings.GetProtocol,
                getLogLevel: settingsHandler.UserSettings.GetLogLevel,
                getLogPath: settingsHandler.UserSettings.GetLogPath,
                getProxyPort: settingsHandler.UserSettings.GetProxyPort,
                getTunPort: settingsHandler.UserSettings.GetTunPort,
                getTestPort: settingsHandler.UserSettings.GetTestPort,
                getSystemProxyUsed: settingsHandler.UserSettings.GetSystemProxyUsed,
                getUdpEnabled: settingsHandler.UserSettings.GetUdpEnabled,
                getTunIp: settingsHandler.UserSettings.GetTunIp,
                getDns: settingsHandler.UserSettings.GetDns,
                getProxy: proxyHandler.GetProxy,
                getTunnel: tunnelHandler.GetTunnel,
                onFailLoadingConfig: configHandler.RemoveConfigFromList
            );
        }
    }
}