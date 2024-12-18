using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OilClicker : MonoBehaviour
{
    public int oilAmount = 100;            // ���������� �����
    public float clickMultiplier = 1f;     // ��������� ����� �� ����
    public float oilPerSecond = 0f;        // ����� � �������

    [SerializeField]
    public bool isAutoOilPurchased = false; // ���� ������� ��������� �����

    public Text oilText;                   // ����� ��� ����������� �����
    public Button clickButton;             // ������ ��� �����
    public Button buyAutoOilButton;        // ������ �� ������ ������� ���������
    public Text buyAutoOilButtonText;      // ����� ������ ���������

    void Start()
    {
        UpdateOilText();
        clickButton.onClick.AddListener(OnClick);
        StartCoroutine(OilPerSecondCoroutine());
    }

    public void UpdateOilText()
    {
        oilText.text = "�����: " + oilAmount;
    }

    public void OnClick()
    {
        oilAmount += Mathf.RoundToInt(clickMultiplier);
        UpdateOilText();
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("OilAmount", oilAmount); // ��������� ���������� �����
        PlayerPrefs.SetFloat("ClickMultiplier", clickMultiplier); // ��������� ��������� �����
        PlayerPrefs.SetFloat("OilPerSecond", oilPerSecond); // ��������� ��������
        PlayerPrefs.Save(); // ��������� ��� ������

        Debug.Log("�������� �������!");
    }


    IEnumerator OilPerSecondCoroutine()
    {
        while (true)
        {
            if (isAutoOilPurchased)
            {
                oilAmount += Mathf.RoundToInt(oilPerSecond);
                UpdateOilText();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void BuyAutoOil(int cost)
    {
        if (oilAmount >= cost && !isAutoOilPurchased)
        {
            oilAmount -= cost;             // ��������� �����
            isAutoOilPurchased = true;     // ���������� ����
            oilPerSecond = 10f;             // ����� ������� ����� � �������
            UpdateOilText();

            // ��������� ������ ������� ���������
            buyAutoOilButton.interactable = false;
            buyAutoOilButtonText.text = "�������� ������!";

            Debug.Log("�������� ����� �����������!");
        }
        else if (isAutoOilPurchased)
        {
            Debug.Log("�������� ��� ������!");
        }
        else
        {
            Debug.Log($"�� ������� �����! �����: {cost}, � ���: {oilAmount}");
        }
    }
}
