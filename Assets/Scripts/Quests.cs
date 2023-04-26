using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Quests : MonoBehaviour
{
    private int positivePoint;
    
    [SerializeField] private Image[] quests;
    [SerializeField] private bool[] statusQuests;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < quests.Length; i++)
            statusQuests[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
