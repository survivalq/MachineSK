namespace MachineSK.Utils
{
    internal class customItem
    {
		public static string giveCommand(string itemType, string itemName, string[] itemLore, string itemNBT)
		{
			string loreText = "";
			foreach (string line in itemLore)
			{
				loreText += $" and '{line}'";
			}

			string giveCommandSkript = $@"";
			if (itemNBT == "")
			{
				giveCommandSkript = $@"
command /autoskript:
	permission: op
	trigger:
		give player 1 {itemType} with name '{itemName}' with lore ''{loreText}
";
			}
			else
			{
				giveCommandSkript = $@"
command /autoskript:
	permission: op
	trigger:
		give player 1 {itemType} with name '{itemName}' with lore ''{loreText} with nbt '{{{itemNBT}}}'
";
			}
			return giveCommandSkript;
		}
		public static string skriptCommand(string eventType, string toolType, string itemName, string[] itemLore, string[] customSkript)
		{
			string loreText = "";
			foreach (string line in itemLore)
			{
				loreText += $" and '{line}'";
			}

			string executeSkript = "";
			foreach (string line in customSkript)
			{
				executeSkript += $"			{line}\n";
			}

			string skriptCommandCode = $@"";
			if (eventType == "Passive")
			{
				skriptCommandCode = $@"
every 1 second:
	loop all players:
		if loop-player´s tool is a {toolType} named '{itemName}' with lore ''{loreText}:
{executeSkript}
";
			}
			if (eventType == "OnDamage")
			{
				skriptCommandCode = $@"
on damage:
	if attacker´s tool is a {toolType} named '{itemName}' with lore ''{loreText}:
{executeSkript}
";
			}
			return skriptCommandCode;
		}
	}
}
