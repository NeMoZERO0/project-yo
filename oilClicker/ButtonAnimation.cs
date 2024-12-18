using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale; // �������� ������ ������
    public float scaleFactor = 1.1f; // �� ������� ��� ����������� ������ ������
    public float animationSpeed = 10f; // �������� ��������

    void Start()
    {
        originalScale = transform.localScale; // ��������� �������� ������ ������
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ����������� ������
        StopAllCoroutines();
        StartCoroutine(ScaleButton(originalScale * scaleFactor));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ���������� ������ � ��������� �������
        StopAllCoroutines();
        StartCoroutine(ScaleButton(originalScale));
    }

    private System.Collections.IEnumerator ScaleButton(Vector3 targetScale)
    {
        // ��������� ������� ������
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * animationSpeed);
            yield return null;
        }

        transform.localScale = targetScale; // ��������� ������ ������
    }
}
