using System;
public class ReportService {
	private ApiController api;

	public Report GetReportById(ref int id) {
		throw new System.Exception("Not implemented");
	}
	public ReportHeader[] GetReportsHeaders() {
		throw new System.Exception("Not implemented");
	}
	public bool ExportReportToPDF(ref int id) {
		throw new System.Exception("Not implemented");
	}
	public bool DeleteReport(ref int id) {
		throw new System.Exception("Not implemented");
	}
	public int AddNewReport(ref ReportPropotype newReport) {
		throw new System.Exception("Not implemented");
	}

	private APIController aPIController;

}
