using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyCode : MonoBehaviour
{
    public float range;
    public Transform Player;
    public float speed;

    //Range ATK Vars
    public GameObject bulletPrefab;
    public float shootingCooldown;
    public float timeBetweenShots;

    //Melee ATK Vars
    public float meleeRange;
    public GameObject meleePrefab;
    public float meleeCooldown;
    public float timeBetweenMelee;
    public Vector2 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Vector2.Distance(Player.position, transform.position) <= range)
        {
            //transform.Translate(Vector2.MoveTowards(transform.position, -Player.position, 0) * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, Player.position, step);
            if (shootingCooldown <= 0)
            {
                //Create bullet
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                shootingCooldown = timeBetweenShots;
            }
            else
            {
                //reduce cooldown
                shootingCooldown = shootingCooldown - 1;
            }
        }

        // MELEE ATK -----------------------------------------------------------------------------------
        if (Vector2.Distance(Player.position, transform.position) <= meleeRange)
        {
            if (meleeCooldown <= 0)
            {
                //find player and create object in area

                GameObject mATK = Instantiate(meleePrefab, transform.position, transform.rotation);
                Vector2 meleeArea = Player.transform.position - transform.position;

                if (meleeArea.x < 0)
                {
                    if (meleeArea.y > 0)
                    {
                        //attack up to the left
                        mATK.transform.Translate(-1, 1, 0);
                    }
                    else if (meleeArea.y > -.5 && meleeArea.y < .5)
                    {
                        //shoot direcly to the left
                        mATK.transform.Translate(-1, 0, 0);
                    }
                    else if (meleeArea.y < 0)
                    {
                        //shoot down to the left
                        mATK.transform.Translate(-1, -1, 0);
                    }
                }
                else if (meleeArea.x > -.5 && meleeArea.x < .5)
                {
                    if (meleeArea.y > 0)
                    {
                        //shoot directly up
                        mATK.transform.Translate(0, 1, 0);
                    }
                    else if (meleeArea.y < 0)
                    {
                        //shoot direcly down
                        mATK.transform.Translate(0, -1, 0);
                    }
                }
                else if (meleeArea.x > 0)
                {
                    if (meleeArea.y > 0)
                    {
                        //shoot up and to the right
                        mATK.transform.Translate(1, 1, 0);
                    }
                    else if (meleeArea.y > -.5 && meleeArea.y < .5)
                    {
                        //shoot directly right
                        mATK.transform.Translate(1, 0, 0);
                    }
                    else if (meleeArea.y < 0)
                    {
                        //shoot down and to the right
                        mATK.transform.Translate(1, -1, 0);
                    }
                }

                //Reset cooldown for attack
                meleeCooldown = timeBetweenMelee;
            }

            else
            {
                //reduce cooldown for melee attack
                meleeCooldown = meleeCooldown - 1;
            }
        }
        //End Melee Attack ---------------------------------------------------------------------------------------
    }
}
