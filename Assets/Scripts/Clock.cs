using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SurvivalShooter
{
    public class Clock : MonoBehaviour
    {
        public Text timerText;
        public float countdownTime = 60;

        // Update is called once per frame
        void Update ()
        {
            countdownTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(countdownTime / 60f);
            int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);

            string TimeRemaining = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerText.text = TimeRemaining;
        }
    }
}
