using UnityEngine;

public class PumpController : MonoBehaviour
{
    private Animator animator;         // Ссылка на Animator
    private float lastClickTime = 0f;  // Время последнего клика
    public float stopDelay = 1f;       // Время до остановки анимации после последнего клика
    private bool isAnimating = false;  // Флаг активности анимации

    void Start()
    {
        animator = GetComponent<Animator>(); // Получаем Animator
    }

    void Update()
    {
        // Проверяем, прошло ли время с момента последнего клика
        if (isAnimating && Time.time - lastClickTime > stopDelay)
        {
            isAnimating = false; // Останавливаем анимацию
            animator.SetBool("IsRunning", false);
        }
    }

    public void OnClick()
    {
        lastClickTime = Time.time; // Обновляем время последнего клика

        // Если анимация не запущена, запускаем её
        if (!isAnimating)
        {
            isAnimating = true;
            animator.SetBool("IsRunning", true);
        }
        // Если анимация уже идёт, ничего не делаем — флаг `IsRunning` остаётся true
    }
}
