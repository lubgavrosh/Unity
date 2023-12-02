using UnityEngine;

public class MoonScript : MonoBehaviour
{
    SunScript sun = new SunScript();
    public float nightDuration =15f;
    public Color dayColor = new Color(0.5f, 0.5f, 1f);
    public Color nightColor = new Color(0f, 0f, 0.2f);
    public Vector3 startDayPosition = new Vector3(-82.5f, -3.27f, 150f);
    public Vector3 halfDayPosition = new Vector3(60.1f, 3f, 150f);
    public Vector3 endDayPosition = new Vector3(200.8f, -16f, 150f);
    public float startDayHeight = -13f;
    public float endDayHeight = -13f;
    public float maxDayHeight = 3f;

    private bool isNight = false;
    private float timer = 0f;


    void Update()
    {
        timer += Time.deltaTime;
       
            if (isNight)
            {
                if (timer < nightDuration / 2f)
                {
                    MoveMoon(startDayPosition, halfDayPosition, startDayHeight, maxDayHeight, true);

                }
                else
                {
                    MoveMoon(halfDayPosition, endDayPosition, maxDayHeight, endDayHeight, false);

                }

                if (timer >= nightDuration)
                {
                    timer = 0f;
                    isNight = false;
                    ChangeBackgroundColor(nightColor);
                }
            }
            else
            {
                MoveMoon(endDayPosition, endDayPosition, endDayHeight, endDayHeight, false);

                if (timer >= nightDuration)
                {
                    timer = 0f;
                    isNight = true;
                    ChangeBackgroundColor(dayColor);
                }
            }
        
    }

    void MoveMoon(Vector3 from, Vector3 to, float startHeight, float endHeight, bool raising)
    {
        float t = timer / (nightDuration / 2f);

        if (!raising)
            t = 1 - t;

        float t1 = 3f * t * t - 2f * t * t * t;

        float height = Mathf.Lerp(startHeight, endHeight, t1);
        transform.position = Vector3.Lerp(from, to, t1);
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }

    void ChangeBackgroundColor(Color targetColor)
    {
        Camera.main.backgroundColor = targetColor;
    }
}
