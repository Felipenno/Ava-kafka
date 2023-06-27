using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Email.Settings;
public class MongodbSettings
{
    public string ConnectionString { get; set; }
    public string Database { get; set; }
}