namespace MachineSK.Utils
{
    internal class customArmor
    {
		public static string giveCommand(string armorType, string armorName, string[] itemLore, string itemNBT, bool isLeather, decimal itemColor)
		{
			string loreText = "";
            foreach (string line in itemLore)
            {
				loreText += $" and '{line}'";
            }

			string armorColor = "";
			if (isLeather == true && itemColor != 0)
            {
				armorColor = "display:{color:" + itemColor + "}";
            }

			string giveCommandSkript = $@"";
			if (itemNBT == "" && isLeather == false)
			{
				giveCommandSkript = $@"
command /autoskript:
	permission: op
	trigger:
		give player 1 {armorType} helmet with name '{armorName} Helmet' with lore ''{loreText}
		give player 1 {armorType} chestplate with name '{armorName} Chestplate' with lore ''{loreText}
		give player 1 {armorType} leggings with name '{armorName} Leggings' with lore ''{loreText}
		give player 1 {armorType} boots with name '{armorName} Boots' with lore ''{loreText}
";
			}
			else if (itemNBT != "" && isLeather == true)
			{
				giveCommandSkript = $@"
command /autoskript:
	permission: op
	trigger:
		give player 1 {armorType} helmet with name '{armorName} Helmet' with lore ''{loreText} with nbt '{{{armorColor},{itemNBT}}}'
		give player 1 {armorType} chestplate with name '{armorName} Chestplate' with lore ''{loreText} with nbt '{{{armorColor},{itemNBT}}}'
		give player 1 {armorType} leggings with name '{armorName} Leggings' with lore ''{loreText} with nbt '{{{armorColor},{itemNBT}}}'
		give player 1 {armorType} boots with name '{armorName} Boots' with lore ''{loreText} with nbt '{{{armorColor},{itemNBT}}}'
";
            }
            else
            {
				giveCommandSkript = $@"
command /autoskript:
	permission: op
	trigger:
		give player 1 {armorType} helmet with name '{armorName} Helmet' with lore ''{loreText} with nbt '{{{itemNBT}}}'
		give player 1 {armorType} chestplate with name '{armorName} Chestplate' with lore ''{loreText} with nbt '{{{itemNBT}}}'
		give player 1 {armorType} leggings with name '{armorName} Leggings' with lore ''{loreText} with nbt '{{{itemNBT}}}'
		give player 1 {armorType} boots with name '{armorName} Boots' with lore ''{loreText} with nbt '{{{itemNBT}}}'
";
			}
			return giveCommandSkript;
		}
		public static string skriptCommand(string eventType, string armorName, string[] customSkript)
		{
			string executeSkript = "";
			foreach (string line in customSkript)
			{
				executeSkript += $"						{line}\n";
			}

			string skriptCommandCode = $@"";
			if (eventType == "Passive")
			{
				skriptCommandCode = $@"
every 1 second:
	loop all players:
		if name of loop-player´s helmet is '{armorName} Helmet':
			if name of loop-player´s chestplate is '{armorName} Chestplate':
				if name of loop-player´s leggings is '{armorName} Leggings':
					if name of loop-player´s boots is '{armorName} Boots':
{executeSkript}
";
			}
			if (eventType == "OnDamage")
			{
				skriptCommandCode = $@"
on damage:
	if name of attacker´s helmet is '{armorName} Helmet':
		if name of attacker´s chestplate is '{armorName} Chestplate':
			if name of attacker´s leggings is '{armorName} Leggings':
				if name of attacker´s boots is '{armorName} Boots':
{executeSkript}
";
			}
			return skriptCommandCode;
		}
	}
}
