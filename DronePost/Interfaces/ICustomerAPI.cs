using DronePost.DataModel;

namespace DronePost.Interfaces
{
    public interface ICustomerAPI
    {
        void GetPackage(Package package);
        void AddPackage(Package package, Station stationToAdd);
        void ChangePersonalData();
    }
}
