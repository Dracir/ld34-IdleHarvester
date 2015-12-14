using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;

public class PlantUpgradePanel : UpgradePanelBase
{
	public SeedsHarvestedComponent PlantSeed;

	protected override long GetRessourceAmount()
	{
		return PlantSeed.Amount;
	}
	protected override long SetRessourceAmount(long value)
	{
		return PlantSeed.Amount = value;
	}
}
