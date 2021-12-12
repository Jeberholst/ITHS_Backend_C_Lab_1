using ITHS_Backend_C_Lab_1.DTOs;
using ITHS_Backend_C_Lab_1.Entities;

namespace ITHS_Backend_C_Lab_1.Repo
{
    public interface IAnimalRepo
    {
        List<Animal> GetAll();
        
        Animal FindByUid(int uid);

        Animal CreateAnimal(CreateAnimalDto animal);

        Animal UpdateAnimal(UpdateAnimalDto updateAnimalDto, int uid);

        void DeleteAnimal(int uid);
    }
}