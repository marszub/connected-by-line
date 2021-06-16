using System.Collections;
using UnityEngine;

namespace Assets.Line
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public GameObject player1;
        public GameObject player2;

        public Vector2 player1pos;
        public Vector2 player2pos;

        public float player1speed;
        public float player2speed;

        public float player1angspd;
        public float player2angspd;

        public GameObject chain;
        public int chainLength;

        public float zero;
    }
}