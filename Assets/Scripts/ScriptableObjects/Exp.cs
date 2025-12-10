using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Exp", menuName = "CardEffects/Exp")]
public class Exp : CardEffect
{
    public int number;

    public Card nextCard;

    public int baseAmount;

    public void Update()
    {
        if (nextCard.type == "simple")
        {
            baseAmount += nextCard.value;
        }
    }

    public override void Apply(ref int score)
    {
        score += (int)Math.Pow(baseAmount, number);
    }
}
