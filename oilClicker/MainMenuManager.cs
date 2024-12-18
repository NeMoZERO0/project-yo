using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Метод для запуска игровой сцены
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Загружаем игровую сцену
        Debug.Log("Загрузка игровой сцены...");
    }

    // Метод для выхода из игры
    public void QuitGame()
    {
        Debug.Log("Выход из игры...");
        Application.Quit(); // Работает только в собранной версии
    }
}
