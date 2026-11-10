
using UnityEngine;

public class IslandMapGenerator : MonoBehaviour
{
    public int mapSize = 400;
    public int treeCount = 150;
    public int rockCount = 60;
    public int buildingCount = 15;
    public int seed = 12345;

    void Start()
    {
        Random.InitState(seed);

        CreateGround();
        CreateWater();
        CreateTrees();
        CreateRocks();
        CreateBuildings();

        Debug.Log("MAP NUSANTARA BERHASIL DIBUAT!");
    }

    void CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(
            PrimitiveType.Plane
        );

        ground.name = "Pulau Nusantara";
        ground.transform.position = Vector3.zero;
        ground.transform.localScale =
            new Vector3(mapSize / 10f, 1, mapSize / 10f);
    }

    void CreateWater()
    {
        GameObject water = GameObject.CreatePrimitive(
            PrimitiveType.Plane
        );

        water.name = "Laut Nusantara";
        water.transform.position =
            new Vector3(0, -1, 0);

        water.transform.localScale =
            new Vector3(60, 1, 60);

        water.GetComponent<Collider>().enabled = false;
    }

    void CreateTrees()
    {
        for (int i = 0; i < treeCount; i++)
        {
            Vector3 pos = RandomPosition();

            GameObject trunk =
                GameObject.CreatePrimitive(
                    PrimitiveType.Cylinder
                );

            trunk.name = "Pohon Nusantara";
            trunk.transform.position =
                pos + Vector3.up * 1.5f;

            trunk.transform.localScale =
                new Vector3(0.5f, 1.5f, 0.5f);

            GameObject leaves =
                GameObject.CreatePrimitive(
                    PrimitiveType.Sphere
                );

            leaves.transform.position =
                pos + Vector3.up * 4f;

            leaves.transform.localScale =
                new Vector3(3f, 3f, 3f);
        }
    }

    void CreateRocks()
    {
        for (int i = 0; i < rockCount; i++)
        {
            GameObject rock =
                GameObject.CreatePrimitive(
                    PrimitiveType.Sphere
                );

            rock.name = "Batu Nusantara";
            rock.transform.position =
                RandomPosition() + Vector3.up * 0.5f;

            rock.transform.localScale =
                Vector3.one * Random.Range(1f, 3f);
        }
    }

    void CreateBuildings()
    {
        for (int i = 0; i < buildingCount; i++)
        {
            GameObject house =
                GameObject.CreatePrimitive(
                    PrimitiveType.Cube
                );

            house.name = "Rumah Nusantara";

            house.transform.position =
                RandomPosition() + Vector3.up * 2f;

            house.transform.localScale =
                new Vector3(8f, 4f, 8f);
        }
    }

    Vector3 RandomPosition()
    {
        float half = mapSize / 2f;

        return new Vector3(
            Random.Range(-half, half),
            0,
            Random.Range(-half, half)
        );
    }
}
