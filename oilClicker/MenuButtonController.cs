using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public GameObject menuPanel; // ������ �� ������ ����

    private bool isMenuActive = false; // ���� ��������� ���� (�������/�������)

    // ����� ��� ������������ ����
    public void ToggleMenu()
    {
        if (menuPanel == null)
        {
            Debug.LogError("Menu Panel �� �������� � ����������!");
            return;
        }

        isMenuActive = !isMenuActive; // ����������� ����
        menuPanel.SetActive(isMenuActive); // �������� ��� ��������� ����

        // ��������� ������ ����
        Time.timeScale = isMenuActive ? 0f : 1f;

        Debug.Log("���� " + (isMenuActive ? "�������" : "�������"));
    }
}
