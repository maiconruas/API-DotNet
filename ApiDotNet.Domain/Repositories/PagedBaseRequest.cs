namespace ApiDotNet.Domain.Repositories
{
	public class PagedBaseRequest
	{
        public int Page{ get; set; }
		public int pageSize { get; set; }
		public string OrderByProperty { get; set; }

		public PagedBaseRequest()
		{
			Page = 1;
			pageSize = 10;
			OrderByProperty = "Id";
		}
	}
}
