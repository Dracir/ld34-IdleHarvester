using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class QuantityUpgradeComponent : PComponent
{
	public Plant Plant;
	public UpgradeStage UpgradeStage;
	[Space()]

	public float QuantityChanceUpgradePerStep;
	public string DoneText = "Complete";
	public string InProgressTextFormat = "{0} % Chance";

	public void OnUpgrade()
	{
		if (UpgradeStage.IsComplete)
		{
			Plant.BaseSpawnQuantity++;
			Plant.chanceForOneMoreSpawn -= (UpgradeStage.NbStages - 1) * QuantityChanceUpgradePerStep;
			UpgradeStage.CurrentLevelDescription = DoneText;
		}
		else
		{
			Plant.chanceForOneMoreSpawn += QuantityChanceUpgradePerStep;
			int percentChance = (int)Mathf.Round(QuantityChanceUpgradePerStep * 100);
			UpgradeStage.CurrentLevelDescription = string.Format(InProgressTextFormat, percentChance);
		}

	}

}
