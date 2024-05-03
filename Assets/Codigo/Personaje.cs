using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private CharacterController controladorPersonaje;

    [SerializeField]
    private float velocidad = 5f;

    [SerializeField]
    private float velocidadRotacion = 10f;

    [SerializeField]
    private Camera camara;

    private Animator animaciones;
    private Vector3 velocidadActual;
    private bool enElPiso;

    [SerializeField]
    private float gravedad = -9.81f;

    private void Start()
    {
        animaciones = GetComponent<Animator>();
        controladorPersonaje = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        enElPiso = controladorPersonaje.isGrounded;
        if (enElPiso && velocidadActual.y < 0)
        {
            velocidadActual.y = 0f;
        }

        float valorHorizontal = Input.GetAxis("Horizontal");
        float valorVertical = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, camara.transform.eulerAngles.y, 0) * new Vector3(valorHorizontal, 0, valorVertical);
        Vector3 movementDirection = movementInput.normalized;

        controladorPersonaje.Move(movementDirection * velocidad * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, velocidadRotacion * Time.deltaTime);
        }

        velocidadActual.y += gravedad * Time.deltaTime;
        controladorPersonaje.Move(velocidadActual * Time.deltaTime);
        EstadosAnimaciones(valorHorizontal, valorVertical);
    }

    private void EstadosAnimaciones(float h,float v)
    {
        float direccion = Mathf.Abs(v) + Mathf.Abs(h);
        direccion = Mathf.Clamp(direccion, 0, 1);
        animaciones.SetFloat("Direccion", direccion);
    }
}
