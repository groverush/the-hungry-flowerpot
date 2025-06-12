using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLaunch : MonoBehaviour
{
    public float lifeTime = 5f; // Por si no choca con nada
    public Vector3 boundsMin = new Vector3(-10f, -10f, -10f); // Ajusta según el nivel
    public Vector3 boundsMax = new Vector3(10f, 10f, 10f);

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Destruye el misil si sale del área del nivel
        Vector3 pos = transform.position;
        if (pos.x < boundsMin.x || pos.x > boundsMax.x ||
            pos.y < boundsMin.y || pos.y > boundsMax.y ||
            pos.z < boundsMin.z || pos.z > boundsMax.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Aquí puedes verificar el tag del enemigo u objeto que quieras destruir
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
