namespace TripTrackService.Models; 
public struct Team{
    public int ownerId{get; set;}
    public string name{get; set;}
    public string info{get; set;}
    public List<int> members{get; set;}
    public List<int> trips{get; set;}
    public List<int> vehicles{get; set;}
    }