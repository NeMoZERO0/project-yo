using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // ����� ��� ������� ������� �����
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // ��������� ������� �����
        Debug.Log("�������� ������� �����...");
    }

    // ����� ��� ������ �� ����
    public void QuitGame()
    {
        Debug.Log("����� �� ����...");
        Application.Quit(); // �������� ������ � ��������� ������
    }
}
