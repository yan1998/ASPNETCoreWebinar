namespace DIContainer.Services
{
    public class GuidWrapperService : IGuidWrapperService
    {
        private readonly IGuidService _guidService;

        public GuidWrapperService(IGuidService guidService)
        {
            _guidService = guidService;
        }

        public void ShowGuid()
        {
            _guidService.ShowGuid();
        }
    }
}
