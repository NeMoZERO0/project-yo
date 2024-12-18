using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    // ������ �� ������ � ������
    public Button openStoreButton;
    public Button closeStoreButton;
    public GameObject upgradeStorePanel;

    void Start()
    {
        // ������ ������� � ������
        upgradeStorePanel.SetActive(false);

        // ��������� ������
        openStoreButton.onClick.AddListener(OpenStore);
        closeStoreButton.onClick.AddListener(CloseStore);
    }

    // ������� �������
    void OpenStore()
    {
        upgradeStorePanel.SetActive(true);  // ���������� ������ ��������
    }

    // ������� �������
    void CloseStore()
    {
        upgradeStorePanel.SetActive(false);  // ������ ������ ��������
    }
}
