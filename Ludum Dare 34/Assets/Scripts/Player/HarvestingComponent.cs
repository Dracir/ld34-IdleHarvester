using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;

public class HarvestingComponent : PComponent
{
	Money playerMoney;
	public List<Harvester> Harvesters = new List<Harvester>();
	public Queue<Plant> PlantToAddToHarvester = new Queue<Plant>();



	int freeHarvesters;
	int plantsToHarvest;

	public int FreeHarvesterCount { get { return freeHarvesters; } }
	public int PlantsToHarvestCount { get { return plantsToHarvest; } }


	public void AddNewHarvester()
	{
		Harvesters.Add(new Harvester());
		freeHarvesters++;
	}

	protected override void Start()
	{
		playerMoney = EntityManager.GetEntityGroup(EntityGroups.Player).Entities[0].GetComponent<Money>();
		AddNewHarvester();
	}

	void Update()
	{
		while (FreeHarvesterCount > 0 && PlantToAddToHarvester.Count >= 1)
		{
			PutNextFreeHarvesterOn(PlantToAddToHarvester.Dequeue());
		}
		foreach (var harvester in Harvesters)
		{
			if (harvester.IsHarvesting)
			{
				if (harvester.Harvest())
				{
					plantsToHarvest--;
					freeHarvesters++;
					playerMoney.Gain(harvester.HarvestingPlant.Profit);
					harvester.HarvestingPlant.PickedUp();
					harvester.Clear();
				}
			}
		}
	}

	public void PutToHarvest(Plant plant)
	{
		plantsToHarvest++;
		if (freeHarvesters == 0)
			PlantToAddToHarvester.Enqueue(plant);
		else
			PutNextFreeHarvesterOn(plant);
	}

	private void PutNextFreeHarvesterOn(Plant plant)
	{
		Harvester freeHarvester = GetNextFreeHarvester();
		freeHarvester.HarvestingPlant = plant;
		freeHarvesters--;
	}

	private Harvester GetNextFreeHarvester()
	{
		foreach (var harvester in Harvesters)
		{
			if (harvester.HarvestingPlant == null)
			{
				return harvester;
			}
		}
		return null;
	}
}
