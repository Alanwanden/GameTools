using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weather_Controller : MonoBehaviour
{
    States currentStates;
    public Button sunny, rainy, snowy, nýght, day;
    // Start is called before the first frame update
    void Start()
    {
        currentStates = new Sunny();
    }

    // Update is called once per frame
    void Update()
    {
        currentStates = currentStates.Procces();
    }
    
}