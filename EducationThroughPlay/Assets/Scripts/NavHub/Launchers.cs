using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launchers : MonoBehaviour
{
    // Float that controls the bounce height
  [Range(100,10000)]
  public float bounceheight;

  // String that controls which scene is loaded
  public string sceneName;

  IEnumerator LoadNewScene()
  {
    // Wait so player sees travel up
    yield return new WaitForSeconds(1.5f);
    // Switch to the designated scene
    SceneManager.LoadScene(sceneName);
  }

  // When this object collides with another
  private void OnCollisionEnter(Collision player)
  {
    // Get the player object
    GameObject Launcher = player.gameObject;
    // Get its rigid body
    Rigidbody rb = Launcher.GetComponent<Rigidbody>();
    // Fling it up
    rb.AddForce(Vector3.up * bounceheight);
    // Call load new Scene
    StartCoroutine(LoadNewScene());
  }
}
