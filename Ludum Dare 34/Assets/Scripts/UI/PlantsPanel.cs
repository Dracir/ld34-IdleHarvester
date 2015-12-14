using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using UnityEngine.UI;

public class PlantsPanel : MonoBehaviour
{
	public UISkinColors skin;


	public SelectedPlant PlayerPlantSelection;
	public PlantPrefabs PlantPrefabs;
	[Space()]
	public Button YellowPlantButton;

	public void SelectYellowPlant()
	{
		YellowPlantButton.GetComponent<Image>().color = skin.SelectedButtonBackground;
		PlayerPlantSelection.Plant = PlantPrefabs.YellowFlower;
	}


	void Update()
	{

	}
}
