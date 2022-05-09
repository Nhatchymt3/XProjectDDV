pushd Repository\XProject.Repository
dotnet ef migrations add %1 -v --context AppDbContext
dotnet ef database update -v --context AppDbContext
popd