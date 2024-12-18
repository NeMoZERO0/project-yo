using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    // Ссылки на кнопки и панели
    public Button openStoreButton;
    public Button closeStoreButton;
    public GameObject upgradeStorePanel;

    void Start()
    {
        // Скрыть магазин в начале
        upgradeStorePanel.SetActive(false);

        // Настроить кнопки
        openStoreButton.onClick.AddListener(OpenStore);
        closeStoreButton.onClick.AddListener(CloseStore);
    }

    // Открыть магазин
    void OpenStore()
    {
        upgradeStorePanel.SetActive(true);  // Показываем панель магазина
    }

    // Закрыть магазин
    void CloseStore()
    {
        upgradeStorePanel.SetActive(false);  // Прячем панель магазина
    }
}
