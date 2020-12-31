using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    //variable current item selected.
    public int currentSelectedItem;
    public int currentItemCost;
    private Player _player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.hasAmountOfDiamonds);

            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        //0 flame sword
        //1 boots of
        //2 key to cas
        Debug.Log(item);

        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(191);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(93);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-16);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }
    public void BuyItem()
    {
        
        if (_player.hasAmountOfDiamonds >= currentItemCost)
        {
            //award

            if (currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            _player.hasAmountOfDiamonds -= currentItemCost;
            UIManager.Instance.OpenShop(_player.hasAmountOfDiamonds);

            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You do not have enough gems. Closing the shop.");
            shopPanel.SetActive(false);
        }
    }
    //BuyItem Method
    //check player gems is greater than itemCost
    //if true then subtract cost from player.

}
