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
            case 1:
                target = new Vector3(75, 25, 1);
                break;
            case 2:
                target = new Vector3(100, 25, 1);
                break;
            case 3:
                target = new Vector3(125, 25, 1);
                break;
            case 4:
                target = new Vector3(50, 25, 1);
                break;
        }
    }
}
