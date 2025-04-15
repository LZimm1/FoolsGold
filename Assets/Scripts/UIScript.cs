using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UIScript : MonoBehaviour
{   
    public static int Money = 150;
    public static float buyPrice=100;
    public static int effBuyPrice;
    private int totalGoldBought;
    private int realGoldBought;
    private int fakeGoldBought;
    public static int totalGoldInventory;
    public static int realGoldInventory;
    public static int fakeGoldInventory;
    private int realGoldBoughtShop=0;
    private int fakeGoldBoughtShop=0;
    private int realSellPrice = 200;
    private int fakeSellPriceMin = 10;
    private int fakeSellPriceMax = 50;
    private int realBuyPrice =150;
    private int fakeBuyPrice = 20;
    private int realGoldSold=0;
    private int levelUpPrice = 100;
    public Text buyPriceStr;
    public Text moneyText;
    public Text totalGoldText;
    public Text realGoldText;
    public Text fakeGoldText;
    public Text sellRealText;
    public Text sellFakeText;
    public Text buyRealText;
    public Text buyFakeText;
    public Text levelUpText;
    public Text currentLevelText;
    public Text accuracyText;
    public Text moneyPerSecond;
    public AudioSource buySound;
    public AudioSource discardSound;
    public AudioSource sellSound;
    public AudioSource upgradeSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Increment());
    }

    // Update is called once per frame
    void Update()
    {
        effBuyPrice = (int)buyPrice;
        if(Money > 2000000000){
            Money = 2000000000;
        }
        if(buyPrice > 2000000000){
            buyPrice = 2000000000;
        }
        if(totalGoldBought > 2000000000){
            totalGoldBought = 2000000000;
        }
        if(realGoldBought > 2000000000){
            realGoldBought = 2000000000;
        }
        if(fakeGoldBought > 2000000000){
            fakeGoldBought = 2000000000;
        }
        if(buyPriceStr){
            buyPriceStr.text = "Buy Gold: $" + (effBuyPrice).ToString();
        }
        if(moneyText){
            moneyText.text = "Money: $" + (Money).ToString();
        }
        if(totalGoldText){
            totalGoldText.text = "Total Gold: " + totalGoldInventory.ToString();
        }
        if(realGoldText){
            realGoldText.text = "Real Gold: " + realGoldInventory.ToString();
        }
        if(fakeGoldText){
            fakeGoldText.text = "Fake Gold: " + fakeGoldInventory.ToString();
        }
        if(sellRealText){
            sellRealText.text = "Sell Real Gold - $" + realSellPrice.ToString();
        }
        if(sellFakeText){
            sellFakeText.text = "Sell Fake Gold - $" + fakeSellPriceMin.ToString()+"-$"+ fakeSellPriceMax.ToString();
        }
        if(buyRealText){
            buyRealText.text = "Buy Real Gold - $" + realBuyPrice.ToString();
        }
        if(buyFakeText){
            buyFakeText.text = "Buy Fake Gold - $" + fakeBuyPrice.ToString();
        }
        if(levelUpText){
            levelUpText.text = "Upgrade-$" + levelUpPrice.ToString();
            if(TestScript.level==50){
                levelUpText.text = "MAX";
            }
        }
        if(currentLevelText){
            currentLevelText.text = "Current Level: " + TestScript.level.ToString();
        }
        if(accuracyText){
            accuracyText.text = "Accuracy: " + (TestScript.level + 49).ToString()+"%";
        }
        if(moneyPerSecond){
            moneyPerSecond.text = "MPS: $" + totalGoldBought.ToString();
        }
    }
    public void discard(){
        GoldSpawner.discardedGold = true;
        buyPrice = (float)(100*Math.Pow(1.02f,(float)totalGoldBought));
        discardSound.Play();
    }
    public void buyGold(){
        if(Money-effBuyPrice > 0){
            if(GoldSpawner.rng == 1 || GoldSpawner.rng == 2 || GoldSpawner.rng == 3){
                fakeGoldBought++;
                fakeGoldInventory++;
            }
            else{
                realGoldBought++;
                realGoldInventory++;
            }
            GoldSpawner.discardedGold = true;
            totalGoldBought++;
            totalGoldInventory++;
            buyPrice = (float)(100*Math.Pow(1.02f,totalGoldBought));
            Money -= effBuyPrice;
            buySound.Play();
        }
    }
    IEnumerator Increment(){
        while(true){
            yield return new WaitForSeconds(1f);
            buyPrice*=1.04f;
            Money+= totalGoldBought;
        }
    }
    public void sellRealGold(){
        if(realGoldInventory > 0){
            Money += realSellPrice;
            realGoldInventory--;
            totalGoldInventory--;
            realGoldSold++;
            realSellPrice = (int)(200*Math.Pow(1.02,realGoldSold));
            sellSound.Play();
        }
    }
    public void sellFakeGold(){
        if(fakeGoldInventory > 0){
            Money += UnityEngine.Random.Range(fakeSellPriceMin,fakeSellPriceMax+1);
            fakeGoldInventory--;
            totalGoldInventory--;
            fakeSellPriceMax++;
            fakeSellPriceMin++;
            sellSound.Play();
        }
    }
    public void buyRealGold(){
        if(Money >= realBuyPrice){
            Money -= realBuyPrice;
            realGoldInventory++;
            totalGoldInventory++;
            realGoldBoughtShop++;
            realBuyPrice = (int)(150*Math.Pow(1.04,realGoldBoughtShop));
            buySound.Play();
        }
    }
    public void buyFakeGold(){
        if(Money >= fakeBuyPrice){
            Money -= fakeBuyPrice;
            fakeGoldInventory++;
            totalGoldInventory++;
            fakeGoldBoughtShop++;
            fakeBuyPrice = (int)(20*Math.Pow(1.04,fakeGoldBoughtShop));
            buySound.Play();
        }
    }
    public void levelUp(){
        if(Money >= levelUpPrice && TestScript.level <50){
            TestScript.level++;
            Money -= levelUpPrice;
            levelUpPrice = (int)(100*Math.Pow(1.25,TestScript.level-1));
            upgradeSound.Play();
        }
    }
    
}
