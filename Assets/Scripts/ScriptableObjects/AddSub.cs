using UnityEngine;

[CreateAssetMenu(fileName = "AddSub", menuName = "CardEffects/AddSub")]
public class AddSub : CardEffect
{
    public int number;

    public override void Apply(
        ref int score,
        CardFunction currentCard,
        CardFunction previousCard
    )
    {
        score += number;
    }
}
