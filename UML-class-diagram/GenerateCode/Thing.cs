using System;
public class Thing {
	public int ThingId;
	public char ThingType;
	public string Name;

	public bool Delete() {
		throw new System.Exception("Not implemented");
	}

	private ReportPostion reportPostion;
	private ScanningPosition scanningPosition;

}
