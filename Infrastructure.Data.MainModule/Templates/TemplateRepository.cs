using Infrastructure.Common.Caching;
using Infrastructure.Data.MainModule.Models;
using Infrastructure.Data.MainModule.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MainModule.Hypermedia
{
    public class HypermediaRepository : ITemplateRepository
    {
        private readonly TemplateContext _context = new TemplateContext();

        public List<Domain.Entities.Template> GetManyBy(Func<Domain.Entities.Template, bool> predicate)
        {
            var items = _context.Templates.Where(predicate);

            return items.ToList();
        }

        public Domain.Entities.Template GetBy(Func<Domain.Entities.Template, bool> predicate)
        {
            var item = _context.Templates.FirstOrDefault(predicate);

            return item;
        }

        public Domain.Entities.Template Add(Domain.Entities.Template item)
        {
            item.DateCreated = DateTime.Now;

            var addeditem = _context.Templates.Add(item);

            _context.SaveChanges();

            return addeditem;
        }

        public Domain.Entities.Template Update(Domain.Entities.Template item)
        {
            var itemToUpdate = _context.Templates.FirstOrDefault(i => i.Id == item.Id);

            itemToUpdate.Property1 = item.Property1;

            itemToUpdate.Property2 = item.Property2;
            
            itemToUpdate.DateModified = DateTime.Now;

            _context.SaveChanges();

            return itemToUpdate;
        }

        public Domain.Entities.Template Delete(int id)
        {
            var itemToRemove = _context.Templates.FirstOrDefault(i => i.Id == id);

            var deletedItem = _context.Templates.Remove(itemToRemove);

            _context.SaveChanges();

            return itemToRemove;
        }

        public List<Domain.Entities.Template> GetAll()
        {
            var items = _context.Templates;

            return items.ToList();
        }
    }
}
