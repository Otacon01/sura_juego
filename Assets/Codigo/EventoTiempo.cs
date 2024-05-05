using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventoTiempo : MonoBehaviour
{
    public float tiempoDuracion;
    public float tiempo;
    public bool comenzar = false;
    public UnityEvent comienzo;
    public UnityEvent finalizacion;

    private void Start()
    {
        comienzo.Invoke();
    }
    private void Update()
    {
        if (comenzar)
        {
            if (tiempo < tiempoDuracion)
            {
                tiempo += Time.deltaTime;
            }
            else {
                comenzar = false;
                tiempo = 0;
                finalizacion.Invoke();
            }
        }
    }

    public float Tiempo
    {
        get { return tiempo; }
        set { tiempo = value; }
    }

}
