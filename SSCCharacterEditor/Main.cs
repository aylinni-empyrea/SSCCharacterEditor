using System;
using System.Linq;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using TShockAPI.Hooks;
using WireToggleEvent;
using static WireToggleEvent.WireToggleEvent;

namespace SSCCharacterEditor
{
	[ApiVersion(2, 00)]
	public class SSCCharacterEditor : TerrariaPlugin
	{
		#region Plugin Info

		public override string Name => "SSCCharacterEditor";
		public override string Description => "Uses SSC and ingame wires to modify a character";
		public override string Author => "Newy";
		public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

		#endregion

		#region Init / Dispose

		public SSCCharacterEditor(Main game) : base(game)
		{
		}

		public override void Initialize()
		{
				CEConfig = Config.Read();
				GeneralHooks.ReloadEvent += OnReload;
				HitSwitch += OnHitSwitch;
		}

		protected override void Dispose(bool disposing)
		{
			GeneralHooks.ReloadEvent -= OnReload;
			HitSwitch -= OnHitSwitch;
			base.Dispose(disposing);
		}

		#endregion

		public static Config CEConfig;

		private static void OnReload(ReloadEventArgs e)
		{
			try
			{
				CEConfig = Config.Read();
			}
			catch (Exception ex)
			{
				e.Player.SendErrorMessage(
					"An error occurred while reloading SSCCharacterEditor configuration. Check server logs for details.");
				TShock.Log.Error(ex.Message);
			}
		}

		private static void OnHitSwitch(WireToggleEventArgs e)
		{
			var match = CEConfig.Presets.Find(p => p.TogglePoints.Contains(e.Position));

			match?.Apply(e.Player);
		}
	}
}