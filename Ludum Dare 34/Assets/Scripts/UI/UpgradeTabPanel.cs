using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using UnityEngine.UI;
using System;

public class UpgradeTabPanel : MonoBehaviour
{
	public UISkinColors skin;
	public GameObject UpgradePanels;

	[Disable]
	public GameObject[] Panels;
	[Disable]
	public Button[] Buttons;
	[Disable]
	public GameObject SelectedPanel;
	[Disable]
	public int SelectedIndex;

	void Start()
	{
		Panels = UpgradePanels.GetChildren();
		Buttons = GetComponentsInChildren<Button>();
		SelectedPanel = Panels[0];
		SelectedIndex = 0;

		foreach (var panels in Panels)
		{
			panels.SetActive(false);
		}
		Select(0);
	}

	public void Select(int index)
	{
		SelectedPanel.SetActive(false);
		skin.Enabled(Buttons[SelectedIndex]);

		SelectedPanel = Panels[index];
		SelectedIndex = index;
		SelectedPanel.SetActive(true);
		skin.Select(Buttons[SelectedIndex]);
	}
}
