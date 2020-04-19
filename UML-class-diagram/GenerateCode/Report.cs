using System;
public class Report {
	public int ReportId;
	public string Name;
	public Room Room;
	public DateTime CreateDate;
	public ReportPosition[] Positions;

	public bool ExportToPDF() {
		throw new System.Exception("Not implemented");
	}
	public bool Delete() {
		throw new System.Exception("Not implemented");
	}

	private ReportPostion[] reportPostions;
	private Room room;

}
