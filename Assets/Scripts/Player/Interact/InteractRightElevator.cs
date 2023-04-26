using System.Collections;
using UnityEngine;

public class InteractRightElevator : MonoBehaviour
{
    public bool isPlay;
    public bool isCall;

    [Header("����� �����")]
    [SerializeField] private Animator _animatorMain;
    [SerializeField] private Animator _animatorHelp;
    [Header("��������� ��������� �����")]
    [SerializeField] private GameObject _mainStatus;
    [SerializeField] private GameObject status;
    [Header("���� ��� ������� �� ������")]
    [SerializeField] private AudioSource _audio;

    private void Update()
    {
        isPlay = _audio.isPlaying;
        if (isCall && !isPlay) 
            StartCoroutine(CallElevator());
    }
    private IEnumerator CallElevator()

    {
        _audio.Play();
        _animatorMain.SetBool("isCall", isCall);
        _animatorHelp.SetBool("isCall", isCall);
        
        isCall = false;

        yield return new WaitForSeconds(3);

        _animatorMain.SetBool("isEnd", !isCall);
        _animatorHelp.SetBool("isEnd", !isCall);

        _animatorMain.SetBool("isCall", isCall);
        _animatorHelp.SetBool("isCall", isCall);
    }

    public void playMe()
    {
        _audio.Play();
    }
}
