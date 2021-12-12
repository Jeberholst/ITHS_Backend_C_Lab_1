namespace ITHS_Backend_C_Lab_1.DTOs
{
    public class AnimalDto
    {
        public int Uid { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public string ToUpdateString()
        {
            return Name;
        }
    }
}