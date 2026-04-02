using GameBackLogTracker.CORE.Interfaces;

namespace GameBackLogTracker.DAL
{
    public class FileRepository<T>: IRepository<T> where T : class, IEntity, new()
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
                    sw.WriteLine(_mapper.Serialize(item));
                }
            }
        }
        private List<T> Load()
        {
            if(!File.Exists(_fileName))
            {
                File.Create(_fileName).Close();
            }
            List<T> items = new();
            try
            {
                using (StreamReader sr = new(_fileName))
                {
                    T item = new();
                    string input = sr.ReadLine();
                    while (input != null)
                    {
                        item = _mapper.Deserialize(input);
                        items.Add(item);
                        input = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
            return items;
        }
        public void Commit()
        {
            Save(_items);
        }
        public T Create(T Entity)
        {
            int maxId = 0;
            if (_items.Count > 0)
            {
                maxId = _items.Max(i => i.Id);
            }
            Entity.Id = maxId + 1;
            _items.Add(Entity);
            return Entity;
        }

        public void Delete(int Id)
        {
            int index = -1;
            for(int i = 0; i < _items.Count; i++)
            {
                if(_items[i].Id == Id)
                {
                    _items.RemoveAt(i);
                    i--;
                }
            }
        }
        public List<T> ReadAll()
        {
            return Load();
        }
        public T ReadById(int Id)
        {
            throw new NotImplementedException();
        }
        public void Rollback()
        {
            _items = Load();
        }
        public void Update(int id, T Entity)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if(_items[i].Id == id)
                {
                    _items[i] = Entity;
                    return;
                }
            }
        }
    }
}
