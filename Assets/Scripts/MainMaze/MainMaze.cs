using UnityEngine;
using System.Collections;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class MainMaze : MonoBehaviour {
	public bool FullRandom = false;
	public int RandomSeed = 12345;
	public GameObject Floor = null;
	public GameObject Wall = null;
	public int Rows = 14;
	public int Columns = 30;
	public float UnitWidth = 4;
	public float UnitHeight = 4;
	// public GameObject GoalPrefab = null;
	// public GameObject HolePrefab = null;
	// public GameObject BulbPrefab = null;

	private Generator MazeGenerator = null;

	void Start () {
		if (!FullRandom) {
			Random.InitState(RandomSeed);
		}

		MazeGenerator = new Generator(Rows, Columns);

		// MazeGenerator.GenerateMaze();
		for (int row = 0; row < Rows; row++) {
			for(int column = 0; column < Columns; column++){
				float x = column * UnitWidth;
				float z = row * UnitHeight;
				int unit = MazeGenerator.GetMazeUnit(row, column);
				GameObject tmp;
				// tmp = Instantiate(Floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
				// tmp.transform.parent = transform;
				
				if(unit >= 8){
                    unit -= 8;
					tmp = Instantiate(Wall, new Vector3(x, 0, z+UnitHeight/2) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;// up
					tmp.transform.parent = transform;
				}
				if(unit >= 4){
                    unit -= 4;
					tmp = Instantiate(Wall, new Vector3(x, 0, z-UnitHeight/2) + Wall.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;// down
					tmp.transform.parent = transform;
				}
				if(unit >= 2){
                    unit -= 2;
					tmp = Instantiate(Wall, new Vector3(x-UnitWidth/2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject;// left
					tmp.transform.parent = transform;
				}
                if(unit >= 1){
                    unit -= 1;
					tmp = Instantiate(Wall, new Vector3(x+UnitWidth/2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;// right
					tmp.transform.parent = transform;
				}
				// if((row != 0 || column != 0)){
				// 	if(Random.Range(1, 11) == 1 && HolePrefab != null) {
				// 		tmp = Instantiate(HolePrefab,new Vector3(x + Random.Range(-1f, 1f), -0.94f, z + Random.Range(-1f, 1f)), Quaternion.Euler(0, 0, 0)) as GameObject;
				// 		tmp.transform.parent = transform;
				// 	} else if(GoalPrefab != null && Random.Range(1, 4) == 1) {
				// 		tmp = Instantiate(GoalPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 0)) as GameObject;
				// 		tmp.transform.parent = transform;
				// 	} else if(BulbPrefab != null && Random.Range(1, 6) == 1) {
				// 		tmp = Instantiate(BulbPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 0)) as GameObject;
				// 		tmp.transform.parent = transform;
				// 	}
				// }
			}
		}
	}
}
