using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionArea : MonoBehaviour
{
    public BeeIconDictionary iconDictionary;

    public Image iconLeft;
    public Image iconRight;
    public Text nameText;
    public Text countText;
    public Text speciesMainText;
    public Text speciesSecText;
    public Text speedMainText;
    public Text speedSecText;
    public Text lifeSpanMainText;
    public Text lifeSpanSecText;
    public Text fertilityMainText;
    public Text fertilitySecText;

    public void Setup(Bee bee, string count)
    {
        iconLeft.sprite = iconDictionary.GetSprites((Species.ValueType)bee.pairs[0].main.GetValue())[(int)bee.type];
        iconRight.sprite = iconDictionary.GetSprites((Species.ValueType)bee.pairs[0].secondary.GetValue())[(int)bee.type];
        nameText.text = $"{bee.GetSpecies()} {bee.type}";
        countText.text = "Count: " + count;
        speciesMainText.text = ((Species.ValueType)bee.pairs[0].main.GetValue()).ToString();
        speciesSecText.text = ((Species.ValueType)bee.pairs[0].secondary.GetValue()).ToString();
        speedMainText.text = ((Speed.ValueType)bee.pairs[1].main.GetValue()).ToString();
        speedSecText.text = ((Speed.ValueType)bee.pairs[1].secondary.GetValue()).ToString();
        lifeSpanMainText.text = ((LifeSpan.ValueType)bee.pairs[2].main.GetValue()).ToString();
        lifeSpanSecText.text = ((LifeSpan.ValueType)bee.pairs[2].secondary.GetValue()).ToString();
        fertilityMainText.text = bee.pairs[3].main.GetValue().ToString();
        fertilitySecText.text = bee.pairs[3].secondary.GetValue().ToString();
    }
}
