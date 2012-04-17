using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapperSample.Model;
using AutoMapperSample.Profiles;
using AutoMapperSample.ViewModel;

namespace AutoMapperSample.Logic
{
    public class AutoMapperDriver
    {
        public PersonViewModel MapSimple(Person person, bool validate = false)
        {
            Mapper.CreateMap<Person, PersonViewModel>();
            if (validate)
            {
                Mapper.AssertConfigurationIsValid();
            }
            var meViewModel = new PersonViewModel();
            Mapper.Map(person, meViewModel);
            return meViewModel;
        }

        public PersonViewModel MapSimple2(Person person, bool validate = false)
        {
            var meViewModel = new PersonViewModel();
            Mapper.CreateMap<Person, PersonViewModel>();
            if (validate)
            {
                Mapper.AssertConfigurationIsValid();
            }
            return Mapper.Map<PersonViewModel>(person);
        }

        public PersonViewModel MapWithIgnore(Person person)
        {
            var meViewModel = new PersonViewModel();
            Mapper.CreateMap<Person, PersonViewModel>()
                .ForMember(v => v.FullName, opt => opt.Ignore());
            Mapper.AssertConfigurationIsValid();
            return Mapper.Map<PersonViewModel>(person);
        }

        public PersonViewModel MapWithFullName(Person person)
        {
            Mapper.CreateMap<Person, PersonViewModel>()
                .ForMember(v => v.FullName,
                        opt => opt.MapFrom(m => string.Format("{0} {1}", m.FirstName, m.LastName)));
            Mapper.AssertConfigurationIsValid();
            return Mapper.Map<PersonViewModel>(person);
        }

        public PersonViewModel MapWithProfile(Person person)
        {
            Mapper.AddProfile<PersonProfile>();
            Mapper.AssertConfigurationIsValid();
            return Mapper.Map<PersonViewModel>(person);
        }
    }
}