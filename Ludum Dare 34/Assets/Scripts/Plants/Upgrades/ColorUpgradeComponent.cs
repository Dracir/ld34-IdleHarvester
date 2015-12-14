using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class ColorUpgradeComponent : PComponent
{
	public SpriteRenderer SpriteUpgraded;

	public UpgradeStage UpgradeStage;
	[Space()]
	public Color ColorFrom;
	public Color ColorTo;

	public void OnUpgrade()
	{
		SpriteUpgraded.color = Color.Lerp(ColorFrom, ColorTo, UpgradeStage.PourcentageDone);
	}
}
