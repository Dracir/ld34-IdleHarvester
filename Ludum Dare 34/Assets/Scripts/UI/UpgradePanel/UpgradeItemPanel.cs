using UnityEngine;
using System.Collections.Generic;
using Pseudo;
using UnityEngine.UI;

public class UpgradeItemPanel : MonoBehaviour
{
	public UpgradePanelBase UpgradeBase;


	public Text UpgradeTitle;
	public Text UpgradeText;

	public Button UpgradeButton;
	public Text CostText;
	public Text CostTitle;

	public Image UpgradeImage;

	public UpgradeStage UpgradeData { get { return UpgradeBase.Upgrade; } }

	[Button("Refresh", "Refresh")]
	public bool RefreshBtn;
	public void Refresh()
	{
		UpgradeBase = GetComponent<UpgradePanelBase>();
		UpgradeTitle.text = UpgradeData.UpgradeName;
		UpgradeText.text = UpgradeData.CurrentLevelDescription;
		CostText.text = NumberFormater.GetCuteNumber(UpgradeData.CurrentLevelCost);
	}
	void Start()
	{

	}


	public void Upgrade()
	{
		UpgradeBase.RessourceAmount -= UpgradeData.CurrentLevelCost;
		UpgradeData.NextStage();
		if (UpgradeImage)
			UpgradeImage.color = Color.Lerp(new Color(1, 1, 1, 0.1f), new Color(1, 1, 1, 1f), UpgradeData.PourcentageDone);
		UpgradeText.text = UpgradeData.CurrentLevelDescription;
	}


	void Update()
	{
		if (UpgradeData.IsComplete)
		{
			CostText.text = "";
			CostTitle.gameObject.SetActive(false);
			UpgradeButton.gameObject.SetActive(false);
			UpgradeButton.GetComponent<Image>().color = Color.gray;

		}
		else
		{

			CostText.text = NumberFormater.GetCuteNumber(UpgradeData.CurrentLevelCost);
			if (UpgradeData.HaveRequiredUpgrade && UpgradeBase.RessourceAmount >= UpgradeData.CurrentLevelCost)
			{
				UpgradeButton.enabled = true;
				UpgradeButton.GetComponent<Image>().color = Color.white;
			}
			else
			{
				UpgradeButton.enabled = false;
				UpgradeButton.GetComponent<Image>().color = Color.gray;
			}
		}
	}
}
