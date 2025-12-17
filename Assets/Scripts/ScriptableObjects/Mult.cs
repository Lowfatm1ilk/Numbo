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
        if (previousCard == null)
            return;

        Card prevData = previousCard.data;

        if (prevData.type == CardType.Simple)
        {
            prevData.value = prevData.value * multiplier;
            Debug.Log($"Exp: Changed{prevData.cardName} value now {prevData.value}");
        }
    }
}
