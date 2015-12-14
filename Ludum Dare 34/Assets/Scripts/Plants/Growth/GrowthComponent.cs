using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;

public class GrowthComponent : PComponent
{
	public float currentStageGrowth;
	public PlantStage currentStage;

	MathComponent mathComponent;
	Plant plant;
	public bool growthDone;

	protected override void Start()
	{
		mathComponent = GetComponent<MathComponent>();
		plant = GetComponent<Plant>();
		currentStage.Show(plant.PlantZone);
	}

	void Update()
	{
		if (!growthDone)
		{
			currentStageGrowth += mathComponent.Calculate(TimeManager.World.DeltaTime);
			if (currentStageGrowth >= currentStage.GrowthNeeded)
			{
				currentStageGrowth = 0;
				plant.RemovePlantsInstances();
				currentStage = currentStage.nextStage;
				currentStage.Show(plant.PlantZone);
				if (currentStage.nextStage == null)
				{
					growthDone = true;
					SendPlantToHarvest();
				}
			}
		}
	}

	private void SendPlantToHarvest()
	{
		PEntity player = EntityManager.GetEntityGroup(EntityGroups.Player).Entities[0];
		HarvestingComponent Harvesting = player.GetComponent<HarvestingComponent>();
		Harvesting.PutToHarvest(plant);
	}
}
