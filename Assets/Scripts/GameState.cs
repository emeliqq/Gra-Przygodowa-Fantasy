
public static class GameState
{
    public static bool BackpackOpened { get; private set; }
    public static bool MapUsed { get; private set; }

    public static void OpenBackpack()
    {
        BackpackOpened = true;
    }

    public static void UseMap()
    {
        MapUsed = true;
    }

    public static void ResetGameState()
    {
        BackpackOpened = false;
        MapUsed = false;
    }
}
