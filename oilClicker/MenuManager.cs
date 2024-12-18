using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel; // ������ � ������� ����
    private bool isMenuActive = false;

    void Start()
    {
        menuPanel.SetActive(false); // �������� ���� ��� ������
    }

    // ����� ��� ����������� ������ ����
    public void ShowMenu()
    {
        isMenuActive = true;
        menuPanel.SetActive(true); // ���������� ������ ����
        Time.timeScale = 0f; // ������ ���� �� �����
        Debug.Log("���� �������.");
    }

    // ����� ��� �������� ���� � ����������� ����
    public void ContinueGame()
    {
        isMenuActive = false;
        menuPanel.SetActive(false); // �������� ������
        Time.timeScale = 1f; // ������������ ����
        Debug.Log("���� ����������.");
    }

    // ����� ��� ���������� ���������
    public void SaveGame()
    {
        OilClicker oilClicker = FindObjectOfType<OilClicker>(); // ���� OilClicker
        if (oilClicker != null)
        {
            oilClicker.SaveProgress(); // �������� ����� ����������
            Debug.Log("�������� �������!");
        }
        else
        {
            Debug.LogError("OilClicker �� ������! ���������� ����������.");
        }
    }

    // ����� ��� ������ � ������� ����
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // ������������ �����
        SceneManager.LoadScene("MainMenu"); // ��������� ������� ����
        Debug.Log("������� � ������� ����.");
    }
}
