using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SkySettingsFactory))]
public class SkyBoxManager : MonoBehaviour{
    [SerializeField] private Material skyboxMaterial;
    private Color topColor { get { return skyboxMaterial.GetColor("_TopColor"); } set { skyboxMaterial.SetColor("_TopColor", value); } }
    private Color botColor { get { return skyboxMaterial.GetColor("_BotColor"); } set { skyboxMaterial.SetColor("_BotColor", value); } }
    private float power { get { return skyboxMaterial.GetFloat("_power"); } set { skyboxMaterial.SetFloat("_power", value); } }
    private float starVisibility { get { return skyboxMaterial.GetFloat("_StarVisibility"); } set { skyboxMaterial.SetFloat("_StarVisibility", value); } }

    private SkySettingsFactory skySettingsFactory;


    private void Start(){
        skySettingsFactory = GetComponent<SkySettingsFactory>();
    }
    public void StopChanges(){
        StopAllCoroutines();
    }


    public void ChangeSkyBox(BiomeType type){
        SkyBoxSettings sky = skySettingsFactory.GetSkyBoxOfType(type);
        StartCoroutine(ChangeTopColor(sky.TopColor, 3f));
        StartCoroutine(ChangeBotColor(sky.BotColor, 3f));
        ChangeDayNightCycle(sky.IsDay);
        ChangeStarVisibility(sky.IsStarsVisible);
    }
    public void ChangeSkyBox(SkyBoxSettings sky){
        StartCoroutine(ChangeTopColor(sky.TopColor, 3f));
        StartCoroutine(ChangeBotColor(sky.BotColor, 3f));
        ChangeDayNightCycle(sky.IsDay);
        ChangeStarVisibility(sky.IsStarsVisible);
    }
    private void ChangeDayNightCycle(bool isDay){
        if (isDay){
            StartCoroutine(ChangePower(power, 0.0f, 3f));
            return;
        }
        StartCoroutine(ChangePower(power, 1.85f, 3f));
    }
    
    private void ChangeStarVisibility(bool isStarVisible){
        if (isStarVisible){
            StartCoroutine(ChangeVisibility(starVisibility, 30.0f, 3f));
            return;
        }
        StartCoroutine(ChangeVisibility(starVisibility, 600.0f, 3f));
    }

    IEnumerator ChangePower(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            power = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        power = v_end;
    }

    IEnumerator ChangeVisibility(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            starVisibility = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        starVisibility = v_end;
    }

    IEnumerator ChangeTopColor(Color v_end, float duration)
    {
        Color startColor = topColor;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            topColor = Color.Lerp(startColor, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        topColor = v_end;
    }

    IEnumerator ChangeBotColor(Color v_end, float duration)
    {
        Color startColor = botColor;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            botColor = Color.Lerp(startColor, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        botColor = v_end;
    }
}
