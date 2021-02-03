using System.Collections.Generic;

namespace inplup1MVC.ViewModels
{
    public class AdminRolesIndexViewModel
    {
        public List<AdminRoleItem> Items { get; set; }

        public class AdminRoleItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}