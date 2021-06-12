using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Line
{
    public class PlayersBehaviour : MonoBehaviour
    {
        public PlayerSettings settings;
        private Rigidbody2D player1;
        private Rigidbody2D player2;
        private List<GameObject> chainParts;

        private void GenerateChain()
        {
            Vector2 chainDirection = settings.player2pos - settings.player1pos;

            chainParts.Add(Instantiate(settings.chain, settings.player2pos, Quaternion.LookRotation(forward: Vector3.forward, upwards: Quaternion.Euler(0, 0, 90) * chainDirection), transform));
            HingeJoint2D jointPlayer2 = chainParts[0].GetComponent<HingeJoint2D>() as HingeJoint2D;
            jointPlayer2.connectedAnchor = Vector2.zero;
            jointPlayer2.connectedBody = player2;

            for (int i = 0; i < settings.chainLength + 1; i++)
            {
                chainParts.Add(Instantiate(settings.chain, settings.player2pos - chainDirection * (i + 1) / (settings.chainLength + 1), Quaternion.LookRotation(forward: Vector3.forward, upwards: Quaternion.Euler(0, 0, 90) * chainDirection), transform));
                HingeJoint2D joint = chainParts[i + 1].GetComponent<HingeJoint2D>();
                joint.connectedBody = chainParts[i].GetComponent<Rigidbody2D>();
            }

            HingeJoint2D jointPlayer1 = chainParts[settings.chainLength + 1].AddComponent<HingeJoint2D>() as HingeJoint2D;
            HingeJoint2D originalJoint = settings.chain.GetComponent<HingeJoint2D>();
            jointPlayer1.connectedBody = player1;
            jointPlayer1.connectedAnchor = Vector2.zero;
            jointPlayer1.anchor = -originalJoint.anchor;
        }

        void Start()
        {
            chainParts = new List<GameObject>();
            player1 = Instantiate(settings.player1, settings.player1pos, Quaternion.identity, transform).GetComponent<Rigidbody2D>();
            player2 = Instantiate(settings.player2, settings.player2pos, Quaternion.identity, transform).GetComponent<Rigidbody2D>();
            GenerateChain();
        }

        void FixedUpdate()
        {
            float v1Axis = Input.GetAxis("P1Vertical");
            float h1Axis = Input.GetAxis("P1Horizontal");
            Vector2 player1direction = new Vector2(h1Axis, v1Axis);
            player1.AddForce(player1direction.normalized * settings.player1speed);

            float v2Axis = Input.GetAxis("P2Vertical");
            float h2Axis = Input.GetAxis("P2Horizontal");
            Vector2 player2direction = new Vector2(h2Axis, v2Axis);
            player2.AddForce(player2direction.normalized * settings.player2speed);
        }
    }
}
