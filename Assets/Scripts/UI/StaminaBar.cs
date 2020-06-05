using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private int player = 0;
    private Slider staminaBar;

    private void Start()
    {
        staminaBar = GetComponent<Slider>();
        EventSystemUI.current.onSetMaxStamina += SetMaxStamina;
        EventSystemUI.current.onStaminaChanged += ChangeStamina;
    }

    private void SetMaxStamina(int playerId, float amount)
    {
        if (playerId == player)
        {
            staminaBar.maxValue = amount;
            staminaBar.value = amount;
        }  
    }
    private void ChangeStamina(int playerId, float amount)
    {
        if (playerId == player)
        {
            staminaBar.value = amount;
        }
            
    }

    private void OnDisable()
    {
        EventSystemUI.current.onSetMaxStamina -= SetMaxStamina;
        EventSystemUI.current.onStaminaChanged -= ChangeStamina;
    }
}
