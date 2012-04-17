using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapperSample.Model;
using AutoMapperSample.ViewModel;

namespace AutoMapperSample.Profiles
{
    public class PersonProfile : Profile
    {
        public override string ProfileName { get { return "PersonProfile"; } }

        protected override void Configure()
        {
            Mapper.ForSourceType<DateTime>().AddFormatter<DateStringFormatterJP>();
            Mapper.CreateMap<Person, PersonViewModel>()
                .ForMember(v => v.FullName,
                        opt => opt.MapFrom(m => string.Format("{0} {1}", m.FirstName, m.LastName)));
        }
    }
}