using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class ActivateComponentUpgradeComponent : PComponent
{
	public PComponent component;

	public void OnUpgrade()
	{
		component.enabled = true;
	}
}
