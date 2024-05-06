using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManejadorJuego : MonoBehaviour
{
    public Text puntajeGlobal;
    public int puntaje;

    public void CalcularPuntaje(int valor)
    {
        puntaje += valor;
        puntajeGlobal.text = puntaje + "";
    }
}
