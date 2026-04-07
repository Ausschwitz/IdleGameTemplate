using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coin = 0;
    public int clickPower = 1;
    public int passiveIncome = 1;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI passiveText;
    public TextMeshProUGUI upgradeCostText;

    public ClickUpgrade clickUpgrade;
    public PassiveUpgrade passiveUpgrade;
    public CritSystem critSystem;
    public OfflineManager offlineManager;

    private int passiveUpgradeCost = 10;
    private float timer = 0f;

    void Start()
    {
        LoadGame();

        if (offlineManager != null)
        {
            int offlineCoins = offlineManager.CalculateOfflineEarnings(passiveIncome);
            coin += offlineCoins;
        }

        UpdateUI();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer = 0f;
            coin += passiveIncome;
            UpdateUI();
        }
    }

    public void AddCoin()
    {
        int earned = clickPower;

        if (critSystem != null)
            earned = critSystem.Calculate(clickPower);

        coin += earned;
        UpdateUI();
    }

    public void BuyPassiveUpgrade()
    {
        if (coin >= passiveUpgradeCost)
        {
            coin -= passiveUpgradeCost;
            passiveIncome += 1;
            passiveUpgradeCost += 10;
            UpdateUI();
        }
    }

    public void BuyClickUpgrade()
    {
        if (clickUpgrade != null)
        {
            clickUpgrade.Upgrade(ref coin, ref clickPower);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (coinText != null)
            coinText.text = "Coin: " + coin;

        if (passiveText != null)
            passiveText.text = "Pasif: " + passiveIncome + "/sn";

        if (upgradeCostText != null)
            upgradeCostText.text = "Fiyat: " + passiveUpgradeCost;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("clickPower", clickPower);
        PlayerPrefs.SetInt("passiveIncome", passiveIncome);
        PlayerPrefs.SetInt("passiveUpgradeCost", passiveUpgradeCost);

        if (offlineManager != null)
            offlineManager.SaveTime();

        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        coin = PlayerPrefs.GetInt("coin", 0);
        clickPower = PlayerPrefs.GetInt("clickPower", 1);
        passiveIncome = PlayerPrefs.GetInt("passiveIncome", 1);
        passiveUpgradeCost = PlayerPrefs.GetInt("passiveUpgradeCost", 10);
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
}
