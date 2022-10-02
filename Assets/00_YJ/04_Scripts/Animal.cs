using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 1. ü�°��� : ���� �̻� ������ �������� => Slider�� �� �޾ƿͼ� / 3�� �� ������ �ν��ϰ� / �ν� ������ ( �ִϸ��̼� ���� ������ ) destroy object �ϱ�
 */

public class Animal : MonoBehaviour
{
    public Slider hpbar;
    public Animator anim;
    public GameObject vfx_hit;


    [SerializeField] float maxHP;
    [SerializeField] float currentHP;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100;
        currentHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = currentHP / maxHP;

    }




    private void OnCollisionEnter(Collision collision)
    {
        GameObject temp = collision.gameObject;


        if (temp.name.Contains("Fire")) // �Ѿ˿� ������ 
        {
            currentHP -= FireBall.hitDamage;
            anim.SetTrigger("damage"); // ������ �ִϸ��̼� ���ֱ�

            // ������ VFX ���ֱ�
            ContactPoint contact = collision.contacts[0]; // �浹 ����
            GameObject tempVFX = Instantiate(vfx_hit);
            tempVFX.transform.position = contact.point; // ��ġ ���� ����
        }



        if (currentHP <= 0)
        {
            // �״� �ô� �ϰ�
            anim.SetTrigger("die");


            // 1�� �ڿ� ���ֱ�
            Destroy(this.gameObject, 3.0f);
        }

        anim.SetTrigger("idle");
    }


}
