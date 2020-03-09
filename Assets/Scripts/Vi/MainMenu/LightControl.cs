using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{

    Light light;
    public float flickeringTime = 0.2f;
    public int flickering = 3;
    [SerializeField]
    int currentflicker;
    float currentTimer;
    public bool isFlickering;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if (isFlickering && currentflicker < flickering) {
            if (currentTimer < flickeringTime)
            {
                light.enabled = true;
                currentTimer += Time.deltaTime;
            }
            else {
                light.enabled = false;
                currentflicker += 1;
                currentTimer = 0;
            }
        }
    }
}
