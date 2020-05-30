using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorScript : MonoBehaviour
{
    public Animator Door;
    public AudioSource Audio;
    public Animator Elevator;

    private void OnTriggerEnter(Collider other)
    {
        Audio.Play();
        Door.SetBool("GoingUp",true);
        Door.SetBool("Opening",false);
        StartCoroutine(GoUp());
    }
    IEnumerator GoUp() {
        yield return new WaitForSeconds(1);
        Elevator.SetBool("GoingUp",true);
        Door.SetBool("ElevatorUp",true);
        yield return new WaitForSeconds(4);
        Elevator.SetBool("GoingUp",false);
        Door.SetBool("ElevatorUp",false);
        SceneManager.LoadScene("Level2");
    }
}
