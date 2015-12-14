using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using UnityEngine.UI;

public class PlantPanel : PComponent
{
	public SeedsHarvestedComponent SeedComponent;

	[Space()]
	public Text SeedText;

	void Update()
	{
		SeedText.text = NumberFormater.GetCuteNumber(SeedComponent.Amount);
	}
}
