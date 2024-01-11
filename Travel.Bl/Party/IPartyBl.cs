using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Dto;

namespace Travel.Bl.Party
{
   public interface IPartyBl
    {
        public ResponseModel AddParty(PartyDto partyObj);

        public ResponseModel DeleteParty(int vehicleId);

        public ResponseModel UpdateParty(PartyDto partyObj, int vehicleId);
    }
}
