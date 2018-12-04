using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_part3.Models
{
    public class NbaDataModel:DbContext
    {
        public NbaDataModel(DbContextOptions<NbaDataModel> options) : base(options)
        {

        }
        //reference  model 
        public DbSet<player> players { get; set; }
    }
}
