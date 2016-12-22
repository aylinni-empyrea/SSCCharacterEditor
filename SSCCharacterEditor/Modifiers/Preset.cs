using Microsoft.Xna.Framework;
using TShockAPI;
using static SSCCharacterEditor.SSCCharacterEditor;

namespace SSCCharacterEditor.Modifiers
{
	public class Preset
	{
		public string Name { get; protected set; }
		public int Health { get; }
		public int Mana { get; }
		public string InventoryName { get; }
		public Point[] TogglePoints { get; protected set; }

		public Preset(string _name, string _inv, int _hp, int _mp, params Point[] _toggle)
		{
			Name = _name;
			Health = _hp;
			Mana = _mp;
			TogglePoints = _toggle;
			InventoryName = _inv;
		}

		public void Apply(TSPlayer player)
		{
			player.TPlayer.statLifeMax = Health;
			player.TPlayer.statManaMax = Mana;

			player.SendData(PacketTypes.PlayerHp, player.Name, player.Index);
			player.SendData(PacketTypes.PlayerMana, player.Name, player.Index);
			player.SendData(PacketTypes.PlayerUpdate, player.Name, player.Index);

			if (
				!Tools.Database.TryCommit(
					$"UPDATE tsCharacter SET MaxHealth = {Health}, MaxMana = {Mana} WHERE Account = {player.Name};"))
			{
				TShock.Log.Error("An error occurred while applying preset's health variables to the player's database.");
			}

			var inventory = CEConfig.Inventories.Find(p => p.Name == InventoryName);

			inventory?.Apply(player);
		}
	}
}