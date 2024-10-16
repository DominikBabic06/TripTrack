namespace TripTracker.Models
{
    public struct Trip
    {
        public int ID { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly arival { get; set; }
        public TimeOnly endTime { get; set; }
        public double departureMilage { get; set; } 
        public double arivalMilage { get; set; }
        public int driverID { get; set; }   
        public int vehicleID { get; set; }  
        public string reasonForTrip { get; set;}
        public TripType typeOfTrip { get; set; }
        public TripStatus status { get; set; }
        public int teamID { get; set; } 
    }  
}