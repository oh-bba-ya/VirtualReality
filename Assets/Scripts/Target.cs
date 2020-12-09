using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Color m_FlashDamageColor = Color.white;
    public Animator anim;

    private MeshRenderer m_MeshRenderer = null;
    private Color m_OriginalColor = Color.white;

    private int m_MaxHealth = 2;
    private int m_Health = 0;


    private int hashDamage = Animator.StringToHash("damage");
    private int hashDie = Animator.StringToHash("die");
    private int hashAttack = Animator.StringToHash("attack_01");
    private int hashFinish = Animator.StringToHash("isFinish");


    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_MeshRenderer.material.color;
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ResetHealth();
    }

    private void OnCollisionEnter(Collision collision)              // OnCollisionEnter 는 서로 부딪히는 오브젝트끼리의 trigger가 체크되어있으면 작동안함.
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            anim.SetTrigger(hashFinish);
            Damage();
        }
    }


    private void OnTriggerEnter(Collider other)         //   Player 주변에 있는 collider는 istrigger , 몬스터도 istrigger 가 켜져있으므로 triggerenter을 사용함.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger(hashAttack);
        }
    }

    private void Damage()
    {
        StopAllCoroutines();
        StartCoroutine(Flash());
        anim.SetTrigger(hashDamage);
        RemoveHealth();
    }

    private IEnumerator Flash()
    {
        m_MeshRenderer.material.color = m_FlashDamageColor;

        WaitForSeconds wait = new WaitForSeconds(0.1f);
        yield return wait;

        m_MeshRenderer.material.color = m_OriginalColor;
    }

    private void RemoveHealth()
    {
        m_Health--;
        CheckForDeath();
    }

    private void ResetHealth()
    {
        m_Health = m_MaxHealth;
    }

    private void CheckForDeath()
    {
        if(m_Health <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        anim.SetTrigger(hashDie);             // life = 0 되면은 죽음.
        gameObject.SetActive(false);
        
    }
}
