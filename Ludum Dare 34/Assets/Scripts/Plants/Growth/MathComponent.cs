using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class MathComponent : PComponent
{
	public float BaseFactor;
	public float MultiplicationFactor;


	/// <summary>
	/// (<i>BaseFactor</i> * <i>deltaTime</i>) * <i>MultiplicationFactor</i>
	/// </summary>
	/// <param name="deltaTime"></param>
	/// <returns></returns>
	public float Calculate(float deltaTime)
	{
		return BaseFactor * deltaTime * MultiplicationFactor;

	}
}
