using UnityEngine;

public static class FishingSceneData
{
    private static FishBase[] possibleFish;
    public static FishBase fish;
    public static new Vector3 target;

    public static void SetPossibleFish(FishBase[] fishList)
    {
        Debug.Log(possibleFish);
        possibleFish = fishList;
    }

    public static FishBase[] GetPossibleFish()
    {
        return possibleFish;
    }

    public static void GetRandomFish()
    {
        fish = possibleFish[Random.Range(0, possibleFish.Length)];
        switch (fish.level)
        {
            case 0:
                target = new Vector3(100, 25, 1);
                break;
            case 1:
                target = new Vector3(150, 25, 1);
                break;
            default:
                target = new Vector3(50, 25, 1);
                break;
        }
    }
}
