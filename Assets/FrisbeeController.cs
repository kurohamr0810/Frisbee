using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrisbeeController : MonoBehaviour
{
    [SerializeField] float risePower = 50f;
    [SerializeField] float rotatePower= 80f;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem outParticle;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RiseObjInput();
        RotateObjInput();
    }

    //フリスビーを上昇させる
    private void RiseObjInput()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.AddRelativeForce(Vector3.up * risePower);
        }
    }

    //フリスビーを操作
    private void RotateObjInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotatePower * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotatePower * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Safety")
        {
            Debug.Log("なんもしない");
        }else if(collision.gameObject.tag == "Success")
        {
            SuccessProcessing();
        }
        else
        {
            OutProcessing();
        }
    }

    private void SuccessProcessing()
    {
        successParticle.Play();
        Invoke("LoadActiveStage", 2f);
    }

    private void LoadNextStage()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void LoadActiveStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OutProcessing()
    {
        outParticle.Play();
    }






}
