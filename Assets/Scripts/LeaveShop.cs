using UnityEngine;
public class LeaveShop : MonoBehaviour
{
    public GameObject menuPanel, shopPanel;
    public void leaveShop()
    {
        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }
}
