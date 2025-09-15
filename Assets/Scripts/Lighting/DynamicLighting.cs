using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLighting : MonoBehaviour
{
    public Light sunLight;
    public float dayDuration = 60f; 
    public Gradient skyColor;
    public Gradient lightColor;
    public Camera mainCamera;

    private float timeOfDay = 0f;

    void Start()
    {
        if (mainCamera != null)
        {
            mainCamera.clearFlags = CameraClearFlags.Nothing;
        }
    }

    void Update()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        timeOfDay %= 1f; 

        UpdateLighting(timeOfDay);
    }

    void UpdateLighting(float time)
    {
        if (sunLight != null)
        {
            float sunAngle = time * 360f;
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(sunAngle, -30f, 0f));

            sunLight.color = lightColor.Evaluate(time);
            sunLight.intensity = Mathf.Clamp01(Mathf.Sin(time * Mathf.PI)) * 1.2f;

            RenderSettings.ambientLight = skyColor.Evaluate(time);
        }
    }

    public void SetTimeOfDay(float time)
    {
        timeOfDay = Mathf.Clamp01(time);
        UpdateLighting(timeOfDay);
    }
}