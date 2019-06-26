using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour{
    public float velocidad=1.0f;
    
    private float avanzando=0;

    
    [System.Serializable]
    public struct Union{
        //public string nombre;
        public Transform transform;
        public bool giroX;
        public float maxAnguloX,minAnguloX;
        public bool giroY;
        public float maxAnguloY,minAnguloY;
        public bool giroZ;
        public float maxAnguloZ,minAnguloZ;

    }
    public Union rodillaDD;
    public Union rodillaDT;
    public Union rodillaID;
    public Union rodillaIT;
    public Union caderaDD;
    public Union caderaDT;
    public Union caderaID;
    public Union caderaIT;
    
    //private Transform piernaIzquierdaDelantera;
    
    void Awake(){
        
        //transform.Find("LF Muslo");
    }
    void Start(){ 
    }

    void Update(){
        float factor=velocidad*Time.deltaTime;
        if(Input.GetAxis("Vertical")>0.01 || Input.GetAxis("Vertical")<-0.01){
            rotar(rodillaDD,Input.GetAxis("Vertical")*factor);
            rotar(rodillaDT,Input.GetAxis("Vertical")*factor);
            rotar(rodillaID,Input.GetAxis("Vertical")*factor);
            rotar(rodillaIT,Input.GetAxis("Vertical")*factor);/**/
            /*rotar(_uniones["CaderaDD"],Input.GetAxis("Vertical")*-factor, 0);
            rotar(_uniones["CaderaID"],Input.GetAxis("Vertical")*factor, 0);
            rotar(_uniones["CaderaDT"],Input.GetAxis("Vertical")*-factor, 0);
            rotar(_uniones["CaderaIT"],Input.GetAxis("Vertical")* factor, 0);/* */
            //rotarY(_uniones["RodillaDD"],Input.GetAxis("Vertical"), factor);
            //rotarY(_uniones["RodillaDD"],Input.GetAxis("Vertical"), factor);
            /*Vector3 angulos=_uniones["RodillaDD"].localRotation.eulerAngles;
            Quaternion cuaternio=_uniones["RodillaDD"].localRotation;
            float av=angulos.y;
            print("---");
            print(Input.GetAxis("Vertical"));
            print (av);
                av+=(Input.GetAxis("Vertical")*factor);
            print (av);
            print (cuaternio);
            //cuaternio.Set(cuaternio.x,2,cuaternio.z, cuaternio.w);
            cuaternio.Set(cuaternio.x,cuaternio.y,av, cuaternio.w);
            print (cuaternio);
            print("---");
            _uniones["RodillaDD"].localRotation=Quaternion.Euler(angulos.x,av,angulos.z);
            //_uniones["RodillaDD"].localRotation=cuaternio;/* */
        }
        if(Input.GetAxis("Horizontal")>0.01 || Input.GetAxis("Horizontal")<-0.01){
            rotar(caderaDD,Input.GetAxis("Horizontal")*factor);
            rotar(caderaDT,Input.GetAxis("Horizontal")*factor);
            rotar(caderaID,Input.GetAxis("Horizontal")*factor);
            rotar(caderaIT,Input.GetAxis("Horizontal")*factor);
        }
        
        //cuaternios.Set(cuaternios.x,av,cuaternios.z, cuaternios.w);
        //
    }
    /**
        Mueve el angulo indicado
     */
    void rotar(Union union, float valor){
        Vector3 angulos=union.transform.localRotation.eulerAngles;
        float x=angulos.x;
        float y=angulos.y;
        float z=angulos.z;
        float t;
        if(union.giroX){
            float multiplicador=1;
            if(union.transform.localScale.x<0){
                multiplicador=-1;
            }
            t=x+valor*multiplicador;
            if(t<0) t=360+t;
            x=miClamp(t,union.minAnguloX,union.maxAnguloX);
            
        }
        if(union.giroY){
            t=y+valor;
            y=miClamp(t,union.minAnguloY,union.maxAnguloY);
        }
        if(union.giroZ){
            t=z+valor;
            
            z=miClamp(t,union.minAnguloZ,union.maxAnguloZ);
        }
        union.transform.localRotation=Quaternion.Euler(x,y,z);
    }
    float miClamp(float valor, float minimo, float maximo){
        
        if(minimo<0){
            float positivo=360+minimo;
            if(valor< maximo){
                return valor;
            }
            if(valor>positivo){
                return valor;
            }

            return Mathf.Clamp(valor,maximo, positivo);
        }
        return Mathf.Clamp(valor ,minimo,maximo);
    }
}
