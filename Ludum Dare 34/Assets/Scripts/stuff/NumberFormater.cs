using UnityEngine;
using System.Collections.Generic;
using Pseudo;

public class NumberFormater
{
	private const long OneK = 1000;
	private const long OneM = OneK * 1000;
	private const long OneG = OneM * 1000;
	private const long OneT = OneG * 1000;

	public static string GetCuteNumber(long value)
	{
		long size = value;
		string suffix = "";
		if (value < OneK)
		{

		}
		else if (value < OneM)
		{
			suffix = "K";
			size = value / OneK;
		}
		else if (value < OneG)
		{
			suffix = "M";
			size = value / OneM;
		}
		else if (value < OneT)
		{
			suffix = "G";
			size = value / OneG;
		}
		else
		{
			suffix = "T";
			size = value / OneT;
		}
		return string.Format("{0}{1}", size, suffix);
	}
}
