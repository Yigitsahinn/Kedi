using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StressScript : MonoBehaviour
{
    [SerializeField] private int stressAmaount;
    [SerializeField] private int highstressChoice;
    [SerializeField] private int lowstressChoice;
    private int diceNumber;
    private bool succes = false;

    public void HighStress()
    {
        stressAmaount += highstressChoice;
    }

    public void LowStress()
    {
        stressAmaount += lowstressChoice;
    }
   
    public void DiceRoll()
    {
        diceNumber = Random.Range(1, 12);

        if(stressAmaount >=50 && diceNumber <= 4)
        {
            succes = true;
        }
        else if (stressAmaount <= 50 && stressAmaount >=25 && diceNumber <= 6)
        {
            succes = true;
        }
        else if (stressAmaount <= 25 && diceNumber <= 8)
        {
            succes = true;
        }
        else
        {
            succes = false;
        }
    }

    public void RollDice()
    {
        DiceRoll();
        Debug.Log(diceNumber);
        Debug.Log(succes);

    }
}
