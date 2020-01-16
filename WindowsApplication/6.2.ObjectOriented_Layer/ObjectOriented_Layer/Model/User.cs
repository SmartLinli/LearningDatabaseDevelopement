namespace ObjectOriented_Layer
{    
    /// <summary>
    /// 用户；
    /// </summary>
    public class User
    {        
        /// <summary>
        /// 用户号；
        /// </summary>
        public string No
        {
            get;
            set;
        }
        /// <summary>
        /// 密码（加密）；
        /// </summary>
        public byte[] Password
        {
            get;
            set;
        }
		/// <summary>
		/// 是否激活；
		/// </summary>
		public bool IsActivated
		{
			get;
			set;
		}
		/// <summary>
		/// 登录错误次数；
		/// </summary>
		public int LoginFailCount
		{
			get;
			set;
		}
	}
}
