using Nancy;
using HelloWorld.Repository;

namespace HelloWorld
{
    public class SystemModule: NancyModule
    {
        public SystemModule(IRepository<Models.System> _repo)
            : base("/sys")
        {
            Get("/", args =>
            {
                return _repo.FindAll();
            });

            Get("Id={id}", args =>
            {
                return _repo.FindByID(args.id);
            });

            Post("/ID={id}&Desc={description}", args =>
            {
                var posted = new Models.System();
                posted.ID = args.Id;
                posted.Description = args.Description;
       
                _repo.Add(posted);

                return posted;
            });

            Delete("Id={id}", args =>
            {
                _repo.Remove(args.id);
                return $"{args.id} Removed";
            });
        }
    }
}
