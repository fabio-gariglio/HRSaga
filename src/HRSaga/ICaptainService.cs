using HRSaga.GameContext;

namespace HRSaga
{
    public interface ICaptainService
    {
        CaptainModel Get();

        void Save(CaptainModel captain);
    }
}