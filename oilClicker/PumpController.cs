using UnityEngine;

public class PumpController : MonoBehaviour
{
    private Animator animator;         // ������ �� Animator
    private float lastClickTime = 0f;  // ����� ���������� �����
    public float stopDelay = 1f;       // ����� �� ��������� �������� ����� ���������� �����
    private bool isAnimating = false;  // ���� ���������� ��������

    void Start()
    {
        animator = GetComponent<Animator>(); // �������� Animator
    }

    void Update()
    {
        // ���������, ������ �� ����� � ������� ���������� �����
        if (isAnimating && Time.time - lastClickTime > stopDelay)
        {
            isAnimating = false; // ������������� ��������
            animator.SetBool("IsRunning", false);
        }
    }

    public void OnClick()
    {
        lastClickTime = Time.time; // ��������� ����� ���������� �����

        // ���� �������� �� ��������, ��������� �
        if (!isAnimating)
        {
            isAnimating = true;
            animator.SetBool("IsRunning", true);
        }
        // ���� �������� ��� ���, ������ �� ������ � ���� `IsRunning` ������� true
    }
}
