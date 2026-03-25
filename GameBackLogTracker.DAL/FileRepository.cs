using GameBackLogTracker.CORE.Interfaces;

namespace GameBackLogTracker.DAL
{
    public class FileRepository<T>: IRepository<T> where T : class
    {
        private readonly string _fileName;
        private readonly IMapper<T> _mapper;
        private List<T> _items;

        public FileRepository(string fileName, IMapper<T> mapper)
        {
            _fileName = fileName;
            _mapper = mapper;
            _items = Load();
        }
        private void Save(List<T> items)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                foreach (T item in items)
                {
                    sw.WriteLine(item);
                }
            }
        }
        private List<T>? Load()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public T Create(T Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public T ReadById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
