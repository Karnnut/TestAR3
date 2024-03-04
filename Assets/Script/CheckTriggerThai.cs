using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTriggerThai : MonoBehaviour
{
    public static List<bool> check_list = new List<bool>();
    public GameObject Thaiword1_prefab;
    public GameObject Thaiword2_prefab;
    public GameObject Thaiword3_prefab;

    public GameObject Engword1_prefab;
    public GameObject Engword2_prefab;
    public GameObject Engword3_prefab;

    public GameObject Effect;

    public Transform triggert1_pos;
    public Transform triggert2_pos;
    public Transform triggert3_pos;


    private bool check_t1 = false;
    private bool check_t2 = false;
    private bool check_t3 = false;

    private bool check_e1 = false;
    private bool check_e2 = false;
    private bool check_e3 = false;

    private bool hasWon = false; // Track if the game has been won

    public void Update()
    {
        // Debug.Log(check_t2);
        // Check if all objects are in the trigger and the game has not already been won
        if (check_list.Count == 6)
        {
            Debug.Log("Win");
            Effect.SetActive(true);
            hasWon = true; // Set the flag to prevent multiple "Win" logs
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Thaiword1") && gameObject.name == "trigger_t1")
        {
            Debug.Log("Thaiword1 entered the trigger");
            //Thaiword1_prefab.transform.position = new Vector3(triggert1_pos.position.x, triggert1_pos.rotation.y, triggert3_pos.rotation.z);
            check_t1 = true;
            check_list.Add(true);
            Debug.Log(check_t1);
        }
        else if (other.CompareTag("Thaiword2") && gameObject.name == "trigger_t2")
        {
            Debug.Log("Thaiword2 entered the trigger");
            check_t2 = true;
            check_list.Add(true);
            Debug.Log(check_t2);
        }
        else if (other.CompareTag("Thaiword3") && gameObject.name == "trigger_t3")
        {
            Debug.Log("Thaiword3 entered the trigger");
            check_t3 = true;
            check_list.Add(true);
            Debug.Log(check_t3);
        }
        else if (other.CompareTag("Engword1") && gameObject.name == "trigger_e1")
        {
            Debug.Log("Engword1 entered the trigger");
            check_e1 = true;
            check_list.Add(true);
            Debug.Log(check_e1);
        }
        else if (other.CompareTag("Engword2") && gameObject.name == "trigger_e2")
        {
            Debug.Log("Engword2 entered the trigger");
            check_e2 = true;
            check_list.Add(true);
            Debug.Log(check_e2);
        }
        else if (other.CompareTag("Engword3") && gameObject.name == "trigger_e3")
        {
            Debug.Log("Engword3 entered the trigger");
            check_e3 = true;
            check_list.Add(true);
            Debug.Log(check_e3);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Thaiword1") && gameObject.name == "trigger_t1")
        {
            Debug.Log("Thaiword1 exited the trigger");
            check_t1 = false;
            check_list.Remove(true); // Remove the variable from the list
            Debug.Log(check_t1);
        }
        else if (other.CompareTag("Thaiword2") && gameObject.name == "trigger_t2")
        {
            Debug.Log("Thaiword2 exited the trigger");
            check_t2 = false;
            check_list.Remove(true); // Remove the variable from the list
            Debug.Log(check_t2);
        }
        else if (other.CompareTag("Thaiword3") && gameObject.name == "trigger_t3")
        {
            Debug.Log("Thaiword3 exited the trigger");
            check_t3 = false;
            check_list.Remove(true); // Remove the variable from the list
            Debug.Log(check_t3);
        }
        else if (other.CompareTag("Engword1") && gameObject.name == "trigger_e1")
        {
            Debug.Log("Engword1 exited the trigger");
            check_e1 = false;
            check_list.Remove(true); // Remove the variable from the list
            Debug.Log(check_e1);
        }
        else if (other.CompareTag("Engword2") && gameObject.name == "trigger_e2")
        {
            Debug.Log("Engword2 exited the trigger");
            check_e2 = false;
            check_list.Remove(true); // Remove the variable from the list
            Debug.Log(check_e2);
        }
        else if (other.CompareTag("Engword3") && gameObject.name == "trigger_e3")
        {
            Debug.Log("Engword3 exited the trigger");
            check_e3 = false;
            check_list.Remove(true); // Remove the variable from the list
            Debug.Log(check_e3);
        }


    }
}
