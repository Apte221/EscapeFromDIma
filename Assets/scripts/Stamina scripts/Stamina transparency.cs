using UnityEngine;
using UnityEngine.UI;

public class StaminaTransparency : MonoBehaviour
{
    public Player player;   // Посилання на об'єкт Player
    public Image image;
    public float getStamina;
    public float fadeDuration = 0.5f;  

    void Start()
    {
        

    }

    void Update()
    {
        getStamina = player.GetComponent<Player>().Stamina;
        if (getStamina == 100){
            Color color = image.color;
            float alpha = Mathf.Lerp(color.a, 0.15f, Time.deltaTime / fadeDuration);
            color.a = alpha;
            image.color = color;
        }
        else{
            Color color = image.color;
            float alpha = Mathf.Lerp(color.a, 1f, Time.deltaTime / fadeDuration);
            color.a = alpha;
            image.color = color;
        }


    }


}
