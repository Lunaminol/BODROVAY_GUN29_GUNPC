using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public Light directionalLight;
    public Color dayLightColor = Color.white;
    public Color nightLightColor = new Color(0.1f, 0.1f, 0.3f);
    public float dayLightIntensity = 1.0f;
    public float nightLightIntensity = 0.3f;

    public void SetDayTime()
    {
        if (directionalLight != null)
        {
            directionalLight.color = dayLightColor;
            directionalLight.intensity = dayLightIntensity;
            RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    public void SetNightTime()
    {
        if (directionalLight != null)
        {
            directionalLight.color = nightLightColor;
            directionalLight.intensity = nightLightIntensity;
            RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.2f);
        }
    }

    [ContextMenu("Set Day")]
    void SetDay() => SetDayTime();

    [ContextMenu("Set Night")]
    void SetNight() => SetNightTime();
}
