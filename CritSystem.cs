using UnityEngine;

public class CritSystem : MonoBehaviour
{
    [Range(0, 100)]
    public int critChance = 10; // %10 ihtimal

    public int critMultiplier = 2;

    public int Calculate(int baseValue)
    {
        int random = Random.Range(0, 100);

        if (random < critChance)
        {
            return baseValue * critMultiplier;
        }

        return baseValue;
    }
}
