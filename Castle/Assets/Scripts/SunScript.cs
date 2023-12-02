using UnityEngine;

public  class SunScript : MonoBehaviour
{
    public float dayDuration = 15f;

    public Color dayColor = new Color(0.2f, 0.5f, 0.9f);

    public Color nightColor = new Color(0f, 0f, 0.2f);
    public Vector3 startDayPosition = new Vector3(-82.5f, -13.27f, 150f);
    public Vector3 halfDayPosition = new Vector3(60.1f, 3f, 150f);
    public Vector3 endDayPosition = new Vector3(285f, -13f, 150f);
    public float startDayHeight = -13f;
    public float endDayHeight = -13f;
    public float maxDayHeight = 3f;

   private bool isDay = true;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
      
        if (isDay)
        {
            if (timer < dayDuration / 2f)
            {
                MoveSun(startDayPosition, halfDayPosition, startDayHeight, maxDayHeight, true);
              
            }
            else
            {
                MoveSun(halfDayPosition, endDayPosition, maxDayHeight, endDayHeight, false);
               
            }

            if (timer >= dayDuration)
            {
                timer = 0f;
                isDay = false;
                ChangeBackgroundColor(nightColor);
            }
        }
        else
        {
            MoveSun(endDayPosition, endDayPosition, endDayHeight, endDayHeight, false);

            if (timer >= dayDuration)
            {
                timer = 0f;
                isDay = true;
                ChangeBackgroundColor(dayColor);
            }
        }
    }

 void MoveSun(Vector3 from, Vector3 to, float startHeight, float endHeight, bool raising)
{
    float t = timer / (dayDuration / 2f);

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
