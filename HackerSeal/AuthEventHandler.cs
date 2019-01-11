using Smod2;
using Smod2.API;
using HackerSeal;
using Smod2.EventHandlers;
using Smod2.Events;
using System.IO;
using System.Net;

namespace HackerSeal.HackerSealPlugin
{
	class JoinEventHandler : IEventHandlerPlayerJoin
	{
		static IConfigFile Config => ConfigManager.Manager.Config;
		private HackerSeal HackerSealPlugin;

		public JoinEventHandler(HackerSeal HackerSealPlugin)
		{
			this.HackerSealPlugin = HackerSealPlugin;
		}

		public void OnPlayerJoin(PlayerJoinEvent ev)
		{
			string html = string.Empty;
			string privacyMessage = "<privacyMessage>";
			string limitedAccount = "<isLimitedAccount>1</isLimitedAccount>";
			string url = @"https://steamcommunity.com/profiles/"+ev.Player.SteamId+"?xml=1";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				html = reader.ReadToEnd();
			}
			bool privacyMessageFound = html.Contains(privacyMessage);
			bool limitedAccountFound = html.Contains(limitedAccount);
			if (privacyMessageFound || limitedAccountFound)
			{
				if (ConfigManager.Manager.Config.GetBoolValue("HackerSeal_noban", true))
				{
					ev.Player.Ban(0, "New Steam accounts are not allowed on this server.");
					HackerSealPlugin.Info("Kicked " + ev.Player.SteamId + " For having a fresh steam account");
				}
				else
				{
					ev.Player.Ban(26298000, "New Steam accounts are not allowed on this server. You have been permanently banned");
					HackerSealPlugin.Info("Permanently Banned " + ev.Player.SteamId + " For having a fresh steam account");
				}
				
			}

		}
	}
}
