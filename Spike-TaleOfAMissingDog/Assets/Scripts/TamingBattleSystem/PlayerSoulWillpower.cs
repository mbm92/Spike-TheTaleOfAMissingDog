using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSoulWillpower : MonoBehaviour
{
    public int WP;

    public int MaxWp;

    public Slider wpSlider;

    public void TakeDamage(int dmg)
    {
        WP -= dmg;
        SetWp(WP);
        if (WP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Player Has Died");
    }


    public void SetWpSlider()
    {
        wpSlider.maxValue = MaxWp;
        wpSlider.value = WP;
    }

    public void SetWp(int wp)
    {
        wpSlider.value = wp;
    }
}
