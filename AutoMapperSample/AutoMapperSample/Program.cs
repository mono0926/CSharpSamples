using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapperSample.Model;
using AutoMapperSample.ViewModel;

namespace AutoMapperSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var me = new Person { FirstName = "masayuki", LastName = "ono" };
            var meViewModel = new PersonViewModel();
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.Map(me, meViewModel);
            Console.WriteLine(me);
            Console.WriteLine(meViewModel);
            Console.ReadLine();
        }
    }
}