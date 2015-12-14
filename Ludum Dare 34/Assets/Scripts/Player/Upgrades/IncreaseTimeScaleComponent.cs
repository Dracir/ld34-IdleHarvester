using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class IncreaseTimeScaleComponent : PComponent
{
	public TimeManager.TimeChannels TimeChanel;

	public void OnUpgrade()
	{
		TimeManager.GetChannel(TimeChanel).TimeScale++;
	}
}
