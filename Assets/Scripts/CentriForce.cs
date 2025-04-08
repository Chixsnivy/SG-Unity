using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentriForce : MonoBehaviour
{
    public float mass = 1.0f;  // Masa de una partícula
    public GameObject reference;  // Referencia de la fuerza centrípeta

    private Vector3 f, a, v, x;  // Variables dinámicas de la partícula por atraer

    // Start is called before the first frame update
    void Start()
    {
        // Inicialización
        f = new Vector3(0.0f, 0.0f, 0.0f);
        a = new Vector3(0.0f, 0.0f, 0.0f);
        v = new Vector3(0.0f, -20.0f, 0.0f); // velocidad inicial
        x = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float radius = (reference.transform.position - x).magnitude; // Distancia entre masas
        float velocityMagnitude = v.magnitude; // Magnitud del vector de velocidad
        Vector3 forceDirection = reference.transform.position - x;// vector de dirección de la velocidad

        // Cálculo de la fuerza centrípeta
        // F = m * v^2 / r
        f = (mass * velocityMagnitude * velocityMagnitude / (radius * radius)) * forceDirection;

        // Resolución numérica de la posición
        a = f / mass;
        v += a * Time.deltaTime;
        x += v * Time.deltaTime;

        transform.position = x;

        Debug.DrawLine(x, reference.transform.position, Color.yellow);
    }
}
