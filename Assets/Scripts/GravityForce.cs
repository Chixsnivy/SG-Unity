using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    public float G = 9.81f;  // Gravedad escalar
    public float m1 = 1.0f;  // Masa de una part�cula
    public float m2 = 10.0f; // Masa de la segunda part�cula
    public float r1 = 1.0f;  // radio de la primer part�cula
    public float r2 = 5.0f;  // radio de la segunda part�cula
    public GameObject atractor;  // Atractor (generador de la fuerza de gravedad)

    private Vector3 f, a, v, x;  // Variables din�micas de la part�cula por atraer

    // Start is called before the first frame update
    void Start()
    {
        // Inicializaci�n
        f = new Vector3(0.0f, 0.0f, 0.0f);
        a = new Vector3(0.0f, 0.0f, 0.0f);
        v = new Vector3(0.0f, 0.0f, 0.0f);
        x = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = (atractor.transform.position - x).magnitude; // Distancia entre masas

        Vector3 gravityDirection = atractor.transform.position - x; // Direcci�n de la gravedad

        if (distance > r1 + r2) {
            // C�lculo de fuerza (Ley de gravitaci�n)
            // F = m1*m2*G/d^2
            f = (m1 * m2 * G / (distance * distance)) * gravityDirection;

            // Resoluci�n num�rica de la posici�n
            a = f / m1;
            v += a * Time.deltaTime;
            x += v * Time.deltaTime;

            transform.position = x;

        }

        Debug.DrawLine(x, atractor.transform.position, Color.yellow);
    }
}
