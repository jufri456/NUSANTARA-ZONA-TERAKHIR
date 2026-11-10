
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    public int vehicleCount = 10;
    public float mapRadius = 150f;

    void Start()
    {
        if (vehiclePrefabs == null ||
            vehiclePrefabs.Length == 0)
            return;

        for (int i = 0; i < vehicleCount; i++)
        {
            SpawnVehicle();
        }
    }

    void SpawnVehicle()
    {
        GameObject prefab =
            vehiclePrefabs[
                Random.Range(0, vehiclePrefabs.Length)
            ];

        Vector3 position = new Vector3(
            Random.Range(-mapRadius, mapRadius),
            0,
            Random.Range(-mapRadius, mapRadius)
        );

        Instantiate(
            prefab,
            position,
            Quaternion.identity
        );
    }
}
