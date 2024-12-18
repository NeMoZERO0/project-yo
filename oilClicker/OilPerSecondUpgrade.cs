using UnityEngine;
using UnityEngine.UI;

public class OilPerSecondUpgrade : MonoBehaviour
{
    // ������ �� OilClicker
    public OilClicker oilClicker;

    // ��������� ��������� ���������
    public int upgradeCost = 500;

    // ��������, �� ������� ������������� ����� � �������
    public float oilPerSecondIncrease = 10f;

    // ����� �� ������ � ���� ������
    public Text buttonText;
    public Button upgradeButton;

    // ����, ����� ����������� �������
    private bool isPurchased = false;

    void Start()
    {
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (!isPurchased)
        {
            buttonText.text = $"+{oilPerSecondIncrease} �����/���. {upgradeCost} �����";
        }
        else
        {
            buttonText.text = "�������";
            upgradeButton.interactable = false; // ������ ������ ����������
        }
    }

    public void OnUpgradeClick()
    {
        // ���������, ������� �� ����� � �� ������� �� ��� ���������
        if (oilClicker.oilAmount >= upgradeCost && !isPurchased)
        {
            // ��������� ��������� ���������
            oilClicker.oilAmount -= upgradeCost;

            // ����������� ���������� ����� � �������
            oilClicker.oilPerSecond += oilPerSecondIncrease;

            // ��������, ��� ��������� �������
            isPurchased = true;

            // ��������� UI � ������
            UpdateButtonText();
            oilClicker.UpdateOilText();
        }
    }
}
