import pandas as pd;
import os;

Halo_Path = r"O:\UnityProj\Voids-VR-Scene_Unity\Assets\Data\mfiducial_663_halos.dat";
Void_Path = "./centers_all_Quijote_fiducial_663_RSD_ss1.0_z0.00_d00.out";

def selectHalos(xLimit, yLimit, zLimit, outPath):
    halo_Data = pd.read_csv(Halo_Path, sep=" ");
    
    halo_InRange = halo_Data.loc[(halo_Data["x"] < xLimit) & (halo_Data["y"] < yLimit)& (halo_Data["z"] < zLimit)];
    
    halo_InRange = halo_InRange[["x","y","z"]];
    
    halo_InRange.to_csv(outPath, index=False, header=False);
    

if __name__ == "__main__":
    selectHalos(100,100,100,"./halos_In_100.dat");