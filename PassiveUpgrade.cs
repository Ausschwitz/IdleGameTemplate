using UnityEngine;

public class PassiveUpgrade : MonoBehaviour
{
    public int level = 1;
    public int baseCost = 15;
    public float costMultiplier = 2.2f;

    public int GetCost()
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, level - 1));
    }

    public void Upgrade(ref int coin, ref int passiveIncome)
    {
        int cost = GetCost();

        if (coin >= cost)
        {
            coin -= cost;
            level++;
            passiveIncome += 1;
        }
    }
}
