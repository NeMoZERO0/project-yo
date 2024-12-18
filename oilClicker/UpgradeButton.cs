using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    // ������ �� OilClicker, ����� �������� ������ � ����� � ���������
    public OilClicker oilClicker;

    // ���� ���������
    public int upgradeCost = 50;

    // ������ �� UI ��������
    public Text buttonText;
    public Text oilText;

    void Start()
    {
        // �������������� UI ��� ������
        UpdateUI();
    }

    // ����� ��� ���������� UI ������
    void UpdateUI()
    {
        // ��������� ����� �� ������ � ������� ����� ���������
        buttonText.text = $"+1 � ����� �����. {upgradeCost} �����";

        // ��������� �����, ������������ ���������� �����
        oilText.text = $"�����: {oilClicker.oilAmount}";
    }

    // ����� ��� ��������� ������
    public void OnUpgradeClick()
    {
        // ���������, ������� �� ����� ��� ������� ���������
        if (oilClicker.oilAmount >= upgradeCost)
        {
            // ��������� ����� �� ���������
            oilClicker.oilAmount -= upgradeCost;

            // ����������� ��������� ������
            oilClicker.clickMultiplier += 1f;

            // ����������� ���� ���������� ���������
            upgradeCost += 20;

            // ��������� UI ����� �������
            UpdateUI();
        }
        else
        {
            Debug.Log("�� ������� ����� ��� ������� ���������!");
        }
    }
}
