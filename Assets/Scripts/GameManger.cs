using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private Transform[] points;
    public GameObject monsterPrefab;
    public float createTime;
    public int maxMonster = 5;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.Find("ReSpawn").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            StartCoroutine(this.CreateMonster());
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            int monsterCnt = (int)GameObject.FindGameObjectsWithTag("Monster").Length;

            if(monsterCnt < maxMonster)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }

}
