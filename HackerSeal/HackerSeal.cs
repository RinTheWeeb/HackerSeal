using HackerSeal.HackerSealPlugin;
using Smod2;
using Smod2.Attributes;
using Smod2.EventHandlers;
using Smod2.Events;

namespace HackerSeal
{
	[PluginDetails(
		author = "Rin",
		name = "HackerSeal",
		description = "Kicks New Steam Accounts from your server",
		id = "rin.HackerSeal.plugin",
		version = "1.1",
		SmodMajor = 3,
		SmodMinor = 2,
		SmodRevision = 2
		)]
	class HackerSeal : Plugin
	{
		public override void OnDisable()
		{
		}

		public override void OnEnable()
		{
			this.Info("HackerSeal has been loaded and ready to seal!");
            //:)
		}

		public override void Register()
		{
			// Register Events
			this.AddEventHandlers(new JoinEventHandler(this));
			// Register config settings
			this.AddConfig(new Smod2.Config.ConfigSetting("hs_enabled", "true", Smod2.Config.SettingType.STRING, true, "Enables Hackerseal"));
			this.AddConfig(new Smod2.Config.ConfigSetting("hs_noban", "true", Smod2.Config.SettingType.STRING, true, "Doesnt ban the player, but kicks them instead"));
			this.AddConfig(new Smod2.Config.ConfigSetting("hs_banduration", 26298000, Smod2.Config.SettingType.NUMERIC, true, "Ban Duration in Minutes. Defaults to 26298000 minutes (=50 years)"));
			this.AddConfig(new Smod2.Config.ConfigSetting("hs_kickmessage", "New Steam accounts are not allowed on this server.", Smod2.Config.SettingType.STRING, true, "The message that will be displayed when a player gets kicked"));
			this.AddConfig(new Smod2.Config.ConfigSetting("hs_banmessage", "New Steam accounts are not allowed on this server. You have been permanently banned.", Smod2.Config.SettingType.STRING, true, "The message that will be displayed when a player gets banned"));
		}
	}
}
