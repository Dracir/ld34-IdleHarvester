using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class DirtTileComponent : PComponent
{
	public long DigCost = 20;
	[Disable]
	public bool Tiled = false;
	public Sprite TiledSprite;

	public override void OnRecycle()
	{

	}

	void Update()
	{

	}

	void OnMouseUp()
	{
		if (!Tiled)
		{
			PEntity player = EntityManager.GetEntityGroup(EntityGroups.Player).Entities[0];
			Money money = player.GetComponent<Money>();
			if (money.CanBuy(DigCost))
			{
				money.Buy(DigCost);
				Entity.AddComponent(typeof(PlantableTileComponent));
				Entity.GetComponent<SpriteRenderer>().sprite = TiledSprite;
				Tiled = true;
			}
		}

	}

	void OnMouseOver()
	{
		if (!Tiled)
		{
			//TODO Changer le curseur

		}
	}
}
