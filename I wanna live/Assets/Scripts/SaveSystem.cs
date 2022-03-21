
using System.IO;
using UnityEngine;
using System.Linq;



public static class SaveSystem
{
    public static string path = Application.persistentDataPath + "/player.json";
    public static void SaveGame()
    {

        PlayerData data = new PlayerData();

        if (!File.Exists(path))
        {
            SaveToEmptyFile(data);
        }

        else
        {
            var dataFromFile = LoadFromFile();
            var list = dataFromFile.ToList();
            // var oldPlayer = list.FirstOrDefault(x => GameController.instanse.playerName.Equals(x.playerName));
            // if (oldPlayer != null)
            // {

            // }
            // else
            // {
            //     var newPlayer = new PlayerData();
            //     list.Add(newPlayer);
            // }
            SaveToFile(list.ToArray());

        }

    }



    private static void SaveToEmptyFile(PlayerData data)
    {
        PlayerData[] savedata = new PlayerData[1];
        savedata[0] = data;
        var json = JsonHelper.ToJson(savedata, true);
        File.WriteAllText(path, json);
    }
    public static bool isSaveFileCreated()
    {
        return File.Exists(path);
    }
    private static void SaveToFile(PlayerData[] data)
    {
        string json = JsonHelper.ToJson(data, true);
        File.WriteAllText(path, json);
    }



    public static PlayerData[] LoadFromFile()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return JsonHelper.FromJson<PlayerData>(json);
        }
        return null;
    }

    public static PlayerData GetLastPlayer()
    {
        //   var player = LoadFromFile().ToList().Last();

        //   return player;
        return null;


    }

    public static PlayerData FindPlayerByName(string name)
    {
        //  var player = LoadFromFile().ToList().FirstOrDefault(x => x.playerName.Equals(name));

        // return player;
        return null;

    }

}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}