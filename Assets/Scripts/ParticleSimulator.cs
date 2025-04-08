using System;
using UnityEngine;

public class ParticleSimulator : MonoBehaviour
{
    public GameObject particlePrefab; // Prefab for the particle (must have a Rigidbody and Collider)
    public int numberOfParticles = 10; // Number of particles to spawn
    public Vector3 spawnArea = new Vector3(5, 10, 5); // Area in which particles will spawn
    public float particleSize = 1.0f; // Size of each particle

    void Start()
    {
        SpawnParticles();
    }

    void SpawnParticles()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            // Randomize spawn position within the spawn area
            Vector3 spawnPosition = new Vector3(
                UnityEngine.Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                UnityEngine.Random.Range(spawnArea.y / 2, spawnArea.y),
                UnityEngine.Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // Instantiate the particle
            GameObject particle = Instantiate(particlePrefab, spawnPosition, Quaternion.identity);

            // Set particle size
            particle.transform.localScale = Vector3.one * particleSize;

            // Add Rigidbody and configure it
            Rigidbody rb = particle.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = particle.AddComponent<Rigidbody>();
            }
            rb.useGravity = true;
            rb.mass = 1f; // Adjust mass if needed
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // Better collision detection

            // Add a SphereCollider (or any other collider)
            SphereCollider collider = particle.GetComponent<SphereCollider>();
            if (collider == null)
            {
                collider = particle.AddComponent<SphereCollider>();
            }
            collider.radius = particleSize / 2f; // Adjust collider size to match particle size
        }
    }
}