using DistributedServices.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Templates
{
    public interface ITemplateService : IService<Domain.Entities.Template>
    {
        List<Template> GetAll();
    }
}
