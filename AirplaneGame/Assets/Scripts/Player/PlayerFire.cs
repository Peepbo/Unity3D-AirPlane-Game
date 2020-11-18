using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject Bullet;
    Transform AtkPos;

    //사운드
    public AudioSource[] audio;
    public AudioClip shotSound;

    //이펙트
    public GameObject effect;

    //오브젝트 풀링
    int poolSize = 5;
    int fireIndex = 0;

    //1.배열
    //GameObject[] bulletPool;
    //2.리스트
    public List<GameObject> bulletPool;

    //line renderer
    LineRenderer lr;
    //일정시간동안 레이져 보여주기
    public float rayTime = 0.3f;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        AtkPos = transform.Find("AtkPos");

        //오브젝트 풀링 초기화
        InitObjectPooling();
    }

    //오브젝트 풀링 초기화
    private void InitObjectPooling()
    {
        //1. 배열
        //bulletPool = new GameObject[poolSize];

        //for (int i = 0; i < poolSize; i++)
        //{
        //    GameObject _bullet = Instantiate(Bullet);
        //    _bullet.SetActive(false);
        //    bulletPool[i] = _bullet;
        //}

        //2.리스트
        bulletPool = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject _bullet = Instantiate(Bullet);
            _bullet.SetActive(false);
            bulletPool.Add(_bullet);
        }
    }

    public void bulletFire()
    {
        //라인렌더러 버튼 클릭시
        lr.enabled = true;
        //라인 시작점, 끝점 세팅
        lr.SetPosition(0, AtkPos.position);
        //lr.SetPosition(1, AtkPos.position + Vector3.up * 10);

        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hitInfo; // ray와 충돌한 오브젝트의 정보를 담는다

        if(Physics.Raycast(ray, out hitInfo))
        {
            //레이져의 끝점 지점
            lr.SetPosition(1, hitInfo.point);
            //층돌한 오브젝트 모두 지우기
            //Destroy(hitInfo.collider.gameObject);

            if(hitInfo.collider.name.Contains("Enemy"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }

        if (bulletPool.Count > 0)
        {
            GameObject _bullet = bulletPool[0];
            _bullet.SetActive(true);
            bulletPool[fireIndex].transform.position = AtkPos.position;
            bulletPool[fireIndex].transform.up = AtkPos.up;
            //오브젝트 풀에서 빼준다
            bulletPool.RemoveAt(0);
            //bulletPool.Remove(_bullet);
        }

        else // 오브젝트풀이 비어서 오브젝트가 하나도 없으니 풀크기를 키워줌
        {
            GameObject _bullet = Instantiate(Bullet);
            _bullet.SetActive(false);
            bulletPool.Add(_bullet);
        }


        //Instantiate(Bullet, AtkPos.position, Quaternion.identity);
        audio[0].PlayOneShot(shotSound);
        Instantiate(effect, AtkPos.position, Quaternion.identity);
    }

    private void Update()
    {
        showRay();
    }

    private void showRay()
    {
        if (!lr.enabled) return;

        time += Time.deltaTime;
        if(time > rayTime)
        {
            time = 0;
            lr.enabled = false;  
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetButtonDown("Fire1"))
    //    {
    //        //object pooling
    //        //bulletPool[fireIndex].SetActive(true);
    //        //bulletPool[fireIndex].transform.position = AtkPos.position;
    //        //bulletPool[fireIndex].transform.up = AtkPos.up;
    //        //fireIndex++;

    //        //if (fireIndex == poolSize) fireIndex = 0;

    //        //list object pooling
    //        if(bulletPool.Count > 0)
    //        {
    //            GameObject _bullet = bulletPool[0];
    //            _bullet.SetActive(true);
    //            bulletPool[fireIndex].transform.position = AtkPos.position;
    //            bulletPool[fireIndex].transform.up = AtkPos.up;
    //            //오브젝트 풀에서 빼준다
    //            bulletPool.RemoveAt(0);
    //            //bulletPool.Remove(_bullet);
    //        }

    //        else // 오브젝트풀이 비어서 오브젝트가 하나도 없으니 풀크기를 키워줌
    //        {
    //            GameObject _bullet = Instantiate(Bullet);
    //            _bullet.SetActive(false);
    //            bulletPool.Add(_bullet);
    //        }


    //        //Instantiate(Bullet, AtkPos.position, Quaternion.identity);
    //        audio[0].PlayOneShot(shotSound);
    //        Instantiate(effect, AtkPos.position, Quaternion.identity);
    //    }

    //    if(Input.GetButtonDown("Fire2"))
    //    {
    //        for(int i = 0; i < 36; i++)
    //        {
    //            Instantiate(Bullet, AtkPos.position, Quaternion.Euler(0, 0, 10f * i));
    //        }
    //    }
    //}
}
