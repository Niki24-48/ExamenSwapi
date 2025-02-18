namespace ExamenAPI.Model
{
    public class People
    {
        public int id { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color {get; set;}
        public string skin_color {get; set;}
        public string eye_color {get; set;}
        public string birth_year {get; set;}
        public string gender {get; set;}
        public DateTime? created {get; set;}
        public DateTime? edited {get; set;}
        public string name {get; set;}
        public string homeworld {get; set;}
        public string url {get; set;}
    }
}
