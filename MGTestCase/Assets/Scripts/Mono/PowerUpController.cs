using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    public float Exp = 0f;

    [SerializeField] Button boostButton;

    [SerializeField] Image boostImage;

    private void Awake()
    {
        Instance = this;
    }

    public void AddExp(float val)
    {
        Exp += val;
        boostImage.fillAmount += val;

        if(Exp >= 1f)
        {
            Exp = 1f;

            Highlight();
        }
        else
        {
            NormalLight();
        }
            
    }

    public void RemoveExp(float val)
    {
        Exp -= val;
        boostImage.fillAmount -= val;

        NormalLight();

        if (Exp < 0f)
            Exp = 0f;
    }

    private void Highlight()
    {
        var colors = boostButton.colors;
        colors.colorMultiplier = 2;

        boostButton.colors = colors;
    }


    private void NormalLight()
    {
        var colors = boostButton.colors;
        colors.colorMultiplier = 1;

        boostButton.colors = colors;
    }

    public void Boost()
    {
        if (Exp < 1f) return;

        Exp = 0f;

        boostImage.fillAmount = 0f;

        var movement = GameObject.FindObjectOfType<Player>().GetComponentInChildren<ForwardMovement>();

        StartCoroutine(IEBoost(movement, 5f));
    }

    IEnumerator IEBoost(ForwardMovement movement, float delay)
    {
        movement.SetSpeed(10f);

        yield return new WaitForSeconds(delay);

        movement.SetSpeed(movement.initialSpeed); 
    }

    public static PowerUpController Instance;
}
