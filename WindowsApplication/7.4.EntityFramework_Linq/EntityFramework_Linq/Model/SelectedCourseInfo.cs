namespace EntityFramework_Linq
{
	/// <summary>
	/// 已选课程信息；
	/// </summary>
	public partial class SelectedCourseInfo
	{
		/// <summary>
		/// 课程号；
		/// </summary>
		public string No { get; set; }
		/// <summary>
		/// 课程名称；
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 学分；
		/// </summary>
		public decimal Credit { get; set; }
		/// <summary>
		/// 可否被移除；
		/// </summary>
		public bool CanBeRemoved => this.State == EntityInfoState.Added;
		/// <summary>
		/// 是否订购教材；
		/// </summary>
		private bool _OrderBook;
		public bool OrderBook
		{
			get => this._OrderBook;
			set
			{
				this._OrderBook = value;
				if (this.State != EntityInfoState.Added)
				{
					this.State = EntityInfoState.Modified;
				}
			}
		}
		/// <summary>
		/// 状态；
		/// </summary>
		public EntityInfoState State { get; set; }
	}
}
