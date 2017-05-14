using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AndiDance.Persistence.Repository;
using AndiDance.Data;

namespace AndiDance.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MemberRepository mr = new MemberRepository();
            Member member = new Member
            {
                Age = 1,
                Balance = 100,
                Birthday = DateTime.Now.Date,
                CardId = "333",
                CourseCounselorId = 2,
                CourseCounselorName = "奥黛丽",
                Gender = "女",
                IsDeleted = false,
                Name = "黛安娜",
                Phone = "13332442311",
                QQ = "555367",
                RegDate = DateTime.Now,
                Remarks = "一刀一人",
                StudioId = 1,
                StudioName = "地球分店",
                TransactorId = 1,
                TransactorName = "BetaCat",
                Type = "英雄"
            };
            mr.Add(member);
        }

        private int GetDayOfWeek(DateTime dt)
        {
            var dayOfWeek = (int)dt.DayOfWeek - 1;
            return dayOfWeek == -1 ? 6 : dayOfWeek;
        }
    }
}
