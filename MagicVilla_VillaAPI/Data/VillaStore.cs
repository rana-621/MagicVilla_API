using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaUpdateDTO> villaList = new List<VillaUpdateDTO>
        {
            new VillaUpdateDTO {Id =1 , Name ="Pool View", Occupancy=100 , Sqft=4 },
            new VillaUpdateDTO {Id =2 , Name="Beach View" , Occupancy=300 , Sqft=3 },

        };
    }
}
