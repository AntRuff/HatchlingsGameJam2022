using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public List<GameObject> goons;
    [SerializeField]
    private float dayLength = 200f;
    [SerializeField]
    private float curTime = 0;
    [SerializeField]
    private bool isNight = false;
    [SerializeField]
    private GameObject dayLight;
    public static DayNightManager Instance;
    [SerializeField]
    private List<GoonSpawnerScript> spawners;
    private float dayAngle = 60f;
    private float nightAngle = (0f - 5f);
    [SerializeField]
    private float tranTime = 15;
    private float curTranTime = 0;
    [SerializeField]
    private List<Silver> ilver;
    [SerializeField]
    private List<Gold> gold;
    [SerializeField]
    private AudioSource day;
    [SerializeField]
    private AudioSource night1;

    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        if(curTime < dayLength)
        {
            curTime += Time.deltaTime;
        } else
        {
            isNight = !isNight;
            foreach (GoonSpawnerScript i in spawners)
            {
                i.isNight = isNight;
                if (isNight)
                {
                    i.TURNUPTHEHEAT();
                }
            }
            curTime = 0;
            curTranTime = 0;
            if (!isNight)
            {
                foreach(GameObject g in goons)
                {
                    Destroy(g);
                }
                goons.Clear();
                foreach(Silver i in ilver)
                {
                    if (!i.gameObject.activeSelf)
                    {
                        i.gameObject.SetActive(true);
                        i.Replish();
                    }
                }
                foreach (Gold g in gold)
                {
                    if (!g.gameObject.activeSelf)
                    {
                        g.gameObject.SetActive(true);
                        g.Replish();
                    }
                }                
            }
        }
        if (isNight && curTranTime < tranTime)
        {
            dayLight.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(nightAngle, -30, 0)), curTranTime);
            day.volume = Mathf.Lerp(1, 0, curTranTime);
            night1.volume = Mathf.Lerp(0, 1, curTranTime);
            curTranTime += Time.deltaTime;

        } else if (curTranTime < tranTime)
        {
            dayLight.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(dayAngle, -30, 0)), curTranTime);
            day.volume = Mathf.Lerp(0, 1, curTranTime);
            night1.volume = Mathf.Lerp(1, 0, curTranTime);
            curTranTime += Time.deltaTime;
        }
    }
}
