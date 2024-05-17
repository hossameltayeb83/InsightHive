namespace InsightHive.Identity.Authentication
{
    public static class PolicyData
    {
        public const string RoleClaimName = "userRole";
        public const string AdminPolicyName = "Admin";
        public const string AdminClaimValue = "admin";
        public const string OwnerPolicyName = "Owner";
        public const string OwnerClaimValue = "owner";
        public const string UserPolicyName = "Reviewer";
        public const string UserClaimValue = "reviewer";
    }
}
