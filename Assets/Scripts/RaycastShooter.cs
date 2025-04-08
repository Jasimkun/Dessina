using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastShooter : MonoBehaviour
{

    public ParticleSystem flashEffect;    //�߻� ����Ʈ ���� ����

    public int magazineCaoacity = 30;     //źâ�� ũ��
    private int currentAmmo;             //���� �Ѿ� ����

    public TextMeshProUGUI ammoUI;     //�Ѿ� ������ ��Ÿ�� TextMeshProUGUI ����

    //������ ��� ���� ����
    public Image reloadingUI;         //������ UI
    public float reloadtime = 2f;     //������ �ð�
    private float timer = 0;          //�ð� Ȯ�ο� Ÿ�̸�
    private bool isReloading = false;  //������ Ȯ�ο� bool ����

    //���� ��� ��� ���� ����
    public AudioSource audioSource;          //����� �ҽ�
    public AudioClip audioClip;              //����� Ŭ��


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = magazineCaoacity;
        //ammoUI.text = currentAmmo + "/" + magazineCaoacity;
        ammoUI.text = $"{currentAmmo}/{magazineCaoacity}";    //���� �Ѿ� ������ UI�� ǥ��

        reloadingUI.gameObject.SetActive(false);             //������ UI ��Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && currentAmmo > 0 && isReloading == false)  //���������� �ƴ� �� ���� �߰�
        {
            audioSource.PlayOneShot(audioClip);                   //�߻� ���� ���
            currentAmmo--;                                        //�Ѿ��� 1�� �Һ��Ѵ�
            flashEffect.Play();                                   //����Ʈ ���
            ammoUI.text = $"{currentAmmo}/{magazineCaoacity}";    //���� �Ѿ� ������ UI�� ǥ��
            ShootRay();                                           //���� �߻� �Լ� ȣ��
        }

        if(Input.GetKeyDown(KeyCode.R))               //RŰ�� ������
        {
            isReloading = true;                      //������ ������ ����
            reloadingUI.gameObject.SetActive(true);  //������ UI Ȱ��ȭ
        }

        if(isReloading == true)
        {
            Reloading();
        }

    }

    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);     //�߻��� Ray�� ������, ���� ���� (���� ī�޶󿡼� ���콺 Ŀ�� �������� �߻�)
        RaycastHit hit;                                             //Ray�� ���� ����� ������ ������ �����

        if(Physics.Raycast(ray, out hit))               //Raycast�� ��ȯ���� Bool��, Ray�� �¾Ҵٸ� true ��ȯ
        {
            Destroy(hit.collider.gameObject);         //���� ��� ������Ʈ�� ����
        }
    }

    void Reloading()
    {
        timer += Time.deltaTime;

        reloadingUI.fillAmount = timer / reloadtime;            //������ UI�� fill ���� ���� ������� ������Ʈ

        if(timer >= reloadtime)                        //������ �ð��� ������ ���
        {
            timer = 0;
            isReloading = false;                            //�������� �Ϸ������ ǥ��
            currentAmmo = magazineCaoacity;                 //�Ѿ��� ä���ش�
            ammoUI.text = $"{currentAmmo}/{magazineCaoacity}"; //���� �Ѿ� ������ ǥ��
            reloadingUI.gameObject.SetActive(false);            //������ UI ������Ʈ�� ��Ȱ��ȭ
        }
    }
}
