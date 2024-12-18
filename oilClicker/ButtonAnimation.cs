using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale; // Исходный размер кнопки
    public float scaleFactor = 1.1f; // Во сколько раз увеличивать размер кнопки
    public float animationSpeed = 10f; // Скорость анимации

    void Start()
    {
        originalScale = transform.localScale; // Сохраняем исходный размер кнопки
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Увеличиваем кнопку
        StopAllCoroutines();
        StartCoroutine(ScaleButton(originalScale * scaleFactor));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Возвращаем кнопку к исходному размеру
        StopAllCoroutines();
        StartCoroutine(ScaleButton(originalScale));
    }

    private System.Collections.IEnumerator ScaleButton(Vector3 targetScale)
    {
        // Анимируем масштаб кнопки
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * animationSpeed);
            yield return null;
        }

        transform.localScale = targetScale; // Финальный размер кнопки
    }
}
