using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyIndicator : MonoBehaviour
{
    public Transform player;
    public List<Transform> targets;
    private Transform target;
    public Transform arrow;
    public float rotationSpeed = 150.0f; 
    private float myX = 0;
    private float myY = 0;
    private Vector3 _vectorToTarget;
    bool lastRotationX;
    bool lastRotationY;

    private void Start() {
    if (targets.Count == 0)
        {
            Debug.LogError("Aucune cible définie dans la liste.");
            return;
        }

        target = targets[Random.Range(0, targets.Count)];
    } 
    private void Update()
    {

        Vector3 directionToPlayer = player.position - transform.position;

        //float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        Vector3 targetDirection = target.position - player.position;
        
        Vector3 targetPosition = target.position;
        
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(targetDirection.x) > Mathf.Abs(targetDirection.y))
        {
            if (targetDirection.x > 0)
            {
                //Debug.Log("à droite");
                //Debug.Log(arrow.position.x - player.position.x );
                //transform.position =  player.position  + new Vector3(0.70f, -0.1f, 0);
                if (arrow.position.x - player.position.x < 0.85f) {
                    if (lastRotationY == true) {
                        transform.RotateAround(player.position, Vector3.forward * -1, rotationSpeed * Time.deltaTime);
                    } else {
                        transform.RotateAround(player.position, Vector3.forward, rotationSpeed * Time.deltaTime);
                    } lastRotationX = true;
                }
            }
            else
            {
                //Debug.Log("à gauche");
                //transform.position = player.position  + new Vector3(-0.70f, -0.1f, 0);
                if (arrow.position.x - player.position.x > -0.85f) {
                    if (lastRotationY == true) {
                        transform.RotateAround(player.position, Vector3.forward, rotationSpeed * Time.deltaTime);
                    } else {
                        transform.RotateAround(player.position, Vector3.forward * -1, rotationSpeed * Time.deltaTime);
                    } lastRotationX = false;
                }
                
            }
        }
        else
        {
            if (targetDirection.y > 0)
            {
                //Debug.Log("au-dessus");
                //transform.position = player.position  + new Vector3(0.03f, 0.88f, 0);
                if (arrow.position.y - player.position.y < 0.85f)
                {
                    if (lastRotationX == true) {
                        transform.RotateAround(player.position, Vector3.forward, rotationSpeed * Time.deltaTime);
                    } else {
                        transform.RotateAround(player.position, Vector3.forward * -1, rotationSpeed * Time.deltaTime);
                    } lastRotationY = true;
                }
                
            }
            else
            {
                //Debug.Log("en dessous");
                //transform.position = player.position  + new Vector3(0.03f, -1.14f, 0);
                if (arrow.position.y - player.position.y > -0.85f)
                {
                    if (lastRotationX == true) {
                        transform.RotateAround(player.position, Vector3.forward* -1, rotationSpeed * Time.deltaTime);
                    } else {
                        transform.RotateAround(player.position, Vector3.forward, rotationSpeed * Time.deltaTime);
                    } lastRotationY = false;
                }
                
            }
        }

        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }


    public void ChangeTargetByName(string targetName)
    {
        Transform newTarget = targets.Find(t => t.name == targetName);

        if (newTarget != null)
        {
            Debug.Log("Changement de cible vers : " + newTarget.name);
            target = newTarget;
        }
        else
        {
            Debug.LogWarning("Aucune cible trouvée avec le nom : " + targetName);
        }
    }

}