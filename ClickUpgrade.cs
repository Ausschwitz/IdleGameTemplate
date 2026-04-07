using UnityEngine;

public class ClickUpgrade : MonoBehaviour
{
    public int level = 1;
    public int baseCost = 10;
    public float costMultiplier = 2f;

    public int GetCost()
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, level - 1));
    }

    public void Upgrade(ref int coin, ref int clickPower)
    {
        int cost = GetCost();

        if (coin >= cost)
        {
            coin -= cost;
            level++;
            clickPower += 1;
        }
    }
}
