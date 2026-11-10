
using UnityEngine;

public class WeaponSkinApplicator : MonoBehaviour
{
    public Renderer[] weaponRenderers;

    public Material goldMaterial;
    public Material tigerMaterial;
    public Material dragonMaterial;

    public void ApplySkin(string skinId)
    {
        Material selectedMaterial = null;

        switch (skinId)
        {
            case "AKM_GOLD":
                selectedMaterial = goldMaterial;
                break;

            case "M416_TIGER":
                selectedMaterial = tigerMaterial;
                break;

            case "SNIPER_DRAGON":
                selectedMaterial = dragonMaterial;
                break;
        }

        if (selectedMaterial == null)
        {
            Debug.Log("Material skin belum tersedia!");
            return;
        }

        foreach (Renderer weaponRenderer in weaponRenderers)
        {
            if (weaponRenderer != null)
            {
                weaponRenderer.material = selectedMaterial;
            }
        }
    }
}
