using UnityEngine;
using System.Collections.Generic;
using Pseudo;

[System.Serializable]
public class Harvester
{
	public Plant HarvestingPlant;
	public float HarvestProgress;

	public bool IsHarvesting { get { return HarvestingPlant != null; } }
	public bool Harvest()
	{
		HarvestProgress += TimeManager.Player.DeltaTime;
		if (HarvestProgress >= HarvestingPlant.HarvestTime)
		{
			return true;

		}
		else
		{
			return false;
		}
	}

	public void Clear()
	{
		HarvestingPlant = null;
		HarvestProgress = 0;
	}

}
