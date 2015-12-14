using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using UnityEngine.UI;

public class PlayerDataUI : MonoBehaviour
{
	Money PlayerMoney;
	HarvestingComponent Harvesting;

	public Text MoneyText;
	public Text PickerText;
	public Text PlantsToHarvestText;

	void Start()
	{
		PEntity player = EntityManager.GetEntityGroup(EntityGroups.Player).Entities[0];
		PlayerMoney = player.GetComponent<Money>();
		Harvesting = player.GetComponent<HarvestingComponent>();
	}

	void Update()
	{
		MoneyText.text = PlayerMoney.Amount + " $";
		PickerText.text = Harvesting.FreeHarvesterCount + " / " + Harvesting.Harvesters.Count;
		PlantsToHarvestText.text = Harvesting.PlantsToHarvestCount + "";

	}
}
