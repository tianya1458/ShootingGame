
using UnityEngine;
using System.Collections;


public class Shoot : MonoBehaviour
{
public Transform firepoint;
//声明子弹实例
public Rigidbody Bullet;
//初始化发射时间
private float nextFire= 1F;
//声明子弹间隔
public float fireRate = 2F;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame



    void Update()
    {
        //点击左键并且时间已经大于间隔时间
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            //更新间隔时间
            nextFire = Time.time + fireRate;
            //通过射线获得目标点
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            Vector3 target = ray.GetPoint(10);
            firepoint.LookAt(target);
            //实例化子弹
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(Bullet, firepoint.position, firepoint.rotation);
            //初始化子弹的方向速度
            clone.velocity = target - firepoint.position;
            
            
            

        }

        
    }
}

