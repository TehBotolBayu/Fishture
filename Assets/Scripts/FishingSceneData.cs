using UnityEngine;

public static class FishingSceneData
{
    private static FishBase[] possibleFish;

    public static void SetPossibleFish(FishBase[] fishList)
    {
        possibleFish = fishList;
    }

    public static FishBase[] GetPossibleFish()
    {
        return possibleFish;
    }
}
