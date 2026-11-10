
using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player;
    public GameObject vehicle;
    public Transform seatPosition;
    public Transform exitPosition;

    private bool isDriving = false;

    public void EnterVehicle()
    {
        if (isDriving || player == null ||
            vehicle == null || seatPosition == null)
            return;

        player.SetActive(false);

        vehicle.SetActive(true);

        vehicle.transform.position =
            seatPosition.position;

        isDriving = true;

        Debug.Log("Pemain masuk kendaraan!");
    }

    public void ExitVehicle()
    {
        if (!isDriving || player == null ||
            exitPosition == null)
            return;

        player.transform.position =
            exitPosition.position;

        player.SetActive(true);

        isDriving = false;

        Debug.Log("Pemain keluar kendaraan!");
    }
}
