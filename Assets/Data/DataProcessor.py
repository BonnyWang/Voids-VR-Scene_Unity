import pandas as pd
from sqlalchemy import false, true;

Halo_Path = r"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\mfiducial_663_halos.dat";
Void_Path = r"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\centers_all_Quijote_fiducial_663_RSD_ss1.0_z0.00_d00.out";
Cell_Path = r"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\Cells.txt";

def selectHalos(xLimit, yLimit, zLimit, outPath):
    halo_Data = pd.read_csv(Halo_Path, sep=" ");
    
    halo_InRange = halo_Data.loc[(halo_Data["x"] < xLimit) & (halo_Data["y"] < yLimit)& (halo_Data["z"] < zLimit)];
    
    halo_InRange = halo_InRange[["x","y","z"]];
    
    halo_InRange.to_csv(outPath, index=False, header=False);

def selectVoids(xLimit, yLimit, zLimit, outPath, outputCell = false, cellOutpath = ""):
    void_Data = pd.read_csv(Void_Path, sep=" ");
    
    void_InRange = void_Data.loc[(void_Data["x"] < xLimit) & (void_Data["y"] < yLimit)& (void_Data["z"] < zLimit)];
    
    if outputCell:
        for void in void_InRange["voidID"]:
            selectCells(void, cellOutpath);
    
    void_InRange = void_InRange[["x","y","z", "radius(Mpc/h)", "voidID"]];
    
    void_InRange.to_csv(outPath, index=False, header=False);
    
def selectCells(voidID, outPath):
    cells_Data = pd.read_csv(Cell_Path, sep=" ");
    
    cell = cells_Data.loc[cells_Data["voidID"] == voidID];
    
    cell.to_csv(outPath, index= False, header=False, mode="a");
      

if __name__ == "__main__":
    # selectHalos(100,100,100,"./halos_In_100.dat");
    selectVoids(100,100,100,"./voids_In_100.dat",true, "./cells_In_100.dat");