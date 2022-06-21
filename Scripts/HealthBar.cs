using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public void ChangedHealthBar(float x, Transform lifeBar, float oldLifeBar, int hp)
    {
        lifeBar.localPosition = new Vector2(x * hp / 100 - x, lifeBar.localPosition.y);
        lifeBar.localScale = new Vector2(oldLifeBar * hp / 100, lifeBar.localScale.y);
    }
}