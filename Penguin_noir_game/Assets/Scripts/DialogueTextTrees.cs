using UnityEngine;
using System.Collections;

public class DialogueTextTrees : MonoBehaviour {

	public int Startloc;
	public int Xmsgs;
	public int ObjectIndex;
	public string TextToDisplay;

	void DialogueText(int i, int j, int k,string s)
	{
		Startloc = i;
		Xmsgs = j;
		ObjectIndex = k;
		TextToDisplay = s;
	}

	
}
