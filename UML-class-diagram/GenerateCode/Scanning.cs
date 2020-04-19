using System;
public class Scanning {
	private int scaningId;
	private Room room;
	private ScanningPosition[] positions;

	public void AddNewPosition(ref ScanningPosition newPosition) {
		throw new System.Exception("Not implemented");
	}
	public bool SendToDB() {
		throw new System.Exception("Not implemented");
	}
	public void DeletePosition(ref ScanningPosition position) {
		throw new System.Exception("Not implemented");
	}
	public void MoveThingToThisRoom(ref ScanningPosition position) {
		throw new System.Exception("Not implemented");
	}
	public ScanningReport GetScanningReport() {
		throw new System.Exception("Not implemented");
	}

	private ScanningPosition scanningPosition;

}
