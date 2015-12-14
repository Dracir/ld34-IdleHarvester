using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class DeactivateComponentUpgradeComponent : PComponent
{
	public PComponent component;

	public void OnUpgrade()
	{
		component.enabled = false;
	}
}
