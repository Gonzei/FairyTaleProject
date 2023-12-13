using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;

    public bool isBow;

    //projectile
    [SerializeField] private Text firePowerText;
    [SerializeField] private BowWeapon bowWeapon;
    [SerializeField] private string enemyTag;
    [SerializeField] private float maxFirePower;
    [SerializeField] private float firePowerSpeed;
    [SerializeField] private GameObject player;
    public float maxLookAngle;
    
    private float firePower;
    private bool fire;

    // Start is called before the first frame update
    void Start()
    {
        if(isBow) 
        {
            bowWeapon.SetEnemyTag(enemyTag);
            bowWeapon.Reload();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBow)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fire = true;
            }

            if (fire && firePower < maxFirePower)
            {
                firePower += Time.deltaTime * firePowerSpeed;
            }

            if (fire && Input.GetMouseButtonUp(0))
            {
                bowWeapon.Fire(firePower);
                firePower = 0;
                fire = false;
            }

            if (fire)
            {
                firePowerText.text = firePower.ToString();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
