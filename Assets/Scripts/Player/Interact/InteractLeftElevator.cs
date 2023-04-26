using System.Collections;
using UnityEngine;

public class InteractLeftElevator : MonoBehaviour
{
    public bool isCall;
    [SerializeField] private GameObject _mainStatus;

    [Header("Вызов лифта")]
    [SerializeField] private AudioSource _startElevator;
    [SerializeField] private Animator _animatorMain;
    [SerializeField] private Animator _animatorHelp;
    [Header("Звук прибытия лифта")]
    [SerializeField] private AudioSource _endElevator;
    [Header("Следующее состояние лифта")]
    [SerializeField] private GameObject status;
    [Header("Двери лифта")]
    [SerializeField] private Animator elevatorDoor;

    public void Start()
    {
        status.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (isCall)
        {
            _startElevator.Play();
            StartCoroutine(CallElevator());
        }
    }

    public IEnumerator CallElevator()
    {
       
        status.gameObject.SetActive(true);

        _animatorMain.SetBool("isCall", true);

        yield return new WaitForSeconds(1);

        _mainStatus.SetActive(false);

        yield return new WaitForSeconds(5);

        _endElevator.Play();

        elevatorDoor.SetBool("isReady", true);
    }
}
