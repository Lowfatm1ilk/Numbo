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

        Card prevData = previousCard.data;
        Debug.Log($"Exp: Previous card = {prevData.cardName}, type = {prevData.type}, value = {prevData.value}");

        if (prevData.type == CardType.Simple)
        {
            int baseAmount = prevData.value;
            int amount = (int)Math.Pow(baseAmount, exponent);
            score += amount;
            Debug.Log($"Exp: Added {amount} to score, total now {score}");
        }
        else
        {
            Debug.Log("Exp: Previous card is not Simple, skipping");
        }
    }

}
