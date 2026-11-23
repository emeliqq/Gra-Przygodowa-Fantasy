
using System.Collections.Generic;

public static class GameState
{
    public static bool BackpackOpened { get; private set; }
    public static bool MapUsed { get; private set; }

    private static HashSet<string> litRooms = new HashSet<string>();

    public static void OpenBackpack()
    {
        BackpackOpened = true;
    }

    public static void UseMap()
    {
        MapUsed = true;
    }

    public static bool IsRoomLit(string roomId)
    {
        return litRooms.Contains(roomId);
    }

    public static void LightRoom(string roomId)
    {
        litRooms.Add(roomId);
    }

    public static void ResetGameState()
    {
        BackpackOpened = false;
        MapUsed = false;
        litRooms.Clear();
    }
}
