using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentItemSelected;
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player!=null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
            }
            shopPanel.SetActive(true);
        }  
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            shopPanel.SetActive(false);
        }
    }
    public void SelectItem(int item)
    {
        Debug.Log("Select Item " + item);

        currentItemSelected = item;
     
        switch (item)
        {
            case 0:
           UIManager.Instance.UpdateShopSelection(100);
            break;

            case 1:
                UIManager.Instance.UpdateShopSelection(1);
                break;

            case 2:
                UIManager.Instance.UpdateShopSelection(-110);
                break;
        }
    }
    public void BuyItem(int price)
    {
        if (_player.diamonds>=price)
        {
            if (currentItemSelected==2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            _player.diamonds-= price;
            UIManager.Instance.playerGemCountText.text = "" + _player.diamonds + "G";
        }
        else
        {
            shopPanel.SetActive(false);
        }
    }
}
