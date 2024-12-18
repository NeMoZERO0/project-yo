using UnityEngine;
using UnityEngine.UI;

public class OilPerSecondUpgradeButton : MonoBehaviour
{
    public OilClicker oilClicker; // ������ �� OilClicker
    public int upgradeCost = 500; // ��������� ���������
    public float oilPerSecondIncrease = 1f; // ������� ����� � �������

    public Text buttonText; // ����� �� ������
    public Button upgradeButton; // ������

    void Start()
    {
        UpdateButtonState();
    }

    void UpdateButtonState()
    {
        if (!oilClicker.isAutoOilPurchased) // �������� ��������� �����
        {
            upgradeButton.interactable = false; // ��������� ������
            buttonText.text = "������ �������� �����!";
        }
        else
        {
            upgradeButton.interactable = true; // ������������ ������
            UpdateButtonText();
        }
    }

    void UpdateButtonText()
    {
        buttonText.text = $"+{oilPerSecondIncrease} �����/���. {upgradeCost} �����";
    }

    public void OnUpgradeClick()
    {
        if (oilClicker.oilAmount >= upgradeCost && oilClicker.isAutoOilPurchased)
        {
            oilClicker.oilAmount -= upgradeCost;           // ��������� ���������
            oilClicker.oilPerSecond += oilPerSecondIncrease; // ����������� ����� � �������

            upgradeCost = Mathf.CeilToInt(upgradeCost * 1.5f); // ����������� ���������
            oilPerSecondIncrease += 10f;                     // ����������� �������

            UpdateButtonText();
            oilClicker.UpdateOilText();
        }
    }

    void Update()
    {
        UpdateButtonState(); // ��������� ��������� ��������� ������
    }
}
