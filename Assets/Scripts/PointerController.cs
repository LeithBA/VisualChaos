using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerController : MonoBehaviour
{
    [SerializeField] GameObject t_Equation, t_Speed, t_xNoise, t_yNoise, t_Trail, nextPointer;
    private float t, x, y, speed, xNoise, yNoise, trail;
    private bool i = false;

    private void Awake()
    {
		xNoise = Random.Range(-10f,10f);
		yNoise = Random.Range(-10f,10f);
		speed = Random.Range(-2f,2f);
    }
    private void Update()
    {
        t = Time.time * speed;
        x = nextPointer.transform.position.x;
        y = nextPointer.transform.position.y;
        trail = GetComponent<TrailRenderer>().time;
        transform.position = new Vector3(Mathf.Sin(y + t) * Mathf.Cos(xNoise * t),
                                         Mathf.Cos(x + t) * Mathf.Sin(yNoise * t), 0);
        t_Speed.GetComponent<Text>().text = "Speed: " + speed.ToString("F1");
        t_xNoise.GetComponent<Text>().text = "XNoise: " + xNoise.ToString("F1");
        t_yNoise.GetComponent<Text>().text = "YNoise: " + yNoise.ToString("F1");
        t_Trail.GetComponent<Text>().text = "Trail: " + trail;
    }

    public void changeSpeed(float amount)
    {
        speed += amount / 10;
        Mathf.Round(speed);
    }
    public void changexNoise(float amount)
    {
        xNoise += amount / 10;
        Mathf.Round(xNoise);
    }
    public void changeyNoise(float amount)
    {
        yNoise += amount / 10;
        Mathf.Round(yNoise);
    }
    public void changeTrail(float amount)
    {
        trail += amount;
        GetComponent<TrailRenderer>().time = trail;
    }
    public void resetTrail()
    {
        GetComponent<TrailRenderer>().Clear();
        GetComponent<TrailRenderer>().time = trail;

    }
}
