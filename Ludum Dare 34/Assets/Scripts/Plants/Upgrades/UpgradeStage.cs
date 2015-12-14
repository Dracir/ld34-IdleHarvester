using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;

public class UpgradeStage : PComponent
{

	public int CurrentLevel = 0;

	public UpgradeStageData[] Costs;
	public UpgradeStage RequiresUpgrade;

	public bool IsComplete { get { return CurrentLevel == Costs.Length; } }
	public long CurrentLevelCost { get { return Costs[CurrentLevel].Cost; } }
	public int NbStages { get { return Costs.Length; } }
	public bool HaveRequiredUpgrade
	{
		get
		{
			return (RequiresUpgrade == null) || (RequiresUpgrade.IsComplete && RequiresUpgrade.HaveRequiredUpgrade);
		}
	}

	public string CurrentLevelDescription;

	public float PourcentageDone { get { return 1f * CurrentLevel / Costs.Length; } }



	public string UpgradeName;

	public void NextStage()
	{
		CurrentLevel++;
		Entity.SendMessage(EntityMessages.OnUpgrade);
	}


	[System.Serializable]
	public class UpgradeStageData
	{
		public long Cost;
	}
}



