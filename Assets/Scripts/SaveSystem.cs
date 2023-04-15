using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{

    public static void SaveShop( ShopButtons shopButtons)
    {
        BinaryFormatter formatter = new BinaryFormatter();


        string path = Application.persistentDataPath + "/StopData.Minima";
        FileStream stream = new FileStream(path, FileMode.Create);


        ShopData data = new ShopData(shopButtons);

        formatter.Serialize(stream, data);

        stream.Close();

    }

    public static ShopData LoadShop()
    {
        string path = Application.persistentDataPath + "/StopData.Minima";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShopData data = formatter.Deserialize(stream) as ShopData;

            stream.Close();

            return data; 

        }

        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }

    }


    public static void SavePlayer(PlayerCurrencyUI playerCurrency, BubbleDash bubbleDash, BubbleShield bubbleShield, PlayerHealth playerHealth, Grapple grapple, SwitchWeapon switchWeapon)
    {
        BinaryFormatter formatter = new BinaryFormatter();


        string path = Application.persistentDataPath + "/PlayerData.Minima";
        FileStream stream = new FileStream(path, FileMode.Create);


        PlayerData data = new PlayerData(playerCurrency, bubbleDash, bubbleShield, playerHealth, grapple, switchWeapon);

        formatter.Serialize(stream, data);

        stream.Close();

    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/PlayerData.Minima";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;

        }

        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }

    }

}