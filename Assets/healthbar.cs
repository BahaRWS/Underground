using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Slider slider;
    public Gradient grad;
    public Image fill;
    public void setMaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = grad.Evaluate(1);
    }

    // Update is called once per frame
    public void setHealth(int health)
    {
        slider.value = health;
        fill.color = grad.Evaluate(slider.normalizedValue);
    }
}
