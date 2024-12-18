using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public GameObject menuPanel; // Ссылка на панель меню

    private bool isMenuActive = false; // Флаг состояния меню (открыто/закрыто)

    // Метод для переключения меню
    public void ToggleMenu()
    {
        if (menuPanel == null)
        {
            Debug.LogError("Menu Panel не привязан в инспекторе!");
            return;
        }

        isMenuActive = !isMenuActive; // Инвертируем флаг
        menuPanel.SetActive(isMenuActive); // Включаем или выключаем меню

        // Управляем паузой игры
        Time.timeScale = isMenuActive ? 0f : 1f;

        Debug.Log("Меню " + (isMenuActive ? "открыто" : "закрыто"));
    }
}
