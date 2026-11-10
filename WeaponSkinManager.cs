
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkinManager : MonoBehaviour
{
    public List<WeaponSkinData> skins =
        new List<WeaponSkinData>();

    public bool BuyWeaponSkin(string skinId)
    {
        WeaponSkinData skin = skins.Find(
            item => item.skinId == skinId
        );

        if (skin == null)
            return false;

        string key = "OWNED_" + skinId;

        if (PlayerPrefs.GetInt(key, 0) == 1)
        {
            Debug.Log("Skin sudah dimiliki!");
            return false;
        }

        PlayerWallet wallet = FindObjectOfType<PlayerWallet>();

        if (wallet == null || !wallet.SpendCoins(skin.price))
        {
            Debug.Log("Koin tidak cukup!");
            return false;
        }

        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();

        Debug.Log("Berhasil membeli skin: " + skin.skinName);
        return true;
    }

    public bool SelectWeaponSkin(string skinId)
    {
        if (PlayerPrefs.GetInt("OWNED_" + skinId, 0) != 1)
        {
            Debug.Log("Skin belum dimiliki!");
            return false;
        }

        PlayerPrefs.SetString("SELECTED_WEAPON_SKIN", skinId);
        PlayerPrefs.Save();

        Debug.Log("Skin senjata dipilih: " + skinId);
        return true;
    }

    public string GetSelectedWeaponSkin()
    {
        return PlayerPrefs.GetString(
            "SELECTED_WEAPON_SKIN", ""
        );
    }
}
