using UnityEngine;

[CreateAssetMenu(fileName = "Mult", menuName = "CardEffects/Mult")]
public class Mult : CardEffect
{
    public int multiplier;

    public override void Apply(
        ref int score,
        CardFunction currentCard,
        CardFunction previousCard
    )
    {
        Debug.Log("Apply triggered");
        if (previousCard == null)
            return;

        Card prevData = previousCard.data;

        if (prevData.type == CardType.Simple)
        {
            int amount = prevData.value * multiplier;
            score += amount;
        }
    }
}
