using System;
using System.Collections.Generic;

namespace DemoAuroraServerlessBeanstalkNetCore.DataModels
{
    public partial class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ComposerId { get; set; }

        public virtual Composer Composer { get; set; }
    }
}
