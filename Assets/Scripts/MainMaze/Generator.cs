using UnityEngine;
using System.Collections;

//<summary>
//Basic class for maze generation logic
//</summary>
public class Generator {
	private int MazeRows;
	private int MazeColumns;
	// private Unit[,] Map;
	private int[,] Map = new int[,] {
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 5, 0, 0, 0, 0, 6, 12, 5, 0, 0, 0, 0}, 
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 3, 7, 3, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 6, 12, 12, 12, 9, 3, 3, 0, 7, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 6, 4, 12, 12, 9, 3, 0, 3, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 12, 12, 12, 12, 1, 1, 3, 3, 6, 12, 12, 1, 0, 3, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 6, 4, 4, 5, 3, 3, 3, 3, 3, 0, 0, 2, 12, 9, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 12, 1, 2, 8, 8, 9, 3, 3, 11, 3, 3, 0, 0, 3, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 7, 10, 0, 12, 12, 12, 1, 2, 12, 8, 9, 0, 0, 3, 0, 6, 4, 5},
		{6, 4, 12, 12, 5, 0, 0, 0, 0, 0, 0, 3, 10, 5, 3, 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 10, 12, 0, 0, 1},
		{2, 1, 0, 0, 3, 0, 0, 3, 0, 0, 0, 10, 5, 3, 3, 0, 0, 6, 8, 1, 0, 0, 0, 0, 0, 0, 0, 10, 8, 9},
		{2, 1, 0, 6, 8, 12, 12, 8, 12, 4, 12, 5, 2, 8, 9, 0, 0, 3, 7, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{2, 1, 0, 3, 6, 4, 4, 4, 5, 3, 0, 10, 9, 0, 0, 0, 0, 2, 1, 2, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{2, 1, 0, 3, 10, 8, 0, 8, 9, 3, 0, 0, 0, 0, 0, 0, 0, 3, 11, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{2, 1, 0, 10, 12, 12, 8, 12, 12, 9, 0, 0, 0, 0, 0, 0, 0, 10, 12, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};

	private int[,] Lamp = new int[,] {
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 0, 0, 0, 0, 4, 8, 1, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 4, 8, 4, 1, 2, 1, 0, 1, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 4, 8, 4, 1, 2, 0, 2, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 8, 4, 8, 0, 0, 1, 2, 4, 8, 4, 1, 0, 1, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 4, 0, 4, 2, 1, 2, 1, 2, 0, 0, 2, 4, 8, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 8, 0, 0, 0, 8, 0, 1, 2, 1, 2, 1, 0, 0, 1, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 8, 4, 8, 0, 0, 8, 0, 8, 0, 0, 2, 0, 2, 0, 1},
		{ 4, 0, 4, 8, 4, 0, 0, 0, 0, 0, 0, 1, 2, 1, 2, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 8, 4, 0, 0, 1},
		{ 2, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 2, 1, 2, 1, 0, 0, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 1},
		{ 0, 0, 0, 4, 0, 8, 4, 8, 4, 0, 4, 1, 2, 0, 8, 0, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 2, 1, 0, 2, 0, 4, 0, 4, 0, 1, 0, 2, 1, 0, 0, 0, 0, 2, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 0, 0, 1, 0, 8, 0, 8, 1, 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 2, 1, 0, 2, 8, 4, 8, 4, 8, 1, 0, 0, 0, 0, 0, 0, 0, 2, 8, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};

	public Generator(int rows, int columns){
		MazeRows = Mathf.Abs(rows);
		MazeColumns = Mathf.Abs(columns);
	}

	public void GenerateMaze(){
    }

	public int GetMazeUnit(int row, int column){
		if (row >= 0 && column >= 0 && row < MazeRows && column < MazeColumns) {
			return Map[row,column];
		}else{
			Debug.Log(row+" "+column);
			throw new System.ArgumentOutOfRangeException();
		}
	}

	public int GetLampUnit(int row, int column){
		if (row >= 0 && column >= 0 && row < MazeRows && column < MazeColumns) {
			return Lamp[row,column];
		}else{
			Debug.Log(row+" "+column);
			throw new System.ArgumentOutOfRangeException();
		}
	}
}
