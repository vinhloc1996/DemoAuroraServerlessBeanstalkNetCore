using System;
using System.Collections.Generic;

namespace DemoAuroraServerlessBeanstalkNetCore.DataModels
{
    public partial class Composer
    {
        public Composer()
        {
            Music = new HashSet<Music>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Music> Music { get; set; }
    }
}
