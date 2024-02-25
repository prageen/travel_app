using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Bl.Registration
{
    public interface IRegistration
    {
        public ResponseModel AddRegistration(RegistrationDto registrationDto);
        public ResponseModel UpdateRegistration(RegistrationDto registrationDto, int registrationId);
        public ResponseModel ListRegistration();
        public ResponseModel GetRegistration(int id);
        public ResponseModel ActivateRegistration(int registrationId);
        public ResponseModel DeactivateRegistration(int registrationId);

    }
}
