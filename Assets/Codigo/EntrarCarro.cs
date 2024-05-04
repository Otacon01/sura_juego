using DavidJalbert;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntrarCarro : MonoBehaviour
{
    public TinyCarController carroControlador;
    public Transform carro;
    public UnityEvent acercoCarro;
    public UnityEvent alejoCarro;
    public UnityEvent entroCarro;
    public UnityEvent salioCarro;

    private Transform personaje;
    private bool contacto;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && carroControlador.getMotor() == 0)
        {
            if (contacto == true)
            {
                entroCarro.Invoke();
                personaje.SetParent(carro);
                personaje.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Personaje" && contacto == false)
        {
            contacto = true;
            personaje = other.gameObject.transform;
            acercoCarro.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Personaje" && contacto == true)
        {
            contacto = false;
            personaje = null;
            alejoCarro.Invoke();
        }
    }
}
