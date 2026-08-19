using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class attack : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Gradient grad;
    public Image fill;
    public void canattack(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = grad.Evaluate(1);
    }

    // Update is called once per frame
    public void setattackborder(int health)
    {
        slider.value = health;
        fill.color = grad.Evaluate(slider.normalizedValue);

    }
}
