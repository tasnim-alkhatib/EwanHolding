using EwanHolding.Application.Repositories.Implementation;
using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Domain.Entities;
using EwanHolding.Infrastructure.Persistence;

namespace EwanHolding.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EwanHoldingDbContext _context;

        public IAdminRepository Admins { get; private set; }
        public ICompanyRepository Companies { get; private set; }
        public IServiceRepository Services { get; private set; }
        public ICoreValueRepository CoreValues { get; private set; }
        public IStatRepository Stats { get; private set; }
        public IInvestmentOpportunitiesRepository InvestmentOpportunities { get; private set; }
        public INewsRepository News { get; private set; }
        public IContactRepository Contacts { get; private set; }
        public IMediaRepository Media { get; private set; }
        public ITermsAndConditionsRepository TermsAndConditions { get; private set; }
        //public IPageContentRepository PageContents { get; private set; }

        public UnitOfWork(EwanHoldingDbContext context)
        {
            _context = context;
            Admins = new AdminRepository(_context);
            Companies = new CompanyRepository(_context);
            Services = new ServiceRepository(_context);
            CoreValues = new CoreValueRepository(_context);
            Stats = new StatRepository(_context);
            InvestmentOpportunities = new InvestmentOpportunitiesRepository(_context);
            News = new NewsRepository(_context);
            Contacts = new ContactRepository(_context);
            Media = new MediaRepository(_context);
            TermsAndConditions = new TermsAndConditionsRepository(_context);
            //PageContents = new PageContentRepository(_context);
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
