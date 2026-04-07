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

    private int upgradeCost = 10;
    private float timer = 0f;

    void Start()
    {
        LoadGame();
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
        coin += clickPower;
        UpdateUI();
    }

    public void BuyUpgrade()
    {
        if (coin >= upgradeCost)
        {
            coin -= upgradeCost;
            passiveIncome++;
            upgradeCost += 10;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        coinText.text = "Coin: " + coin;
        passiveText.text = "Pasif: " + passiveIncome + "/sn";
        upgradeCostText.text = "Fiyat: " + upgradeCost;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("passive", passiveIncome);
        PlayerPrefs.SetInt("cost", upgradeCost);
    }

    public void LoadGame()
    {
        coin = PlayerPrefs.GetInt("coin", 0);
        passiveIncome = PlayerPrefs.GetInt("passive", 1);
        upgradeCost = PlayerPrefs.GetInt("cost", 10);
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
}
