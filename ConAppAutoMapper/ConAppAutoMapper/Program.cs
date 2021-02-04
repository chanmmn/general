using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAutoMapper
{
    public class AuthorModel
    {
        public int Id
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
    }

    public class AuthorDTO
    {
        public int Id
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AutoMap();
            Console.ReadKey();
        }

        public static void AutoMap()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AuthorModel, AuthorDTO>();
            });
            IMapper iMapper = config.CreateMapper();
            var source = new AuthorModel();
            source.Id = 1;
            source.FirstName = "Joydip";
            source.LastName = "Kanjilal";
            source.Address = "India";
            var destination = iMapper.Map<AuthorModel, AuthorDTO>(source);
            Console.WriteLine("Author Name: " + destination.FirstName + " " + destination.LastName);
        }
    }
}
