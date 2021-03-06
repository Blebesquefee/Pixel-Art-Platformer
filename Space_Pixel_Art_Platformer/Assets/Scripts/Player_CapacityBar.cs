using UnityEngine;
using UnityEngine.UI;
public class Player_CapacityBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient gradient;

    public void Reset(float val, float max)
    {
        slider.maxValue = max;
        slider.minValue = val;
        slider.value = max;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(float value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
