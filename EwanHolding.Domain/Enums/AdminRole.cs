using System;
using System.Collections.Generic;
using System.Text;

namespace EwanHolding.Domain.Enums
{
    public enum AdminRole
    {
        SuperAdmin = 1,
        Editor = 2,
        ContentManager = 3, // was "ContentManagement" - renamed to match the exact string used in every
                             // [Authorize(Roles = "...")] attribute across the controllers (Contact, Media,
                             // News, PageContent, TermsAndConditions, ...). The two didn't match before,
                             // which meant an admin with this role always got 403 Forbidden on those endpoints.
                             // Safe rename: EF Core stores enums as int by default, so existing rows are unaffected.
    }
}
