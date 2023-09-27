using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public Bullet       bulletScript;
    public GameObject   bulletPrefab1;
    public GameObject   bulletPrefab2;
    public float maxshoot;
    public float currentshoot;
    public Sprite full;
    public Sprite halffull;
    public Sprite empty;
    public GameObject player;
    public GameObject Ui;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (currentshoot < maxshoot)|| Input.GetMouseButtonDown(0) && (currentshoot < maxshoot) || Input.GetKeyDown(KeyCode.RightShift) && (currentshoot < maxshoot))
        {

            GameObject bulletInstance = Instantiate(bulletPrefab1, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.ShootBullet(transform.right);
            currentshoot = currentshoot + 1;
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetMouseButtonDown(1))
        {
            currentshoot = 0;
        }

        if (currentshoot == 0)
        {
            player.GetComponent<SpriteRenderer>().sprite = full;
            Ui.GetComponent<SpriteRenderer>().sprite = full;
        }

        if (currentshoot == 1)
        {
            player.GetComponent<SpriteRenderer>().sprite = halffull;
            Ui.GetComponent<SpriteRenderer>().sprite = halffull;
        }

        if (currentshoot == maxshoot)
        {
            player.GetComponent<SpriteRenderer>().sprite = empty;
            Ui.GetComponent<SpriteRenderer>().sprite = empty;
        }
    }
}
