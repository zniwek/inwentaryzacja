using System;
public class Asset {
	public int AssetId;
	public AssetType AssetType;
	public string Name;

	public bool Delete() {
		throw new System.Exception("Not implemented");
	}

	private AssetType assetType;

	private ReportPostion reportPostion;
	private ScanningPosition scanningPosition;

}
