﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BDConnect
    {
        protected SqlConnection _cn = new SqlConnection(@"Data Source=THIENAN\SQLEXPRESS;Initial Catalog=QUANLYCAYGIAPHA;Integrated Security=True"); 
        
    }
}
