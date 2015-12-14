using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;

public class Money : PComponent
{
	public long Amount;

	public bool CanBuy(long cost)
	{
		return Amount >= cost;
	}

	public void Buy(long cost)
	{
		this.Amount -= cost;
	}

	public void Gain(long profit)
	{
		this.Amount += profit;
	}
}


