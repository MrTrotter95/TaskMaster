


namespace TaskMasterWeb.Repositories
{ 
    public static class ClientRepository 
    {
        private TaskMasterDataEntities db = new TaskMasterDataEntities();

        public List<Clients> GetAllClients()
        {
            return db.Clients.ToList();
        }
    }
}