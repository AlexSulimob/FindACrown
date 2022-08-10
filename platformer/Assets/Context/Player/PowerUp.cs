using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool airJump;
    public bool Dash;
    public bool WallSlide;
    public GameObject ShowGameObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (airJump)
            {
                JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanAirJump = true;
            }
            if(Dash)
            {
                JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanDash = true;
            }
            if(WallSlide)
            {
                JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanWallSlide = true;
            }
            JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.Save();

            if(ShowGameObject != null)//minus srp
            {
                ShowGameObject.SetActive(true);
            }
        }
        
    }
}
