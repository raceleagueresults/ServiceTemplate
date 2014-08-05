using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Mappings.Templates
{
    public class TemplateMapper : IMapper<Domain.Entities.Template, DistributedServices.Entities.TemplateDto>
    {
        public Domain.Entities.Template Map(DistributedServices.Entities.TemplateDto obj)
        {
            if (obj == null)
                return new Domain.Entities.Template();

            return new Domain.Entities.Template
            {
                Property1 = obj.Property1,
                Property2 = obj.Property2,
                Id = obj.Id
            };
        }

        public DistributedServices.Entities.TemplateDto Map(Domain.Entities.Template obj)
        {
            if (obj == null)
                return new DistributedServices.Entities.TemplateDto();

            return new DistributedServices.Entities.TemplateDto
            {
                Property1 = obj.Property1,
                Property2 = obj.Property2,
                Id = obj.Id
            };
        }


        public List<Domain.Entities.Template> Map(List<DistributedServices.Entities.TemplateDto> objs)
        {
            if (objs == null)
                return new List<Domain.Entities.Template>();

            var items = objs.Select(obj => new Domain.Entities.Template
            {
                Property1 = obj.Property1,
                Property2 = obj.Property2,
                Id = obj.Id
            });

            return items.ToList();
        }

        public List<DistributedServices.Entities.TemplateDto> Map(List<Domain.Entities.Template> objs)
        {
            if (objs == null)
                return new List<DistributedServices.Entities.TemplateDto>();

            var items = objs.Select(obj => new DistributedServices.Entities.TemplateDto
            {
                Property1 = obj.Property1,
                Property2 = obj.Property2,
                Id = obj.Id
            });

            return items.ToList();
        }
    }
}
