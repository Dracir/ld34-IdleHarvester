using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using System;
using UnityEngine.UI;

public class UISkinColors : MonoBehaviour
{
	public Color SelectedButtonBackground;

	public void Disable(Button button)
	{
		button.enabled = false;
		button.GetComponent<Image>().color = Color.gray;
	}
	public void Enabled(Button button)
	{
		button.enabled = true;
		button.GetComponent<Image>().color = Color.white;
	}
	public void Select(Button button)
	{
		button.enabled = true;
		button.GetComponent<Image>().color = SelectedButtonBackground;
	}
}
