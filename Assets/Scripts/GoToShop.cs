using UnityEngine;

public class GoToShop : MonoBehaviour
{
    public GameObject menuPanel, shopPanel;
    public void goToShop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
}
