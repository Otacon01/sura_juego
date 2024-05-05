using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VerificarCantidadElementos : MonoBehaviour
{
    public GameObject[] objetos;
    public UnityEvent terminoRecolectar;
    public Text cantidadElementos;
    public int cont;
    public void Verificar()
    {
        int cantidad = 0;
        foreach (GameObject objeto in objetos)
        {
            if (objeto.activeSelf == false)
            {
                cantidad++;
            }
        }
        cont = cantidad;
        cantidadElementos.text = cantidad + "/" + objetos.Length;
        if (cantidad == objetos.Length)
            terminoRecolectar.Invoke();
    }
}
