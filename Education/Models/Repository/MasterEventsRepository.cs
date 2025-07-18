namespace Education.Models.Repository
{
    public class MasterEventsRepository : IRepository<MasterEvents>
    {
        public MasterEventsRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterEvents entity)
        {
            MasterEvents data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterEvents entity)
        {
            entity.IsActive = true;
            Db.MasterEvents.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterEvents entity)
        {
            MasterEvents data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterEvents Find(int id)
        {
            var data = Db.MasterEvents.SingleOrDefault(x => x.MasterEventsId == id);
            return data;
        }

        public void Update(int id, MasterEvents entity)
        {
            Db.MasterEvents.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterEvents> View()
        {
            return Db.MasterEvents.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterEvents> ViewFromClient()
        {
            return Db.MasterEvents.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
