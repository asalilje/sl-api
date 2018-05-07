using System.Collections.Generic;

namespace SLApi.Buses
{
    public class BusesModel
    {
        public ResponseData ResponseData { get; set; }      
    }

    public class ResponseData
    {
        public List<BusModel> Buses { get; set; }
    }

    public class BusModel
    {
        public string LineNumber { get; set; }
        public int JourneyDirection { get; set; }
        public string DisplayTime { get; set; }
    }
}