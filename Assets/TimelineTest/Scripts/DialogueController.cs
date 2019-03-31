using TMPro;
using UnityEngine;

namespace CleverCrow.TimelineTest {
    public class DialogueController : MonoBehaviour {
        public TextMeshProUGUI speakerOutput;
        public TextMeshProUGUI lineOutput;
        
        public void Speak (string line, string speaker, float alpha) {
            lineOutput.alpha = alpha;
            lineOutput.SetText(line);;

            speakerOutput.alpha = alpha;
            speakerOutput.SetText(speaker);
        }
    }
}