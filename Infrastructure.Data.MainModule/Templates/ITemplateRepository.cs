using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.MainModule.Templates
{
    public interface ITemplateRepository : IRepository<Domain.Entities.Template>
    {
        List<Template> GetAll();
    }
}
