using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class PlantStage : PComponent
{
	public float GrowthNeeded;
	public PlantStage nextStage;
	public GameObject Prefab;

	public void Show(GameObject parent)
	{
		foreach (var plantGameObject in parent.GetChildren())
		{
			GameObject newPlant = GameObject.Instantiate(Prefab);
			newPlant.transform.parent = plantGameObject.transform;
			newPlant.transform.localPosition = Vector3.zero;
		}
	}
}
