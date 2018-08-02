using HRSaga;
using HRSaga.GameContext;

namespace Host
{
    public class InMemoryCaptainService : ICaptainService
    {
        private CaptainModel _captain = null;
        
        public CaptainModel Get()
        {
            return _captain;
        }

        public void Save(CaptainModel captain)
        {
            _captain = captain;
        }
    }
}