
public static class GameState
{
    // Backpack
    public static bool BackpackOpened { get; private set; }

    // Map
    public static bool MapUsed { get; private set; }
    public static bool MapUnlocked { get; private set; }

    // Water choices
    public static bool BottleChosen { get; private set; }
    public static bool HasStoredWater { get; private set; }
    public static bool FilterUsed { get; private set; }

    // Future rewards
    public static bool BonusCardUnlocked { get; private set; }

    public static void OpenBackpack()
    {
        BackpackOpened = true;
    }

    public static void UseMap()
    {
        MapUsed = true;
        MapUnlocked = true;
    }

    public static void ChooseBottle()
    {
        BottleChosen = true;
        HasStoredWater = true;
        BonusCardUnlocked = true;
    }

    public static void UseFilter()
    {
        FilterUsed = true;
    }

    public static void ResetGameState()
    {
        BackpackOpened = false;

        MapUsed = false;
        MapUnlocked = false;

        BottleChosen = false;
        HasStoredWater = false;
        FilterUsed = false;

        BonusCardUnlocked = false;
    }
}
