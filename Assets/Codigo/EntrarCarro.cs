using DavidJalbert;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntrarCarro : MonoBehaviour
{
    public TinyCarController carroControlador;
    public Transform carro;
    public Transform ubicacionPersonaje;

    public UnityEvent acercoCarro;
    public UnityEvent alejoCarro;
    public UnityEvent entroCarro;
    public UnityEvent salioCarro;

    private Transform personaje;
    private bool contacto;
    private bool dentroDelCarro;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && carroControlador.getMotor() == 0)
        {
            if (contacto == true && dentroDelCarro == false)
            {
                contacto = false;
                dentroDelCarro = true;
                entroCarro.Invoke();
                personaje.SetParent(carro);
                personaje.gameObject.SetActive(false);
            }
            else if (contacto == false && dentroDelCarro == true)
            {
                dentroDelCarro = false;
                salioCarro.Invoke();
                personaje.SetParent(null);
                personaje.gameObject.SetActive(true);

                personaje.position = ubicacionPersonaje.position;
                personaje.rotation = ubicacionPersonaje.rotation;
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
