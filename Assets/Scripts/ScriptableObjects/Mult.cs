using UnityEngine;

[CreateAssetMenu(fileName = "Mult", menuName = "CardEffects/Mult")]
public class Mult : CardEffect
{
    public int number;

    public Card nextCard;

    public int totalAmount;

    public void Update()
    {
        if(nextCard.type == "simple")
        {
            totalAmount += nextCard.value;
            totalAmount *= number;
        }
    }

    public override void Apply(ref int score)
    {
        score += totalAmount;
    }
}
