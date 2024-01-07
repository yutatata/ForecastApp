namespace ForecastApp.DisastersAPIModel
{
    using System;
    using System.Collections.Generic;

    public class DisastersResponse
    {
        public int Count { get; set; }
        public bool Overflow { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<DisasterEvent> Results { get; set; }
    }

    public class DisasterEvent
    {
        public int Relevance { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> Labels { get; set; }
        public int Rank { get; set; }
        public object LocalRank { get; set; }
        public object PhqAttendance { get; set; }
        public List<object> Entities { get; set; }
        public int Duration { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Updated { get; set; }
        public DateTime FirstSeen { get; set; }
        public string Timezone { get; set; }
        public List<double> Location { get; set; }
        public Geo Geo { get; set; }
        public string Scope { get; set; }
        public string Country { get; set; }
        public List<List<string>> PlaceHierarchies { get; set; }
        public string State { get; set; }
        public bool BrandSafe { get; set; }
        public bool Private { get; set; }
    }

    public class Geo
    {
        public Geometry Geometry { get; set; }
    }

    public class Geometry
    {
        public List<double> Coordinates { get; set; }
        public string Type { get; set; }
    }

   

}