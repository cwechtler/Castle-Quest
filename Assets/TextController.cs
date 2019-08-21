using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text text;
	
	private enum States {Start, CastleDoor_0, CastleDoor_1, Open, Guards_0, Guards_1, Attack, Wall, 
						TrapDoor_0, TrapDoor_1, TrapDoor_2, TrapDoor_3, ClimbDown_0, ClimbDown_1, Fall, Hallway_0, 
						Hallway_1, UpStairs, DownStairs, GreenDoor, RedDoor, Save,};
	private States myState;
	
	void Start () {
		myState = States.Start;
	}
	
	void Update () {
		if (Input.GetKey("escape"))
			Application.Quit();
			
		print (myState);
		if 		(myState == States.Start) 				{start();}
		else if (myState == States.CastleDoor_0) 		{CastleDoor_0();}
		else if (myState == States.CastleDoor_1) 		{CastleDoor_1();}
		else if (myState == States.Open) 				{Open();}	
		else if (myState == States.Guards_0)			{Guards_0();}
		else if (myState == States.Guards_1)			{Guards_1();}
		else if (myState == States.Attack)				{Attack();}
		else if (myState == States.Wall)				{Wall();}
		else if (myState == States.TrapDoor_0)			{TrapDoor_0();}
		else if (myState == States.TrapDoor_1)			{TrapDoor_1();}
		else if (myState == States.TrapDoor_2)			{TrapDoor_2();}
		else if (myState == States.TrapDoor_3)			{TrapDoor_3();}
		else if (myState == States.ClimbDown_0)			{ClimbDown_0();}
		else if (myState == States.ClimbDown_1)			{ClimbDown_1();}
		else if (myState == States.Fall)				{Fall();}
		else if (myState == States.Hallway_0)			{Hallway_0();}
		else if (myState == States.Hallway_1)			{Hallway_1();}
		else if (myState == States.UpStairs)			{UpStairs();}
		else if (myState == States.DownStairs)			{DownStairs();}
		else if (myState == States.GreenDoor)			{GreenDoor();}
		else if (myState == States.RedDoor)				{RedDoor();}
		else if (myState == States.Save)				{Save();}		
	}
		
	#region State handler methods
	void start () {
		text.text = "You have been called upon to save the princess from the evil Wizard.\n\n" +
					"Press Space Bar to continue";
		if 		(Input.GetKeyDown(KeyCode.Space))		{myState = States.CastleDoor_0;}
	}
	
	void CastleDoor_0 (){
		text.text = "After your long travels through the woods you find yourself in front of a castle door.\n\n" +
					"Press O to open, R to go right or L to go left";
		if 		(Input.GetKeyDown(KeyCode.O))			{myState = States.Open;}	
		else if (Input.GetKeyDown(KeyCode.R))			{myState = States.Guards_0;}	
		else if (Input.GetKeyDown(KeyCode.L))			{myState = States.TrapDoor_0;}		
	}
	
	void CastleDoor_1 (){
		text.text = "You find yourself in front of the castle door.\n\n" +
					"Press O to open, R to go right or L to go left";
		if 		(Input.GetKeyDown(KeyCode.O))			{myState = States.Open;}	
		else if (Input.GetKeyDown(KeyCode.R))			{myState = States.Guards_0;}	
		else if (Input.GetKeyDown(KeyCode.L))			{myState = States.TrapDoor_0;}	
	}
	
	void Open(){
		text.text = "The castle door is locked. You will need to find another way into the castle\n\n" +
					"Press B to go back";
		if 		(Input.GetKeyDown(KeyCode.B))			{myState = States.CastleDoor_1;}
	}

	void Guards_0 (){
		text.text = "You encounter some guards.\n\n" +
					"Press A to attack them, S to sneek around them, or B to go back";
		if 		(Input.GetKeyDown(KeyCode.A))			{myState = States.Attack;}
		else if (Input.GetKeyDown(KeyCode.S))			{myState = States.Wall;}
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.CastleDoor_1;}
	}
	
	void Guards_1 (){
		text.text = "You Climb over the wall and encounter some guards.\n\n" +
					"Press A to attack them, S to sneek around them or B to go back";
		if 		(Input.GetKeyDown(KeyCode.A))			{myState = States.Attack;}
		else if (Input.GetKeyDown(KeyCode.S))			{myState = States.CastleDoor_1;}
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.TrapDoor_1;}			
	}
	
	void Attack (){
		text.text = "The guards catch you but after some quick thinking you manage to escape into the woods.\n\n" +
					"Press Space Bar to continue";
		if 		(Input.GetKeyDown(KeyCode.Space))		{myState = States.CastleDoor_0;}
	}	
	
	void Wall (){
		text.text = "You manage to sneek around them and run into a wall.\n\n" +
					"Press C to climb over the wall or B to go back";
		if 		(Input.GetKeyDown(KeyCode.C))			{myState = States.TrapDoor_1;}	
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.Attack;}			
	}

	void TrapDoor_0 (){
		text.text = "You find a trap door and a wall.\n\n" +
					"Press E to enter the trap door, X to examine it, C climb the wall or B to go back";
		if 		(Input.GetKeyDown(KeyCode.E))			{myState = States.ClimbDown_0;}
		else if (Input.GetKeyDown(KeyCode.X))			{myState = States.Fall;}
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.CastleDoor_1;}
		else if (Input.GetKeyDown(KeyCode.C))			{myState = States.Guards_1;}
	}
	
	void TrapDoor_1 (){
		text.text = "You find a trap door.\n\n" +
					"Press E to enter it, X to examine it, Space Bar to keep going, or B to go back";
		if 		(Input.GetKeyDown(KeyCode.E))			{myState = States.ClimbDown_0;}
		else if (Input.GetKeyDown(KeyCode.X))			{myState = States.Fall;}
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.Guards_1;}
		else if (Input.GetKeyDown(KeyCode.Space))		{myState = States.CastleDoor_1;}
	}
	
	void TrapDoor_2 (){
		text.text = "You climb back up and see the wall.\n\n" +
					"Press E to enter the Trap door, X to examine it, Space Bar to keep going, or B to go back";
		if 		(Input.GetKeyDown(KeyCode.E))			{myState = States.ClimbDown_0;}
		else if (Input.GetKeyDown(KeyCode.X))			{myState = States.Fall;}
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.Guards_1;}
		else if (Input.GetKeyDown(KeyCode.Space))		{myState = States.CastleDoor_1;}	
		
	}
	
	void TrapDoor_3 (){
		text.text = "You go back down the hall up the ladder were you see the wall.\n\n" +
					"Press E to enter the trap door, C climb the wall or B to go back to the castle door";
		if 		(Input.GetKeyDown(KeyCode.E))			{myState = States.ClimbDown_1;}
		else if (Input.GetKeyDown(KeyCode.C))			{myState = States.Guards_1;}	
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.CastleDoor_1;}		
	}	
	
	void ClimbDown_0 (){
		text.text = "You open the trap door and climb down the ladder and find yourself in a long hallway.\n\n" +
					"Press Space Bar to continue or B to go back up the ladder";
		if 		(Input.GetKeyDown(KeyCode.Space))		{myState = States.Hallway_0;}	
		else if (Input.GetKeyDown (KeyCode.B))			{myState = States.TrapDoor_2;}	
	}	
	
	void ClimbDown_1 (){
		text.text = "You climb down the ladder and find yourself in a long hallway.\n\n" +
					"Press Space Bar to continue or B to go back up the ladder";
		if 		(Input.GetKeyDown(KeyCode.Space))		{myState = States.Hallway_0;}	
		else if (Input.GetKeyDown (KeyCode.B))			{myState = States.TrapDoor_2;}	
	}	
	
	void Fall (){
		text.text = "You try to examine the door but slip and fall through the rickety door. " +
					"As you are falling you manage to grab the ladder to slow your fall and land unharmed. " +
					"You get up and find yourself in a long hallway.\n\n" +
					"Press Space Bar to continue or B to go back up the ladder";
		if 		(Input.GetKeyDown(KeyCode.Space))		{myState = States.Hallway_0;}	
		else if (Input.GetKeyDown (KeyCode.B))			{myState = States.TrapDoor_2;}	
	}	
	
	void Hallway_0(){
		text.text = "You quietly make you way to the end of the hallway. " +
					"You see two sets of stairs one goes up and one goes down..\n\n" +
					"Press U to go up the stairs, D to go down the stairs, B to go back";
		if 		(Input.GetKeyDown(KeyCode.U))			{myState = States.UpStairs;}
		else if (Input.GetKeyDown(KeyCode.D))			{myState = States.DownStairs;}
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.TrapDoor_3;}		
	}	
	
	void Hallway_1 (){
		text.text = "You quietly make you way back down the stairs to the hallway. " +
					"You see two sets of stairs one goes up and one goes down..\n\n" +
					"Press U to go up the stairs, D to go down the stairs, B to go back down the Hall";
		if 		(Input.GetKeyDown(KeyCode.U))			{myState = States.UpStairs;}
		else if (Input.GetKeyDown(KeyCode.D))			{myState = States.DownStairs;}
		else if (Input.GetKeyDown(KeyCode.B))			{myState = States.TrapDoor_3;}		
	}	
	
	void UpStairs (){
		text.text = "You find the princess locked in her cell. " + 
					"You must find the key before you can free her.\n\n" +
					"Press B to go back";
		if 		(Input.GetKeyDown(KeyCode.B))			{myState = States.Hallway_1;}	
	}	
	
	void DownStairs (){
		text.text = "You quietly make your way down the stairs only to be faced with yet another choice. " +
					"You see a red door and a green door.\n\n" +
					"Press R to to open the red door, G to open the green Door";
		if 		(Input.GetKeyDown(KeyCode.R))			{myState = States.RedDoor;}		
		else if (Input.GetKeyDown(KeyCode.G))			{myState = States.GreenDoor;}	
	}
	
	void RedDoor (){
		text.text = "You find yourself in a room with a bunch of keys hanging on the wall. " +
					"After some time you finally find the key for the princesses cell.\n\n" +
					"Press S to go save the princess or G to open the green door to examine it first.";
		if 		(Input.GetKeyDown(KeyCode.S))			{myState = States.Save;}		
		else if (Input.GetKeyDown(KeyCode.G))			{myState = States.GreenDoor;}
	}
			
	void GreenDoor (){
		text.text = "You open the door and to your horror the Wizard is there waiting for you. " +
					"You bravely fight him but quickly realize you are no match for his wizardry. " +
					"Sudenly he raises his staff and casts a spell on you. " +
					"You become frozen in a block of ice to remain there for all eternity.\n" +
					"_____ YOU LOSE!!!! _____\n\n" +
					"Press Enter to start over";
		if 		(Input.GetKeyDown(KeyCode.Return))		{myState = States.Start;}	
	}	
	
	void Save (){
		text.text = "You quietly go back up the stairs to the Princesses cell. " +
					"You free the princess and escape the castle.\n\n" +
					"_____ YOU WIN!!!! _____\n\n" +
					"Press Enter to play again";
		if 		(Input.GetKeyDown(KeyCode.Return))		{myState = States.Start;}			
	}
	#endregion													
}		
		
		
		
		
		
		
		
