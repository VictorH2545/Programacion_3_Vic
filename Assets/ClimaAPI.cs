using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering.HighDefinition.Attributes;
using SimpleJSON;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class ClimaAPI : MonoBehaviour
{
    [SerializeField] public int currentCountryIndex;

    private string url;

    private static readonly string apiKey = "7fe45acb4f5a69f83c45312aad97613a";

    [SerializeField] public Pais[] paises;

    [SerializeField] public VolumeProfile volumen;
    [SerializeField] public float tiempo;

    public TextMeshProUGUI texto;

    public Light luzMundo;

    [SerializeField] public int paisActual;

    public float nuevoValorLuz;
    public Color nuevoColor;


    private string json;

    private void Start()
    {
        StartCoroutine(RetrieveWhwatherData());
    }

    IEnumerator RetrieveWhwatherData()
    {
        paisActual = numeroRandom();

        url = $"https://api.openweathermap.org/data/3.0/onecall?lat={paises[paisActual].latitud}&lon={paises[paisActual].longitud}&appid={apiKey}&lang=sp&units=metric";

        UnityWebRequest request = new UnityWebRequest(url);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);

            json = request.downloadHandler.text;

            DecodeJson();
            GetColorByTemp();
            TransicionarBloom();
            TransicionarLuz();

        }
        yield return new WaitForSecondsRealtime(20);

        StartCoroutine(RetrieveWhwatherData());
    }

    private Color GetColorByTemp()
    {
        switch (paises[paisActual].temperaturaActual)
        {
            case var color when paises[paisActual].temperaturaActual <= 8:
                {
                    nuevoValorLuz = 4300;
                    nuevoColor = Color.cyan;
                    return nuevoColor;
                }

            case var color when paises[paisActual].temperaturaActual > 8 && paises[paisActual].temperaturaActual < 24:
                {
                    nuevoValorLuz = 5600;
                    nuevoColor = new Color(176, 154, 0);
                    return nuevoColor;
                }

            case var color when paises[paisActual].temperaturaActual > 24 && paises[paisActual].temperaturaActual < 45:
                {
                    nuevoValorLuz = 6900;
                    nuevoColor = new Color(255, 179, 0);
                    return nuevoColor;
                }

            case var color when paises[paisActual].temperaturaActual >= 45:
                {
                    nuevoValorLuz = 8200;
                    nuevoColor = Color.red;
                    return nuevoColor;
                }

            default:
                {
                    return nuevoColor;
                }
        }
    }


    public void TransicionarLuz()
    {
        luzMundo.intensity = Mathf.Lerp(luzMundo.intensity, nuevoValorLuz, tiempo * Time.deltaTime);
    }

    public void TransicionarBloom()
    {
        volumen.TryGet(out Bloom bloom);

        bloom.tint.value = Color.Lerp(bloom.tint.value, nuevoColor, tiempo * Time.deltaTime); 
    }

    public void DecodeJson()
    {
        var weatherJson = JSON.Parse(json);

        paises[paisActual].zonaHoraria = weatherJson["timezone"].Value;
        paises[paisActual].temperaturaActual = float.Parse(weatherJson["current"]["temp"].Value);
        paises[paisActual].velocidadViento = float.Parse(weatherJson["current"]["wind_speed"].Value);
        texto.text = "Escenario de " + paises[paisActual].zonaHoraria + " iniciado";

    }

    public int numeroRandom()
    {
        int numero = Random.Range(0, paises.Length);
        return numero;
    }

    [System.Serializable]
    public class Pais
    {
        [SerializeField] public string nombreDePais;
        [SerializeField] public float latitud;
        [SerializeField] public float longitud;

        [SerializeField] public string zonaHoraria;
        [SerializeField] public float temperaturaActual;
        [SerializeField] public float velocidadViento;
    }
}
