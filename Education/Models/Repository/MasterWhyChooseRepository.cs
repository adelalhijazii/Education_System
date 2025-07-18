namespace Education.Models.Repository
{
    public class MasterWhyChooseRepository : IRepository<MasterWhyChoose>
    {
        public MasterWhyChooseRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterWhyChoose entity)
        {
            MasterWhyChoose data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterWhyChoose entity)
        {
            entity.IsActive = true;
            Db.MasterWhyChoose.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterWhyChoose entity)
        {
            MasterWhyChoose data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterWhyChoose Find(int id)
        {
            var data = Db.MasterWhyChoose.SingleOrDefault(x => x.MasterWhyChooseId == id);
            return data;
        }

        public void Update(int id, MasterWhyChoose entity)
        {
            Db.MasterWhyChoose.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterWhyChoose> View()
        {
            return Db.MasterWhyChoose.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterWhyChoose> ViewFromClient()
        {
            return Db.MasterWhyChoose.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
