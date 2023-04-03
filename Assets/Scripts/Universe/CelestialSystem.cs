using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelestialSystem : MonoBehaviour
{
    [SerializeField]
    private float G = 50f;
    [SerializeField]
    public List<CelestialObject> system;
    [SerializeField]
    public CelestialObject baseCelestialObject;

    [SerializeField]
    public float absorptionRate = 1.1f;

    public int state;

    void Start()
    {
        foreach (CelestialObject obj in system)
        {
            obj.G = G;
            obj.mySystem = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Gravity();
    }

    private void Gravity()
    {
        foreach(CelestialObject obj in system)
        {
            obj.Attract(system);
        }
    }

    public void AddObject(CelestialObject obj)
    {
        system.Add(obj);
    }

    public void Annihilate(GameObject annihilator, GameObject annihilated)
    {

        if (GameObject.Find("BlackHoleMode").GetComponent<Toggle>().isOn)
        {
            annihilator.gameObject.GetComponent<Rigidbody2D>().mass += annihilated.gameObject.GetComponent<Rigidbody2D>().mass;
            annihilator.gameObject.transform.localScale *= absorptionRate;
            system.Remove(annihilated.GetComponent<CelestialObject>());
            Destroy(annihilated);
        }
    }

    public void ChangeAbsorptionRate(float newValue)
    {
        absorptionRate = newValue;
    }
}
