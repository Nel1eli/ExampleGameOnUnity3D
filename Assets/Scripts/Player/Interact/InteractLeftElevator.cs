using System.Collections;
using UnityEngine;

public class InteractLeftElevator : MonoBehaviour
{
    public bool isCall;
    [SerializeField] private GameObject _mainStatus;

    [Header("����� �����")]
    [SerializeField] private AudioSource _startElevator;
    [SerializeField] private Animator _animator;
    [Header("���� �������� �����")]
    [SerializeField] private AudioSource _endElevator;
    [Header("��������� ��������� �����")]
    [SerializeField] private GameObject status;

    public void Update()
    {
        if (isCall) CallElevator(); 

    }

    public void CallElevator()
    {
        _startElevator.Play();
        _animator.SetBool("isCall", true);
        status.SetActive(true);

        _mainStatus.SetActive(false);

        _endElevator.Play();
    }
}
