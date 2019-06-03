using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.Interfaces
{
    public interface ICustomMap
    {
        void CreateMappings(Profile configuration);
    }
}
