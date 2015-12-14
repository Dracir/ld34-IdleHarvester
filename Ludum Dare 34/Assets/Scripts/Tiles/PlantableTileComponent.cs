using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;

public class PlantableTileComponent : PComponent
{

	[Disable]
	public Plant PlantOnTile;
	void OnMouseUp()
	{
		if (PlantOnTile == null)
		{
			PEntity player = EntityManager.GetEntityGroup(EntityGroups.Player).Entities[0];
			Money money = player.GetComponent<Money>();
			Plant selectedPlant = player.GetComponent<SelectedPlant>().Plant;
			if (selectedPlant)
			{
				long selectedPlantCost = selectedPlant.GetComponent<Money>().Amount;
				if (money.CanBuy(selectedPlantCost))
				{
					money.Buy(selectedPlantCost);
					PlantOnTile = GameObject.Instantiate(selectedPlant.gameObject).GetComponent<Plant>();
					PlantOnTile.Seed(this);
				}
			}

		}

	}

	public void PickedUp()
	{
		PlantOnTile = null;
	}

	void OnMouseOver()
	{
		Plant selectedPlant = getSelectedPlant();
		if (!PlantOnTile && selectedPlant != null)
		{
			PEntity hoverThing = EntityManager.GetEntityGroup(EntityGroups.UI).Filter(typeof(PreviewTileComponent)).Entities[0];
			SpriteRenderer hoverSprite = hoverThing.GetComponent<SpriteRenderer>();
			hoverSprite.sprite = selectedPlant.FullSizeSprite;
			hoverThing.transform.position = this.transform.position;
			hoverSprite.enabled = true;
		}
	}

	void OnMouseExit()
	{
		PEntity hoverThing = EntityManager.GetEntityGroup(EntityGroups.UI).Filter(typeof(PreviewTileComponent)).Entities[0];
		SpriteRenderer hoverSprite = hoverThing.GetComponent<SpriteRenderer>();
		hoverSprite.enabled = false;
	}

	private Plant getSelectedPlant()
	{
		PEntity player = EntityManager.GetEntityGroup(EntityGroups.Player).Entities[0];
		return player.GetComponent<SelectedPlant>().Plant;
	}

	void Awake()
	{

	}

	void Update()
	{

	}
}
