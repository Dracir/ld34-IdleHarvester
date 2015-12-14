using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class ReplanteOnPickup : PComponent
{

	void OnPickUp()
	{
		Plant plant = Entity.GetComponent<Plant>();
		plant.Seed(plant.TileOn);
	}
}
