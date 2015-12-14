using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class QualityUpgradeComponent : PComponent
{

	public Plant Plant;
	public UpgradeStage UpgradeStage;
	[Space()]

	public long QualityUpgradePerStep;
	public string DoneText = "CompleteProfit per flower + {0}";
	public string InProgressTextFormat = "Profit per flower + {0}";

	public void OnUpgrade()
	{
		if (UpgradeStage.IsComplete)
		{
			Plant.baseProfit += QualityUpgradePerStep;
			UpgradeStage.CurrentLevelDescription = string.Format(InProgressTextFormat, QualityUpgradePerStep);
		}
		else
		{
			Plant.baseProfit += QualityUpgradePerStep;
			UpgradeStage.CurrentLevelDescription = string.Format(InProgressTextFormat, QualityUpgradePerStep);
		}

	}
}
