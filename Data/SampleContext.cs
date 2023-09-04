using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RenderSample.Data.Entities;

namespace RenderSample.Data
{
	public class SampleContext : IdentityDbContext<AppUser>
	{
		public SampleContext(DbContextOptions<SampleContext> options):base(options)
		{
		}
	}
}

