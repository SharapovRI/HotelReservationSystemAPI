namespace HotelReservationSystemAPI.Business.QueryModels
{
    public class AdditionalFacilityQueryModel : QueryModel
    {
        public int HotelId { get; set; }

        public int MinCost { get; set; } = 0;

        public int MaxCost { get; set; } = int.MaxValue;

        public bool IsCostValid()
        {
            if(MinCost < 0) return false;
            if (MinCost > MaxCost) return false;
            return true;
        }
    }
}
