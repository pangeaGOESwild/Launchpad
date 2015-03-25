using System;
using System.Net;

namespace Launchpad_Launcher
{
	/// <summary>
	/// Anonymous stat sending handler.
	/// </summary>
	public sealed class StatsHandler
	{
		/// <summary>
		/// The config handler reference.
		/// </summary>
		ConfigHandler Config = ConfigHandler._instance;

		/// <summary>
		/// Initializes a new instance of the <see cref="Launchpad_Launcher.StatsHandler"/> class.
		/// </summary>
		public StatsHandler ()
		{

		}

		/// <summary>
		/// Sends the useage stats.
		/// </summary>
		/// <param name="guid">GUID.</param>
		/// <param name="version">Version.</param>
		/// <param name="gameName">Game name.</param>
		/// <param name="officialUpdates">If set to <c>true</c> official updates.</param>
		public void SendUseageStats()
		{
			try
			{
				string baseURL = "http://directorate.asuscomm.com/launchpad/stats.php?";
				string formattedURL = String.Format(baseURL + "guid={0}&launcherVersion={1}&gameName={2}&officialUpdates={3}",
				                                    Config.GetGUID(),
				                                    Config.GetLocalLauncherVersion(),
				                                    Config.GetGameName(),
				                                    Config.GetDoOfficialUpdates().ToString()
				                                    );

				WebRequest getRequest;
				getRequest = WebRequest.Create(formattedURL);
				getRequest.GetResponse();
                getRequest.Abort();                
			}
			catch (Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}
	}
}
