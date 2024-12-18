using UnityEngine;

public class TitleSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        // Воспроизводим звук
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource не найден на объекте " + gameObject.name);
        }
    }
}
