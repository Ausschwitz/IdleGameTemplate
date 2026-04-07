using UnityEngine;
using System;

public class OfflineManager : MonoBehaviour
{
    private const string LAST_TIME_KEY = "LastTime";

    public void SaveTime()
    {
        PlayerPrefs.SetString(LAST_TIME_KEY, DateTime.Now.ToString());
    }

    public int CalculateOfflineEarnings(int passiveIncome)
    {
        if (!PlayerPrefs.HasKey(LAST_TIME_KEY))
            return 0;

        DateTime lastTime = DateTime.Parse(PlayerPrefs.GetString(LAST_TIME_KEY));
        DateTime currentTime = DateTime.Now;

        double secondsPassed = (currentTime - lastTime).TotalSeconds;

        int earned = Mathf.FloorToInt((float)secondsPassed * passiveIncome);

        return earned;
    }
}
