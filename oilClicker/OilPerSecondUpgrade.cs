using UnityEngine;
using UnityEngine.UI;

public class OilPerSecondUpgrade : MonoBehaviour
{
    // Ссылка на OilClicker
    public OilClicker oilClicker;

    // Начальная стоимость улучшения
    public int upgradeCost = 500;

    // Значение, на которое увеличивается нефть в секунду
    public float oilPerSecondIncrease = 10f;

    // Текст на кнопке и сама кнопка
    public Text buttonText;
    public Button upgradeButton;

    // Флаг, чтобы отслеживать покупку
    private bool isPurchased = false;

    void Start()
    {
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (!isPurchased)
        {
            buttonText.text = $"+{oilPerSecondIncrease} нефти/сек. {upgradeCost} нефти";
        }
        else
        {
            buttonText.text = "Куплено";
            upgradeButton.interactable = false; // Делаем кнопку неактивной
        }
    }

    public void OnUpgradeClick()
    {
        // Проверяем, хватает ли нефти и не куплено ли уже улучшение
        if (oilClicker.oilAmount >= upgradeCost && !isPurchased)
        {
            // Списываем стоимость улучшения
            oilClicker.oilAmount -= upgradeCost;

            // Увеличиваем количество нефти в секунду
            oilClicker.oilPerSecond += oilPerSecondIncrease;

            // Отмечаем, что улучшение куплено
            isPurchased = true;

            // Обновляем UI и кнопку
            UpdateButtonText();
            oilClicker.UpdateOilText();
        }
    }
}
