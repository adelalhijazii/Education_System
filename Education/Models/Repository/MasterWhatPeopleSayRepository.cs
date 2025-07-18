namespace Education.Models.Repository
{
    public class MasterWhatPeopleSayRepository : IRepository<MasterWhatPeopleSay>
    {
        public MasterWhatPeopleSayRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterWhatPeopleSay entity)
        {
            MasterWhatPeopleSay data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterWhatPeopleSay entity)
        {
            entity.IsActive = true;
            Db.MasterWhatPeopleSay.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterWhatPeopleSay entity)
        {
            MasterWhatPeopleSay data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterWhatPeopleSay Find(int id)
        {
            var data = Db.MasterWhatPeopleSay.SingleOrDefault(x => x.MasterWhatPeopleSayId == id);
            return data;
        }

        public void Update(int id, MasterWhatPeopleSay entity)
        {
            Db.MasterWhatPeopleSay.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterWhatPeopleSay> View()
        {
            return Db.MasterWhatPeopleSay.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterWhatPeopleSay> ViewFromClient()
        {
            return Db.MasterWhatPeopleSay.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
