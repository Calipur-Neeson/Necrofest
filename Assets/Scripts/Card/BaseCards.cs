using TMPro;
using UnityEngine;

namespace AG2187
{
    public abstract class BaseCards : MonoBehaviour
    {
        public string cardName;
        public string cardDescription;
        public Sprite cardImage;
        public Sprite cardFrame;

        public TextMeshProUGUI textCardName;
        public TextMeshProUGUI textCardDescription;

        public virtual void ActivateCard(string name)
        {
            CardEffect.instance.TriggerEffect(name);
        }

        public virtual void Start()
        {
            textCardName.text = cardName;
            textCardDescription.text = cardDescription;
        }
    }

    public class NormalCards : BaseCards
    {

    }

    public class RareCards : BaseCards
    {

    }

    public class EpicCards : BaseCards
    {

    } 
}