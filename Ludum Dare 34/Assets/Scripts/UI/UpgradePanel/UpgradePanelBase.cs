using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;

public abstract class UpgradePanelBase : MonoBehaviour
{
	public UpgradeStage Upgrade;
	public long RessourceAmount
	{
		get { return GetRessourceAmount(); }
		set { SetRessourceAmount(value); }
	}

	protected abstract long GetRessourceAmount();
	protected abstract long SetRessourceAmount(long value);
}
