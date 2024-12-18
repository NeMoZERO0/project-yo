using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OilClicker : MonoBehaviour
{
    public int oilAmount = 100;            // Количество нефти
    public float clickMultiplier = 1f;     // Множитель нефти за клик
    public float oilPerSecond = 0f;        // Нефть в секунду

    [SerializeField]
    public bool isAutoOilPurchased = false; // Флаг покупки автосбора нефти

    public Text oilText;                   // Текст для отображения нефти
    public Button clickButton;             // Кнопка для клика
    public Button buyAutoOilButton;        // Ссылка на кнопку покупки автосбора
    public Text buyAutoOilButtonText;      // Текст кнопки автосбора

    void Start()
    {
        UpdateOilText();
        clickButton.onClick.AddListener(OnClick);
        StartCoroutine(OilPerSecondCoroutine());
    }

    public void UpdateOilText()
    {
        oilText.text = "Нефть: " + oilAmount;
    }

    public void OnClick()
    {
        oilAmount += Mathf.RoundToInt(clickMultiplier);
        UpdateOilText();
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("OilAmount", oilAmount); // Сохраняем количество нефти
        PlayerPrefs.SetFloat("ClickMultiplier", clickMultiplier); // Сохраняем множитель клика
        PlayerPrefs.SetFloat("OilPerSecond", oilPerSecond); // Сохраняем автосбор
        PlayerPrefs.Save(); // Сохраняем все данные

        Debug.Log("Прогресс сохранён!");
    }


    IEnumerator OilPerSecondCoroutine()
    {
        while (true)
        {
            if (isAutoOilPurchased)
            {
                oilAmount += Mathf.RoundToInt(oilPerSecond);
                UpdateOilText();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void BuyAutoOil(int cost)
    {
        if (oilAmount >= cost && !isAutoOilPurchased)
        {
            oilAmount -= cost;             // Списываем нефть
            isAutoOilPurchased = true;     // Активируем флаг
            oilPerSecond = 10f;             // Задаём базовую нефть в секунду
            UpdateOilText();

            // Блокируем кнопку покупки автосбора
            buyAutoOilButton.interactable = false;
            buyAutoOilButtonText.text = "Автосбор куплен!";

            Debug.Log("Автосбор нефти активирован!");
        }
        else if (isAutoOilPurchased)
        {
            Debug.Log("Автосбор уже куплен!");
        }
        else
        {
            Debug.Log($"Не хватает нефти! Нужно: {cost}, у вас: {oilAmount}");
        }
    }
}
