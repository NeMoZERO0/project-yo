using UnityEngine;
using UnityEngine.UI;

public class OilPerSecondUpgradeButton : MonoBehaviour
{
    public OilClicker oilClicker; // Ссылка на OilClicker
    public int upgradeCost = 500; // Стоимость улучшения
    public float oilPerSecondIncrease = 1f; // Прирост нефти в секунду

    public Text buttonText; // Текст на кнопке
    public Button upgradeButton; // Кнопка

    void Start()
    {
        UpdateButtonState();
    }

    void UpdateButtonState()
    {
        if (!oilClicker.isAutoOilPurchased) // Проверка состояния флага
        {
            upgradeButton.interactable = false; // Блокируем кнопку
            buttonText.text = "Купите автосбор нефти!";
        }
        else
        {
            upgradeButton.interactable = true; // Разблокируем кнопку
            UpdateButtonText();
        }
    }

    void UpdateButtonText()
    {
        buttonText.text = $"+{oilPerSecondIncrease} нефти/сек. {upgradeCost} нефти";
    }

    public void OnUpgradeClick()
    {
        if (oilClicker.oilAmount >= upgradeCost && oilClicker.isAutoOilPurchased)
        {
            oilClicker.oilAmount -= upgradeCost;           // Списываем стоимость
            oilClicker.oilPerSecond += oilPerSecondIncrease; // Увеличиваем нефть в секунду

            upgradeCost = Mathf.CeilToInt(upgradeCost * 1.5f); // Увеличиваем стоимость
            oilPerSecondIncrease += 10f;                     // Увеличиваем прирост

            UpdateButtonText();
            oilClicker.UpdateOilText();
        }
    }

    void Update()
    {
        UpdateButtonState(); // Постоянно проверяем состояние кнопки
    }
}
