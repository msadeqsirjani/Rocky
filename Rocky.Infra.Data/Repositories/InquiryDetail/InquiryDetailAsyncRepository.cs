﻿using Rocky.Domain.Interfaces.InquiryDetail;
using Rocky.Infra.Data.Persistence;
using Rocky.Infra.Data.Repositories.Common;
using Rocky.Infra.Data.Scrutor;

namespace Rocky.Infra.Data.Repositories.InquiryDetail
{
    public class InquiryDetailAsyncRepository : AsyncRepository<Domain.Entities.InquiryDetail, int>, IScoped, IInquiryDetailAsyncRepository
    {
        public InquiryDetailAsyncRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
