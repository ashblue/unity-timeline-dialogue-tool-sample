using TMPro;
using UnityEngine;

namespace CleverCrow.TimelineTest {
    public class DialogueController : MonoBehaviour {
        public TextMeshProUGUI speakerOutput;
        public TextMeshProUGUI lineOutput;
        
        public void Speak (string line, string speaker) {
            lineOutput.SetText(line);;
            speakerOutput.SetText(speaker);
            
            Debug.Log($"{speaker}: {line}");
        }
    }
}