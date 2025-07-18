namespace Education.Models.Repository
{
    public class MasterTrainersRepository : IRepository<MasterTrainers>
    {
        public MasterTrainersRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterTrainers entity)
        {
            MasterTrainers data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterTrainers entity)
        {
            entity.IsActive = true;
            Db.MasterTrainers.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterTrainers entity)
        {
            MasterTrainers data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterTrainers Find(int id)
        {
            var data = Db.MasterTrainers.SingleOrDefault(x => x.MasterTrainersId == id);
            return data;
        }

        public void Update(int id, MasterTrainers entity)
        {
            Db.MasterTrainers.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterTrainers> View()
        {
            return Db.MasterTrainers.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterTrainers> ViewFromClient()
        {
            return Db.MasterTrainers.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
