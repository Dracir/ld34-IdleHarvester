using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class MoneyUpgradePanel : UpgradePanelBase
{

	public Money Money;

	protected override long GetRessourceAmount()
	{
		return Money.Amount;
	}
	protected override long SetRessourceAmount(long value)
	{
		return Money.Amount = value;
	}
}
