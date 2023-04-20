using UnityEngine;

public class InteractRightElevator : MonoBehaviour
{
    public bool isPlay;

    [Header("���� ��� ������� �� ������")]
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
