using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShiftAbility : MonoBehaviour
{
    //variables used to instantiate a gameobject that will destroy the object that it touches
    public Transform InstantiatePos;
    Vector2 MousePos;
    Camera cam;
    public GameObject DestroyUser;
    //variables used to put a Cooldown timer on the ability
    float CooldownTimer;
    public float StartCooldownTimer;

    void Start()
    {
        cam = Camera.main;

    }
    void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        InstantiatePos.position = new Vector2(MousePos.x, MousePos.y);
        if (Input.GetKeyDown(KeyCode.Mouse0) && CooldownTimer == 0)
        {
            Instantiate(DestroyUser, this.InstantiatePos.position, this.InstantiatePos.rotation);
            CooldownTimer = StartCooldownTimer;
        }
        if (CooldownTimer > 0)
        {
            CooldownTimer -= Time.fixedDeltaTime;
        }
        else if (CooldownTimer < 0)
        {
            CooldownTimer = 0;
        }

    }
}
