using UnityEngine;

public class InteractRightElevator : MonoBehaviour
{
    public bool isPlay;

    [Header("Звук при нажатии на кнопку")]
    [SerializeField] private AudioSource _audio;
    void Update()
    {
        isPlay = _audio.isPlaying;
    }

    public void playMe()
    {
        _audio.Play();
    }
}
