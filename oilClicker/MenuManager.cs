using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel; // Панель с игровым меню
    private bool isMenuActive = false;

    void Start()
    {
        menuPanel.SetActive(false); // Скрываем меню при старте
    }

    // Метод для отображения панели меню
    public void ShowMenu()
    {
        isMenuActive = true;
        menuPanel.SetActive(true); // Показываем панель меню
        Time.timeScale = 0f; // Ставим игру на паузу
        Debug.Log("Меню открыто.");
    }

    // Метод для закрытия меню и продолжения игры
    public void ContinueGame()
    {
        isMenuActive = false;
        menuPanel.SetActive(false); // Скрываем панель
        Time.timeScale = 1f; // Возобновляем игру
        Debug.Log("Игра продолжена.");
    }

    // Метод для сохранения прогресса
    public void SaveGame()
    {
        OilClicker oilClicker = FindObjectOfType<OilClicker>(); // Ищем OilClicker
        if (oilClicker != null)
        {
            oilClicker.SaveProgress(); // Вызываем метод сохранения
            Debug.Log("Прогресс сохранён!");
        }
        else
        {
            Debug.LogError("OilClicker не найден! Сохранение невозможно.");
        }
    }

    // Метод для выхода в главное меню
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Возобновляем время
        SceneManager.LoadScene("MainMenu"); // Загружаем главное меню
        Debug.Log("Переход в главное меню.");
    }
}
