using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;

public class Plant : PComponent
{
	public Sprite FullSizeSprite;
	public float HarvestTime;
	public PlantableTileComponent TileOn;
	public SeedsHarvestedComponent SeedsHarvestedComponent;
	public GameObject PlantZone;
	public GameObject[] PlantsInstances;

	public int BaseSpawnQuantity = 1;
	public float chanceForOneMoreSpawn = 0;

	public int QuantitySpawned;

	public long baseProfit;

	public long Profit { get { return baseProfit * QuantitySpawned; } }

	public void Seed(PlantableTileComponent tilePlantedOn)
	{
		TileOn = tilePlantedOn;
		transform.position = tilePlantedOn.transform.position;
		transform.parent = tilePlantedOn.transform;
		tilePlantedOn.PlantOnTile = this;

		QuantitySpawned = BaseSpawnQuantity;
		if (PRandom.Range(0, 1) < chanceForOneMoreSpawn)
			QuantitySpawned++;
		PlantsInstances = new GameObject[QuantitySpawned];
		for (int i = 0; i < QuantitySpawned; i++)
		{
			PlantsInstances[i] = new GameObject();
			PlantsInstances[i].transform.parent = PlantZone.GetComponent<Transform>();
			Vector3 NextPosition = FindNextPosition();
			PlantsInstances[i].transform.localPosition = NextPosition;
		}

		GrowthComponent growth = GetComponent<GrowthComponent>();
		growth.enabled = true;
	}

	private Vector3 FindNextPosition()
	{
		int tries = 0;
		Vector3 p = PlantZone.GetComponent<RectZone>().GetRandomLocalPoint();
		while (tries++ < 100 || IsNearOtherPlants(p))
			p = PlantZone.GetComponent<RectZone>().GetRandomLocalPoint();
		return p;
	}

	private bool IsNearOtherPlants(Vector3 p)
	{
		foreach (var item in PlantsInstances)
		{
			if (item != null && Vector3.Distance(p, item.transform.position) < 0.2)
				return true;
		}
		return false;
	}

	internal void RemovePlantsInstances()
	{
		foreach (var instance in PlantsInstances)
		{
			foreach (var child in instance.GetChildren())
			{
				child.Destroy();
			}
		}

	}

	public void OnGrowth()
	{

	}



	public void PickedUp()
	{
		TileOn.PickedUp();
		SeedsHarvestedComponent.Amount += QuantitySpawned;
		Entity.SendMessage(EntityMessages.OnPickUp);
	}
}
