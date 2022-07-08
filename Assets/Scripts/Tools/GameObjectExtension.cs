using UnityEngine;

public static class GameObjectExtension
{
    private const string PLAYER_TAG = "Player"; 

    public static bool IsPlayer(this GameObject gameObject)
    {
        return gameObject.CompareTag(PLAYER_TAG);
    }
}
