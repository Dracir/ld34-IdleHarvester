using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class DestroyOnPickUp : PComponent
{

	void OnPickUp()
	{
		gameObject.Destroy();
	}
}
