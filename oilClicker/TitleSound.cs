using UnityEngine;

public class TitleSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // �������� ��������� AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        // ������������� ����
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource �� ������ �� ������� " + gameObject.name);
        }
    }
}
