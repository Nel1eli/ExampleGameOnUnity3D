using UnityEngine;
using UnityEngine.UI;

public class InteractPlayer : MonoBehaviour
{
    
    [SerializeField] private Image crosshair;
    [SerializeField] private Image _image;
    [SerializeField] private Camera _camera;
    private Ray _ray;
    private RaycastHit _hit;
    public static bool statusRead = false;

    [SerializeField] private float _distance;
    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }
    private void Ray()
    {
        _ray = _camera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
    }

    private void DrawRay()
    {
        if(Physics.Raycast(_ray, out _hit, _distance))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.blue);
        }

        if(_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.red);
        }
    }

    private void Interact()
    {
        bool isObjectSerialze = false;
        if (_hit.transform != null && Time.timeScale != 0)
        {
            _image.gameObject.SetActive(true);
            crosshair.gameObject.SetActive(false);

            if (_hit.transform.GetComponent<InteractDoor>())
            {
                isObjectSerialze = true;
                Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.green);

                if (Input.GetMouseButtonDown(0))
                {
                    _hit.transform.GetComponent<InteractDoor>().InteractWithDoor();

                }
            }

            if (_hit.transform.GetComponent<InteractLeftElevator>())
            {
                if (!_hit.transform.GetComponent<InteractLeftElevator>().isCall)
                {
                    isObjectSerialze = true;
                    Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.green);
                    if (Input.GetMouseButtonDown(0))
                    {
                        _hit.transform.GetComponent<InteractLeftElevator>().isCall = true;
                    }
                }
            }

            if (_hit.transform.GetComponent<InteractRightElevator>())
            {
                if (!_hit.transform.GetComponent<InteractRightElevator>().isPlay)
                {
                    isObjectSerialze = true;
                    Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.green);

                    if (Input.GetMouseButtonDown(0))
                    {
                        _hit.transform.GetComponent<InteractRightElevator>().isCall = true;
                    }
                } 
            }

            if (_hit.transform.GetComponent<QuestItemTrigger>())
            {
                isObjectSerialze = true;
                Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.green);

                if (Input.GetMouseButtonDown(0))
                {
                    _hit.transform.GetComponent<QuestTaker>().OnTriggerOther();
                    _hit.transform.transform.gameObject.SetActive(false);
                   
                }
            }

            if (_hit.transform.GetComponent<InteractPaper>() || statusRead)
            {
                isObjectSerialze = true;
                Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.green);
                if (Input.GetMouseButtonDown(0))
                {
                    statusRead = !statusRead;

                    bool isTrigger = _hit.transform.GetComponent<InteractPaper>().isTrigger;
                    Debug.Log(!statusRead);
                    if (!statusRead && isTrigger)
                    {
                        _hit.transform.GetComponent<QuestTaker>().OnTriggerOther();
                    }

                    _hit.transform.GetComponent<InteractPaper>().Read(statusRead);
                    crosshair.gameObject.SetActive(!statusRead);
                }
            }
        }

        if (statusRead)
        {
            _image.gameObject.SetActive(false);
            crosshair.gameObject.SetActive(false);
        }

        else if (!isObjectSerialze)
        {
            _image.gameObject.SetActive(false);
            crosshair.gameObject.SetActive(true);
        }

        
    }
}
