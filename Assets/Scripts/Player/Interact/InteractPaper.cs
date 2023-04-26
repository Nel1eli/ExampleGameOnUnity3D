using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractPaper : MonoBehaviour
{
    [Header("������� ��� ������")]
    [SerializeField] public bool isTrigger;
    [Header("�����")]
    [SerializeField] Image text;
    [Header("����")]
    [SerializeField] AudioSource clip;
    public void Read(bool status)
    {
        text.gameObject.SetActive(status);
        if (status) Time.timeScale = 0.01f;
        else Time.timeScale = 1;
        clip.Play();
            }
}
