
using UnityEngine;

public class SkinPreview : MonoBehaviour
{
    public Transform previewPosition;
    private GameObject previewObject;

    public void ShowPreview(GameObject skinPrefab)
    {
        if (skinPrefab == null || previewPosition == null)
            return;

        if (previewObject != null)
        {
            Destroy(previewObject);
        }

        previewObject = Instantiate(
            skinPrefab,
            previewPosition.position,
            previewPosition.rotation
        );

        previewObject.transform.SetParent(previewPosition);
    }
}
