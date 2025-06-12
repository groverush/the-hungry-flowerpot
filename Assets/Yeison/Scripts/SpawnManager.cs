using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private List<Transform> spawnsPoints;
    [SerializeField] private float respawnTimeInSeconds;
    [SerializeField] public float speedMin, speedMax;
    [SerializeField] private Transform displayCenter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReturnObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReturnObject()
    {
        while (true)
        {
            int objectRandom = Random.Range(0, objects.Count);
            int positionRandom = Random.Range(0, spawnsPoints.Count);

            // Dirección hacia el centro desde el punto de aparición
            UnityEngine.Vector3 direccion = (displayCenter.position - spawnsPoints[positionRandom].position).normalized;

            // Crear rotación hacia esa dirección
            UnityEngine.Quaternion rotacion = UnityEngine.Quaternion.LookRotation(-direccion);

            Instantiate(objects[objectRandom], spawnsPoints[positionRandom].position, rotacion);
            yield return new WaitForSeconds(respawnTimeInSeconds);
        }
    }
}
