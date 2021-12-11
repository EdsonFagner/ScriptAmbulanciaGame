using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCarro : MonoBehaviour
{

    public float torqueFreio;
    public float torque;
    public bool acelerando,freiando;
    public bool tracaoDianteira, tracaoTraseira;
    public bool freioDianteiro, freioTraseiro;
    public WheelCollider[] w_dianteiras;
    public WheelCollider[] w_traseiras;
    public Transform[] m_dianteiras;
    public Transform[] m_traseiras;
    public float inputVertical,inputHorizontal;
    public Rigidbody rb;
    public Transform pontoDeMassa;
	
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = pontoDeMassa.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");

        atualizarPosicaoMeshRodas();
        fazerCurva(30);

        if(inputVertical != 0)
        {
            acelerando = true;

        }
        else
        {
            acelerando = false;

        }

        if (Input.GetKey(KeyCode.Space))
        {
            freiando = true;

        }
        else
        {
            freiando = false;

        }

        if (acelerando)
        {

            if (tracaoDianteira)
            {

                acelerarDianteiras(torque);
            }

            if (tracaoTraseira)
            {

                acelerarTraseira(torque);
            }



        }
        else
        {

            acelerarDianteiras(0);
            acelerarTraseira(0);
        }
      


        if (freiando)
        {

            if (freioDianteiro)
            {

                freiarDianteira(torqueFreio);
            }

            if (freioTraseiro)
            {

                freiarTraseira(torqueFreio);
            }


        }
        else
        {

            if (freioDianteiro)
            {

                freiarDianteira(0);
            }

            if (freioTraseiro)
            {

                freiarTraseira(0);
            }
        }
       
    }

    public void acelerarDianteiras(float val)
    {
        for (int i = 0; i < w_dianteiras.Length; i++)
        {
            w_dianteiras[i].motorTorque = val * inputVertical;
        }


    }

    public void acelerarTraseira(float val)
    {
        for (int i = 0; i < w_dianteiras.Length; i++)
        {
            w_traseiras[i].motorTorque = val * inputVertical;
        }


    }
    public void freiarTraseira(float val)
    {
        for (int i = 0; i < w_dianteiras.Length; i++)
        {
            w_traseiras[i].brakeTorque = val;
        }


    }
    public void freiarDianteira(float val)
    {
        for (int i = 0; i < w_dianteiras.Length; i++)
        {
            w_dianteiras[i].brakeTorque = val;
        }


    }
    public void fazerCurva(float val)
    {

      
            w_dianteiras[0].steerAngle = val * inputHorizontal;
             w_dianteiras[1].steerAngle = val * inputHorizontal;



    }
    public void atualizarPosicaoMeshRodas()
    {
        for (int i = 0; i < w_dianteiras.Length; i++)
        {
            Vector3 pos;
            Quaternion quat;
            w_dianteiras[i].GetWorldPose(out pos, out quat);
            m_dianteiras[i].transform.position = pos;
            m_dianteiras[i].transform.rotation = quat;

            Vector3 posX;
            Quaternion quatX;
            w_traseiras[i].GetWorldPose(out posX, out quatX);
            m_traseiras[i].transform.position = posX;
            m_traseiras[i].transform.rotation = quatX;


        }





    }

  
}
