using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectOriented_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOriented_Class.Tests
{
	[TestClass()]
	public class UserTests
	{
		[TestMethod()]
		public void LogInTest()
		{
			User target = new User();               // TODO: 初始化为适当的值
			target.No = "3180707001";               // 此处输入正确的用户号、密码；
			target.Password = "7001";
			bool expected = true;                   // TODO: 初始化为适当的值
			bool actual = target.LogIn();           // 该方法涉及App.config，故还需从原项目中将App.config复制至测试项目；
			Assert.AreEqual(expected, actual);      // 测试预期值、实际值否相等；如果两个值相等，则测试通过。
		}
	}
}