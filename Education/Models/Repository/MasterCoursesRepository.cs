namespace Education.Models.Repository
{
    public class MasterCoursesRepository : IRepository<MasterCourses>
    {
        public MasterCoursesRepository(AppDbContext _db)
        {
            Db = _db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterCourses entity)
        {
            MasterCourses data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterCourses entity)
        {
            entity.IsActive = true;
            Db.MasterCourses.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterCourses entity)
        {
            MasterCourses data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterCourses Find(int id)
        {
            var data = Db.MasterCourses.SingleOrDefault(x => x.MasterCoursesId == id);
            return data;
        }

        public void Update(int id, MasterCourses entity)
        {
            Db.MasterCourses.Update(entity);
            Db.SaveChanges();
        }

        public IList<MasterCourses> View()
        {
            return Db.MasterCourses.Where(data => data.IsDelete == false).ToList();
        }

        public IList<MasterCourses> ViewFromClient()
        {
            return Db.MasterCourses.Where(data => data.IsDelete == false && data.IsActive == true).ToList();
        }
    }
}
