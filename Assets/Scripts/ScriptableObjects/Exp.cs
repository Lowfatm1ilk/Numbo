using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Exp", menuName = "CardEffects/Exp")]
public class Exp : CardEffect
{
    public int exponent;

    public override void Apply(
        ref int score,
        CardFunction currentCard,
        CardFunction previousCard
    )
    {
        if (previousCard == null)
        {
            Debug.Log("Exp: No previous card, nothing to do");
            return;
        }

        int prevData = previousCard.currentValue;

        if (previousCard.data.type == CardType.Simple)
        {
            int baseAmount = prevData;
            int amount = (int)Math.Pow(baseAmount, exponent);
            previousCard.currentValue = amount;
            Debug.Log($"Exp: Changed{prevData} value now {amount}");
        }
        else
        {
            Debug.Log("Exp: Previous card is not Simple, skipping");
        }
    }

}
