using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerceraPersona : MonoBehaviour{
    public Transform mirandoA;
    public Transform transformacionCamara;

    private Camera camara;

    public float distancia=10.0f;
    private float xActual=0.0f;
    private float yActual=0.0f ;
    public float yAnguloInicial=2.0f;
    public float xAnguloInicial=0f;
    //private float xSensivilidad=4.0f;
    //private float ySensivilidad=0;

    private const float Y_ANGULO_MIN=-50.0f;
    private const float Y_ANGULO_MAX=50.0f;

    void Start(){
        transformacionCamara=transform;
        camara=Camera.main;    
    }
    void Update(){
        xActual+=Input.GetAxis("Mouse X");
        yActual+=Input.GetAxis("Mouse Y");
        yActual=Mathf.Clamp(yActual,Y_ANGULO_MIN,Y_ANGULO_MAX);/**/
    }
    void LateUpdate(){
        Vector3 direccion=new Vector3(0,0,-distancia);
        Quaternion rotacion=Quaternion.Euler(yActual+yAnguloInicial, xActual+xAnguloInicial, 0);
        transformacionCamara.position=mirandoA.position+rotacion*direccion;
        transformacionCamara.LookAt(mirandoA.position);
    }
}
