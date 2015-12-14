using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class AddPickersComponent : PComponent
{
	public HarvestingComponent HarvestingComponent;
	public void OnUpgrade()
	{
		HarvestingComponent.AddNewHarvester();
	}
}
