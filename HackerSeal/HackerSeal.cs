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
		version = "3.0",
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
			this.Info("Config value: " + this.GetConfigString("HackerSeal_enabled"));
		}

		public override void Register()
		{
			// Register Events
			this.AddEventHandlers(new JoinEventHandler(this));
			// Register with priority (need to specify the handler type
			this.AddEventHandler(typeof(IEventHandlerPlayerJoin), new JoinEventHandler(this), Priority.Highest);
			// Register config settings
			this.AddConfig(new Smod2.Config.ConfigSetting("HackerSeal_enabled", "true", Smod2.Config.SettingType.STRING, true, "Enables Hackerseal"));
			this.AddConfig(new Smod2.Config.ConfigSetting("HackerSeal_noban", "true", Smod2.Config.SettingType.STRING, true, "Doesnt ban the player, but kicks them instead"));
		}
	}
}
