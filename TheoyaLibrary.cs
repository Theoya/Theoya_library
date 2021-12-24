using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheoyaLibrary : MonoBehaviour
{


    //load game scene
    public void loadScene(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    //toggles an object on or off if on
    public void toggleObject(GameObject object){
        if(object.activeSelf == true){
            object.SetActive(false);
        }
        else{
            object.SetActive(true);
        }

    }

    //checks if an object is within a distance of another
    public bool isUnderVariable(Transform object1, Transform object2, float threshold){
        if(Vector3.Distance(object1.position, object2.position) <= threshold){
            return true;
        }
        return false;
    }

    //catch all function to allow an object to check what is underneath it
    //may need altering based off of object rotation
    public Transform downcheckFunction(){
        var downCheck = new Ray(this.transform.position, this.transform.forward);
        if (Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.forward), out hit, 1000))
        {
            return transform;
        }
    }

    //changes the objects color 
    public void colorChange(Color newcolor){
        gameObject.GetComponent<Renderer>().material.color = newcolor;
    }

    //changes the objects color 
    public void updateHealth(Image healthBar, float CurrentHealth, float MaxHealth){
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }

    //move canvas to loook at the camera
    public void canvasLook(){
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);
        transform.Rotate(0,180,0);
    }

    //move parent object to a position
    public void moveObject(Vector3 newPosition){
        transform.position = newPosition;
    }




}