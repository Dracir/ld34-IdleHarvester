using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using UnityEngine.UI;
public class MenuPanel : MonoBehaviour
{
	public UISkinColors Skin;
	[Space()]
	public Button FarmButton;
	[Space()]
	public RectTransform UpgradePanel;
	public Button UpgradeButton;

	void Start()
	{
		ShowFarmPanel();
	}
	public void ShowUpgradePanel()
	{
		HideAll();
		Skin.Select(UpgradeButton);
		UpgradePanel.gameObject.SetActive(true);
	}

	public void ShowFarmPanel()
	{
		HideAll();
		Skin.Select(FarmButton);
	}

	public void HideAll()
	{
		UpgradePanel.gameObject.SetActive(false);
		Skin.Enabled(UpgradeButton);
		Skin.Enabled(FarmButton);
	}
}
