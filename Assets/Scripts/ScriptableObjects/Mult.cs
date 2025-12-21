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

        int prevData = previousCard.currentValue;

        if (previousCard.data.type == CardType.Simple)
        {
            previousCard.currentValue = prevData * multiplier;
            Debug.Log($"Exp: Changed{prevData} value now {previousCard.currentValue}");
        }
    }
}
