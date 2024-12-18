using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    // Ссылка на OilClicker, чтобы получить доступ к нефти и множителю
    public OilClicker oilClicker;

    // Цена улучшения
    public int upgradeCost = 50;

    // Ссылки на UI элементы
    public Text buttonText;
    public Text oilText;

    void Start()
    {
        // Инициализируем UI при старте
        UpdateUI();
    }

    // Метод для обновления UI текста
    void UpdateUI()
    {
        // Обновляем текст на кнопке с текущей ценой улучшения
        buttonText.text = $"+1 к сбору нефти. {upgradeCost} нефти";

        // Обновляем текст, показывающий количество нефти
        oilText.text = $"Нефть: {oilClicker.oilAmount}";
    }

    // Метод для улучшения кликов
    public void OnUpgradeClick()
    {
        // Проверяем, хватает ли нефти для покупки улучшения
        if (oilClicker.oilAmount >= upgradeCost)
        {
            // Списываем нефть за улучшение
            oilClicker.oilAmount -= upgradeCost;

            // Увеличиваем множитель кликов
            oilClicker.clickMultiplier += 1f;

            // Увеличиваем цену следующего улучшения
            upgradeCost += 20;

            // Обновляем UI после покупки
            UpdateUI();
        }
        else
        {
            Debug.Log("Не хватает нефти для покупки улучшения!");
        }
    }
}
