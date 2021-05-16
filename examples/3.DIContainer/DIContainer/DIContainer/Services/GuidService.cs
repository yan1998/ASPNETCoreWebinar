using System;

namespace DIContainer.Services
{
    public class GuidService : IGuidService
    {
        private Guid _guid;

        public GuidService()
        {
            _guid = Guid.NewGuid();
            Console.WriteLine($"GuidService constructor was called!");
        }

        public void ShowGuid()
        {
            Console.WriteLine($"Guid = {_guid}");
        }
    }
}
