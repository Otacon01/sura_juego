using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CargarEscena : MonoBehaviour
{
    public GameObject mensajeCarga;

    public void Salir()
    {
        Application.Quit();
    }

    public void Cargar()
    {
        StartCoroutine(CargarAsynchronously(PlayerPrefs.GetString("Escena")));
    }

    public void Cargar(string valor)
    {
        StartCoroutine(CargarAsynchronously(valor));
    }

    IEnumerator CargarAsynchronously(string valor)
    {
        mensajeCarga.SetActive(true);
        AsyncOperation operacion = SceneManager.LoadSceneAsync(valor);

        while (!operacion.isDone)
        {
            yield return null;
        }
    }
    public void CambiarEstado(string valor)
    {
        PlayerPrefs.SetString("Estado", valor);
    }
}
