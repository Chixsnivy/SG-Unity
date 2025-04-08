using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    public float G = 9.81f;  // Gravedad escalar
    public float m1 = 1.0f;  // Masa de una partícula
    public float m2 = 10.0f; // Masa de la segunda partícula
    public float r1 = 1.0f;  // radio de la primer partícula
    public float r2 = 5.0f;  // radio de la segunda partícula
    public GameObject atractor;  // Atractor (generador de la fuerza de gravedad)

    private Vector3 f, a, v, x;  // Variables dinámicas de la partícula por atraer

    // Start is called before the first frame update
    void Start()
    {
        // Inicialización
        f = new Vector3(0.0f, 0.0f, 0.0f);
        a = new Vector3(0.0f, 0.0f, 0.0f);
        v = new Vector3(0.0f, 0.0f, 0.0f);
        x = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = (atractor.transform.position - x).magnitude; // Distancia entre masas

        Vector3 gravityDirection = atractor.transform.position - x; // Dirección de la gravedad

        if (distance > r1 + r2) {
            // Cálculo de fuerza (Ley de gravitación)
            // F = m1*m2*G/d^2
            f = (m1 * m2 * G / (distance * distance)) * gravityDirection;

            // Resolución numérica de la posición
            a = f / m1;
            v += a * Time.deltaTime;
            x += v * Time.deltaTime;

            transform.position = x;

        }

        Debug.DrawLine(x, atractor.transform.position, Color.yellow);
    }
}
