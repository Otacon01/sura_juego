using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public float tiempo = 10;
    public Text txtTiempo;
    public bool tiempoCorriendo { get; set; }

    public UnityEvent tiempoTerminado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoCorriendo)
        {
            if (tiempo > 0)
            {
                tiempo -= Time.deltaTime;
                MostrarFormato(tiempo);
            }
            else
            {
                tiempo = 0;
                tiempoCorriendo = false;
                tiempoTerminado.Invoke();
            }
        }
    }

    private void MostrarFormato(float valorTiempo)
    {
        valorTiempo += 1;
        float minutos = Mathf.FloorToInt(valorTiempo / 60);
        float segundos = Mathf.FloorToInt(valorTiempo % 60);
        txtTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
