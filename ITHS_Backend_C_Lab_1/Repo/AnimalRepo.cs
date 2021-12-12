using ITHS_Backend_C_Lab_1.DTOs;
using ITHS_Backend_C_Lab_1.Entities;

namespace ITHS_Backend_C_Lab_1.Repo
{
    public class AnimalRepo : IAnimalRepo
    {
        private ApplicationContext _context;

        public AnimalRepo(ApplicationContext context)
        {
            _context = context;
            AddInitialData();
        }

        public List<Animal> GetAll()
        {
            return _context.Animals.ToList();
        }

        private void AddInitialData()
        {
            if (_context.Animals.Any()) return;
            List<Animal> mockData = new List<Animal>
            {
                new()
                {
                    Uid = 1,
                    Type = "Affenpinscher",
                    Name = "Bob"
                },
                new()
                {
                    Uid = 2,
                    Type = "Australian Cattle Dog",
                    Name = "Maja"
                },
                new()
                {
                    Uid = 3,
                    Type = "Basset Bleu de Gascogne",
                    Name = "Stella"
                },
                new()
                {
                    Uid = 4,
                    Type = "Irish Setter",
                    Name = "Dino"
                },
                new()
                {
                    Uid = 5,
                    Type = "Komondor",
                    Name = "Rico"
                },
                new()
                {
                    Uid = 6,
                    Type = "Labrador Retriever",
                    Name = "Cola"
                },
                new()
                {
                    Uid = 7,
                    Type = "Leonberger",
                    Name = "Sune"
                },
                new()
                {
                    Uid = 8,
                    Type = "Lhasa Apso",
                    Name = "Bella"
                },
                new()
                {
                    Uid = 9,
                    Type = "Maltese",
                    Name = "Lilly"
                },
                new()
                {
                    Uid = 10,
                    Type = "Newfoundland",
                    Name = "Malte"
                }
            };

            _context.Animals.AddRange(mockData);
            _context.SaveChanges();
        }


        public Animal FindByUid(int uid)
        {
            Animal animal = _context.Animals.Find(uid);
            return animal;
        }

        public Animal CreateAnimal(CreateAnimalDto createAnimalDto)
        {
            Animal newAnimal = new Animal();
            var nextUid = 1;

            if (_context.Animals.Any())
            {
                nextUid = _context.Animals.OrderBy(x => x.Uid).Last().Uid + 1;
            }

            newAnimal.Uid = nextUid;
            newAnimal.Type = createAnimalDto.Type;
            newAnimal.Name = createAnimalDto.Name;

            _context.Animals.Add(newAnimal);
            _context.SaveChanges();

            return newAnimal;
        }

        public Animal UpdateAnimal(UpdateAnimalDto updateAnimalDto, int uid)
        {
            Animal isExistingAnimal = _context.Animals.FirstOrDefault(x => x.Uid == uid);
            if (isExistingAnimal is not null)
            {
                isExistingAnimal.Name = updateAnimalDto.Name;
            }

            _context.SaveChanges();
            return isExistingAnimal;
        }

        public void DeleteAnimal(int uid)
        {
            _context.Animals.Remove(FindByUid(uid));
            _context.SaveChanges();
        }
    }
}