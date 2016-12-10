using UnityEngine;
public class ObjectsFactory {
    public static GameData getGameData(string gameDataText)
    {
        return JsonUtility.FromJson<GameData>(gameDataText);
    }
}
