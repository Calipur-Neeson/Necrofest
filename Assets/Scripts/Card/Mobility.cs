using UnityEngine;

public class Mobility : NormalCards
{
    private TwinklingFrame twinklingFrame;
    public ParticleSystem ps;

    private void Awake()
    {
        twinklingFrame.twinkle = ps;
        cardName = "Mobility";
        cardDescription = "Allows player to move, run and dash";
    }
}

public class TwinklingFrame
{
    public ParticleSystem twinkle;
}