using UnityEngine;
using AG2187;
public class SpeedDaemon : RareCards
{
    private void Awake()
    {
        cardName = "Speed Daemon";
        cardDescription = "Increase damage based on movement speed\n(5% DMG per 10 MS)";
    }
}
